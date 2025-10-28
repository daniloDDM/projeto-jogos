using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida = 30;

    public void TakeDamage(int amount)
    {
        vida -= amount;
        Debug.Log(name + " levou dano! HP atual: " + vida);

        if (vida <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(name + " morreu!");
        Destroy(gameObject);
    }
}
