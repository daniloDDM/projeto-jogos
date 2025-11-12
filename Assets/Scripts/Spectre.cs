using UnityEngine;

public class Spectre : Inimigo
{
    void Update()
    {
        base.Update();

        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // vira conforme a posição do jogador
            if (Mathf.Abs(direction.x) > 0.01f)
            {
                float facing = direction.x < 0f ? -1f : 1f;
                var s = transform.localScale;
                transform.localScale = new Vector3(Mathf.Abs(s.x) * facing, s.y, s.z);
            }
        }
    }

    // === DANO NO PLAYER ===
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // destrói o inimigo
            Destroy(gameObject);

            // chama a função global de dano (se você tiver o GameManager)
            GameManager.LoseLife(1);
        }
    }
}
