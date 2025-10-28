using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int dano = 10;
    public string tagInimigo = "Inimigo";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagInimigo))
        {
            Inimigo inimigo = other.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                inimigo.TakeDamage(dano);
            }
        }
    }
}
