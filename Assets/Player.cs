using UnityEngine;

public class Player : MonoBehaviour
{

    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.UpArrow;
    public KeyCode golpe = KeyCode.Space;
    //public KeyCode fire = KeyCode.Space;
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public float boundX = 13.0f;
    public float boundY = 4.5f;

    //public GameObject tiroPrefab;
    //public Transform firePoint;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("pisando", isGrounded);
        animator.SetBool("andandoDireita", false);
        animator.SetBool("andandoEsquerda", false);
        animator.SetBool("golpeando", false);

        float horizontalDirection = 0.0f;

        if (Input.GetKey(moveRight))
        {
            animator.SetBool("andandoDireita", true);
            horizontalDirection = 1.0f;
        }
        else if (Input.GetKey(moveLeft))
        {
            animator.SetBool("andandoEsquerda", true);
            horizontalDirection = -1.0f;
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        var hVelocity = rb.velocity;
        hVelocity.x = horizontalDirection * moveSpeed;
        rb.velocity = hVelocity;

        var hPosition = transform.position;
        hPosition.x = Mathf.Clamp(hPosition.x, -boundX, boundX);
        transform.position = hPosition;

        if (Input.GetKey(golpe))
        {
            animator.SetBool("golpeando", true);
        }

        //if (Input.GetKeyDown(fire))
        //{
        //    firePoint = transform.Find("FirePoint");
        //    Instantiate(tiroPrefab, firePoint.position, Quaternion.identity);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = false;
        }
    }
}