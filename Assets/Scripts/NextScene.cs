using UnityEngine;

public class NextScene : MonoBehaviour
{
    public string[] Scenes;
    public void nextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/" + Scenes[Random.Range(0, Scenes.Length)]) ;
    }
}
