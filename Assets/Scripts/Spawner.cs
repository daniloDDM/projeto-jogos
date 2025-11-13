using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public GameObject inimigoPrefab;

    public Transform point;

    private float timer = 0.0f;
    public static float waitTime = 2.0f;

    private void Start()
    {
        Instantiate(inimigoPrefab, point.position, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0.0f;
            int randomPoint = Random.Range(1, 4);
            if (randomPoint != 1)
            {
                Instantiate(inimigoPrefab, point.position, Quaternion.identity);
                if (waitTime > 0)
                {
                    waitTime -= 0.01f;
                }
            }
        }

    }

}