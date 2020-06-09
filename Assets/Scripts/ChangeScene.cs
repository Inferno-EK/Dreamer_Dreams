using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    public void ChangeSceneTo(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}
