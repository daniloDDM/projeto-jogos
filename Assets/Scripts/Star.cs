using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
    public GameObject eba;
    public string scena;
    public float delay = 1.0f; // tempo pra esperar antes de trocar de cena

    private bool used = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (used) return; // evita chamar duas vezes

        if (other.CompareTag("Player"))
        {
            used = true;
            StartCoroutine(TrocarCenaDepoisDaAnim());
        }
    }

    IEnumerator TrocarCenaDepoisDaAnim()
    {
        // instancia o efeito
        if (eba != null)
        {
            GameObject efeito = Instantiate(eba, transform.position, Quaternion.identity);
            Destroy(efeito, 0.5f);
        }

        // opcional: esconder a estrela
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // espera o tempo da animação
        yield return new WaitForSeconds(delay);

        // escolhe cena
        if (scena == "Valhalla")
        {
            ScenaLoader.loadValhalla();
        }
        else if (scena == "Niflheim")
        {
            ScenaLoader.loadNiflheim();
        }
        else if (scena == "Win")
        {
            ScenaLoader.loadWin();
        }
        else
        {
            Debug.LogWarning("Valor de 'scena' não reconhecido: " + scena);
        }

        // se quiser destruir de vez:
        Destroy(gameObject);
    }
}
