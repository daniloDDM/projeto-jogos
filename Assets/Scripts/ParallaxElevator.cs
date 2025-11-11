using UnityEngine;

public class ParallaxElevator : MonoBehaviour
{
    public bool isActive = false;
    public float parallaxEffect = 1f; // velocidade
    public float maxHeight = 0f;
    public float minHeight = 0f;

    private float dir = -1f;
    private Rigidbody2D rb;
    const float EPS = 0.001f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody2D>();

        // Plataforma móvel deve ser Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        // se começar fora do range, clampa
        var p = rb.position;
        p.y = Mathf.Clamp(p.y, Mathf.Min(minHeight, maxHeight), Mathf.Max(minHeight, maxHeight));
        rb.position = p;

        // decide direção inicial se estiver numa borda
        if (Mathf.Abs(p.y - minHeight) <= EPS) dir = 1f;
        else if (Mathf.Abs(p.y - maxHeight) <= EPS) dir = -1f;
    }

    void FixedUpdate()
    {
        if (!isActive) return;

        // calcula próximo Y
        float nextY = rb.position.y + parallaxEffect * Time.fixedDeltaTime * dir;

        // se passou do limite, inverte e "reflete" o excesso para não tremer
        if (nextY <= Mathf.Min(minHeight, maxHeight))
        {
            float overflow = Mathf.Min(minHeight, maxHeight) - nextY;
            dir = 1f;
            nextY = Mathf.Min(minHeight, maxHeight) + overflow; // bounce limpo
        }
        else if (nextY >= Mathf.Max(minHeight, maxHeight))
        {
            float overflow = nextY - Mathf.Max(minHeight, maxHeight);
            dir = -1f;
            nextY = Mathf.Max(minHeight, maxHeight) - overflow; // bounce limpo
        }

        // move usando física
        Vector2 next = new Vector2(rb.position.x, nextY);
        rb.MovePosition(next);
    }

    public void SetActive()
    {
        isActive = true;
    }

    // só para visualizar no editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        var x = transform.position.x;
        var z = transform.position.z;
        Vector3 a = new Vector3(x, Mathf.Min(minHeight, maxHeight), z);
        Vector3 b = new Vector3(x, Mathf.Max(minHeight, maxHeight), z);
        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(a, 0.05f);
        Gizmos.DrawSphere(b, 0.05f);
    }
}
