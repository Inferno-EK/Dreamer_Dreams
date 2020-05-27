using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousInitialisating : MonoBehaviour
{
    [SerializeField] private Way _firstWay;
    private void Awake()
    {
        _firstWay.CreateOther();
        Destroy(gameObject);
    }
}
