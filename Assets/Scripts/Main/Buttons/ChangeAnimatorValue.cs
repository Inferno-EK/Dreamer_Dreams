using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimatorValue : MonoBehaviour
{
    [SerializeField] private Animator buttonAnimator;
 
    public void TurningButtons(bool value)
    {
        buttonAnimator.SetBool("IsON", value);
    }
    public void TurningButtons()
    {
        buttonAnimator.SetBool("IsON", !buttonAnimator.GetBool("IsON"));
    }

}
