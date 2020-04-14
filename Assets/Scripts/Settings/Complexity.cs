using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complexity : MonoBehaviour
{
    static int val = 0;
    UnityEngine.UI.Dropdown dropdown;
    void Start()
    {
        dropdown = gameObject.transform.GetComponent<UnityEngine.UI.Dropdown>();
        dropdown.value = val;
    }
    void Update()
    {
        if (dropdown.value != val) val = dropdown.value; 
    }
}
