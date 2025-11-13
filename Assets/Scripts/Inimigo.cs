using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Atributos b�sicos")]
    public int vida = 30;
    public float moveSpeed = 3f;
    public Transform target;
    public GameObject tomandoDano;

    protected Rigidbody2D rb;
    protected Animator animator;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public virtual void TakeDamage(int amount)
    {
        GameObject efeito = Instantiate(tomandoDano, transform.position, Quaternion.identity);
        Destroy(efeito, 0.5f);

        vida -= amount;
        Debug.Log($"{name} levou dano! HP atual: {vida}");

        if (vida <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Debug.Log($"{name} morreu!");
        Destroy(gameObject);
        GameManager.AddScore(10);
    }
}
