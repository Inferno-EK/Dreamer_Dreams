using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonTextTo : MonoBehaviour
{
    [SerializeField] private string CommonText = "";
    [SerializeField][TextArea] private string OnOverText = "";
    [SerializeField] private UnityEngine.UI.Text TextField = null;
 
    public void OnOver()
    {
        TextField.text = OnOverText;
    }

    public void OnExit()
    {
        TextField.text = CommonText;
    }
}
