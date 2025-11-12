using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public GameObject inimigoPrefab;

    public Transform point1;
    public Transform point2;
    public Transform point3;

    private float timer = 0.0f;
    public static float waitTime = 2.0f;

    private void Start()
    {
        gerarInimigo();
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
                gerarInimigo();
                if (waitTime > 0)
                {
                    waitTime -= 0.01f;
                }
            }
        }

    }

    void gerarInimigo()
    {
        int randomPoint = Random.Range(1, 4);
        switch (randomPoint)
        {
            case 1:
                Instantiate(inimigoPrefab, point1.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(inimigoPrefab, point2.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(inimigoPrefab, point3.position, Quaternion.identity);
                break;
        }
    }
}