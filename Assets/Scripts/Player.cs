using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [Header("Input")]
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.UpArrow;
    public KeyCode golpe = KeyCode.Space;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public float boundX = 13.0f;
    public float boundY = 4.5f;

    public GameObject hitbox;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    float inputX;
    bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        hitbox.SetActive(false);

        // Suaviza visual quando a física interpola entre passos de FixedUpdate
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        inputX = 0f;
        if (Input.GetKey(moveRight)) inputX += 1f;
        if (Input.GetKey(moveLeft)) inputX -= 1f;

        animator.SetBool("pisando", isGrounded);
        animator.SetFloat("andando", Mathf.Abs(inputX));

        if (inputX != 0f) // virar o personagem (tinha feito de outro jeito, mas mudei já pensando no combate)
        {
            float facing = inputX < 0f ? -1f : 1f;
            var s = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(s.x) * facing, s.y, s.z);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (Input.GetKeyDown(golpe))
            animator.SetTrigger("golpeando");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        var pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        rb.position = pos;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Plataforma")) isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Plataforma")) isGrounded = false;
    }

    public void EnableHitbox()
    {
        hitbox.SetActive(true);
        Debug.Log("true");
    }

    public void DisableHitbox()
    {
        hitbox.SetActive(false);
        Debug.Log("false");
    }
}