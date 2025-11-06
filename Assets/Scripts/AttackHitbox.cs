using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int dano = 10;
    public string tagInimigo = "Inimigo";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other) return;

        // Debug para confirmar qual objeto colidiu
        Debug.Log($"Hitbox colidiu com: {other.gameObject.name} (tag: {other.gameObject.tag})");

        if (other.CompareTag(tagInimigo))
        {
            // procura o script no próprio objeto ou em um pai (cobre mais casos)
            Inimigo inimigo = other.GetComponent<Inimigo>() ?? other.GetComponentInParent<Inimigo>();

            if (inimigo != null)
            {
                inimigo.TakeDamage(dano);
                Debug.Log("Dano aplicado ao inimigo.");
            }
            else
            {
                Debug.LogWarning("Tag Inimigo encontrada mas componente Inimigo não foi localizado.");
            }
        }
    }
}