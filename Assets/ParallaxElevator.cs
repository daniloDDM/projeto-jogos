using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ParallaxElevator : MonoBehaviour
{
    public bool isActive = false;
    public float parallaxEffect = 1;
    public float maxHeight = 0f;
    public float minHeight = 0f;
    private float dir = -1f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (!isActive) return;
        transform.position += Vector3.up * parallaxEffect * Time.deltaTime  * dir;
        if (transform.position.y <= minHeight || transform.position.y >= maxHeight)
        {
            dir = dir * -1f;
        }
    }

    public void SetActive()
    {
        isActive = true;
    }
}
