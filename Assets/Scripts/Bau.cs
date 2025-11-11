using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    public bool isActive = false;
    public ParallaxElevator elevator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isActive) return;
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            elevator.SetActive();
        }
    }

    public void SetActive()
    {
        isActive = true;
    }
}
