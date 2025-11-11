using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ParallaxElevator : MonoBehaviour
{
    public float parallaxEffect = 1;
    public float maxHeight = 0f;
    public float minHeight = 0f;
    private float dir = -1f;

    void Update()
    {
        transform.position += Vector3.up * parallaxEffect * Time.deltaTime  * dir;
        if (transform.position.y <= minHeight || transform.position.y >= maxHeight)
        {
            dir = dir * -1f;
        }
    }
}
