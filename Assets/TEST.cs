using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    [SerializeField] Color ToLeft;
    [SerializeField] Color ToRight;
    [SerializeField] Image image;
    private void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        Color d = (axis > 0) ? ToLeft : ToRight;
        d *= System.Math.Abs(axis);
        image.color = d;
        
        Debug.Log(axis);
    }
}
