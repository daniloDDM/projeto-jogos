using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Status")]
    public int vida = 10;

    // Chamado quando o inimigo recebe dano
    public void TakeDamage(int dano)
    {
        vida -= dano;
        Debug.Log($"Inimigo tomou {dano} de dano! Vida restante: {vida}");

        if (vida <= 0)
            Morrer();
    }

    void Morrer()
    {
        Debug.Log("Inimigo derrotado!");
        Destroy(gameObject);
    }
}
