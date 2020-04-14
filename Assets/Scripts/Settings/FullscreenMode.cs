using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenMode : MonoBehaviour
{
    UnityEngine.UI.Toggle toggle;
    void Start()
    {
        toggle = gameObject.transform.GetComponent<UnityEngine.UI.Toggle>();
        toggle.isOn = Screen.fullScreen;
    }

    void Update()
    {
        if (toggle.isOn != Screen.fullScreen) 
            Screen.fullScreen = toggle.isOn;
    }
}
