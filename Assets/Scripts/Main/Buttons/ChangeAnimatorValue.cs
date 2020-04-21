using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimatorValue : MonoBehaviour
{
    [SerializeField] private Animator buttonAnimator;
 
    public void ChangeStateTo(int value)
    {
        buttonAnimator.SetInteger("State", value);
    }
}
