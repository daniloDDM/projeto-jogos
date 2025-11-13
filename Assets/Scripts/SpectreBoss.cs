using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreBoss : Inimigo
{
    public GameObject morrendo;

    protected override void Update()
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

    protected override void Die()
    {
        GameObject efeito = Instantiate(morrendo, transform.position, Quaternion.identity);
        Destroy(efeito, 0.5f);
        Debug.Log($"{name} morreu!");
        Destroy(gameObject);
        GameManager.AddScore(100);
    }

}
