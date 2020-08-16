using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private GameObject leftBounds;
    [SerializeField] private GameObject rightBounds;

    public int Id;

    public Bound CurrentLeftBounds;
    public Bound CurrentRightBounds;

    public void SetBound(Bound bound, Enums.Derection derection)
    {
        if (derection == Enums.Derection.Right)
        {

            CurrentRightBounds = bound;
        }
        else
        {
            CurrentLeftBounds = bound;
        }
    }

    public void CreateOther()
    {
        if (CurrentLeftBounds == null)
        {
            CurrentLeftBounds = Instantiate(leftBounds).GetComponent<Bound>();
        }

        if (CurrentRightBounds == null)
        {
            CurrentRightBounds = Instantiate(rightBounds).GetComponent<Bound>();
        }

        CurrentLeftBounds.transform.position = new Vector3(-transform.GetComponent<BoxCollider2D>().size.x / 2 + transform.localPosition.x, 0, 0); CurrentLeftBounds.gameObject.name = "Left";
        CurrentRightBounds.transform.position = new Vector3(transform.GetComponent<BoxCollider2D>().size.x / 2 + transform.localPosition.x, 0, 0); CurrentRightBounds.gameObject.name = "Right";

        CurrentLeftBounds.LeftWay = gameObject;
        CurrentRightBounds.RightWay = gameObject;

        CurrentLeftBounds.CreateNextWay();
        CurrentRightBounds.CreateNextWay();
    }


}
