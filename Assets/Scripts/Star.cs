using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
    public GameObject eba;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject efeito = Instantiate(eba, transform.position, Quaternion.identity);
            Destroy(efeito, 0.5f);
            Destroy(gameObject);
            ScenaLoader.loadValhalla();
            //StartCoroutine(TrocarCenaDepoisDaAnim());
        }
    }

    //IEnumerator TrocarCenaDepoisDaAnim()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    ScenaLoader.loadValhalla();
    //}
}
