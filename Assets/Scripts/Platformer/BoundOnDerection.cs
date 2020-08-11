using Delegates;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class BoundOnDerection : MonoBehaviour
{
    [SerializeField] Bound _parentBound;

    public bool isOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<HeroMove>() != null)
        {
            isOn = true;
            _parentBound.CreateNewWay();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<HeroMove>() != null)
        {
            isOn = false;
            _parentBound.DeleteOldWay();
        }
    }
}
