using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaLoader : MonoBehaviour
{
    public static void loadMenu() => SceneManager.LoadScene("Menu");
    public static void loadHelheim() => SceneManager.LoadScene("tileset-helheim");
    public static void loadNiflheim() => SceneManager.LoadScene("Niflheim");
    public static void loadValhalla() => SceneManager.LoadScene("tileset-valhalla");
    public static void loadLose() => SceneManager.LoadScene("Lose");
    public static void loadWin() => SceneManager.LoadScene("Win");
}
