using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleVsFamale : MonoBehaviour
{
    UnityEngine.UI.Slider slider;
    UnityEngine.UI.Text text;
    static int Male = 50;
    void Start()
    {
        slider = gameObject.transform.GetComponent<UnityEngine.UI.Slider>();
        slider.value = Male;
        text = gameObject.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
        text.text = $"{Male}|{100 - Male}";
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != Male)
        {
            Male = (int)slider.value;
            text.text = $"{Male}|{100 - Male}";
        }
    }
}
