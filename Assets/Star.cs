using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameManager.AddScore(200);
        }
    }
}
