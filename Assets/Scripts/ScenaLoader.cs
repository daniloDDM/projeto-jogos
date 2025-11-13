using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaLoader : MonoBehaviour
{
    public static void loadHelheim() => SceneManager.LoadScene("tileset-helheim");
    public static void loadValhalla() => SceneManager.LoadScene("tileset-valhalla");
}
