//using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static int Lives = 3;

    public GUIStyle textStyle;

    private void Awake()
    {
        Score = 0;
        Lives = 100;
    }

    public static void AddScore(int amount)
    {
        Score += amount;
        if (Score >= 500)
        {
            // SceneLoader.LoadGame();
            SpawnInimigo.waitTime = 2.0f;
        }
    }

    public static void LoseLife(int amount)
    {
        Lives -= amount;
        if (Lives <= 0)
        {
            // SceneLoader.LoadGame();
            SpawnInimigo.waitTime = 2.0f;
        }
    }

    void OnGUI()
    {
        if (Camera.current != Camera.main) return; // só desenha com a main camera ativa
        GUI.Label(new Rect(20, 20, 200, 40), "Score: " + Score, textStyle);
        GUI.Label(new Rect(Screen.width - 200, 20, 100, 40), "Lives: " + Lives, textStyle);
    }
}