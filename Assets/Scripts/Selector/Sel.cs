using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sel : MonoBehaviour
{
    public string[] Scenes;

    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Mods/" + Scenes[Random.Range(0, Scenes.Length)]);
    }
}