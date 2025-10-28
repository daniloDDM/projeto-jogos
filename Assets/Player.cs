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

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    float inputX;          // lido em Update
    bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        // Suaviza visual quando a física interpola entre passos de FixedUpdate
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        // --- INPUT ---
        inputX = 0f;
        if (Input.GetKey(moveRight)) inputX += 1f;
        if (Input.GetKey(moveLeft)) inputX -= 1f;

        // --- ANIMATOR PARAMS (somente set de valores, sem mover aqui) ---
        animator.SetBool("pisando", isGrounded);
        animator.SetFloat("andando", Mathf.Abs(inputX));  // use em um Blend Tree (0 = Idle, >0 = Walk)

        // Vira o sprite conforme direção
        if (inputX != 0f) sr.flipX = inputX < 0f;

        // Pulo
        if (Input.GetKeyDown(jump) && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Golpe como Trigger (no Animator crie o parâmetro "golpear" do tipo Trigger)
        if (Input.GetKeyDown(golpe))
            animator.SetTrigger("golpeando");
    }

    void FixedUpdate()
    {
        // --- MOVIMENTO DE FATO (física) ---
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        // --- LIMITES (se realmente precisar) ---
        var pos = rb.position; // usa rb.position em vez de transform.position
        pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        rb.position = pos;     // evita brigar com a física
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Plataforma")) isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Plataforma")) isGrounded = false;
    }
}