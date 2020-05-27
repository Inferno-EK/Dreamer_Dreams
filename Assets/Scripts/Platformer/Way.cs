using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private GameObject[] bounds = new GameObject[2];
    public int Id;
    public Bound[] CurrentBounds = new Bound[2];

    public void SetBound(Bound bound, Enums.Derection derection)
    {
        if (derection == Enums.Derection.Right)
        {
            CurrentBounds[0] = bound;
        }
        else
        {
            CurrentBounds[1] = bound;
        }
    }

    public void CreateOther()
    {
        if (CurrentBounds[0] == null)
        {
            if (CurrentBounds[1] != null && CurrentBounds[1].Id == bounds[0].GetComponent<Bound>().Id && Random.value <= 0.5f)
            {
                var newObject = Instantiate(bounds[1]);
                CurrentBounds[0] = newObject.GetComponent<Bound>();
            }
            else
            {
                var newObject = Instantiate(bounds[0]);
                CurrentBounds[0] = newObject.GetComponent<Bound>();
            }
        }

        if (CurrentBounds[1] == null)
        {
            if (CurrentBounds[0] != null && CurrentBounds[0].Id == bounds[0].GetComponent<Bound>().Id && Random.value <= 0.5f)
            {
                var newObject = Instantiate(bounds[1]);
                CurrentBounds[1] = newObject.GetComponent<Bound>();
            }
            else
            {
                var newObject = Instantiate(bounds[0]);
                CurrentBounds[1] = newObject.GetComponent<Bound>();
            }
        }

        CurrentBounds[0].transform.position = new Vector3(transform.localScale.x / 2 + transform.localPosition.x, 0, 0);
        CurrentBounds[1].transform.position = new Vector3(-transform.localScale.x / 2 + transform.localPosition.x, 0, 0);
       
        CurrentBounds[0].LeftWay = gameObject;
        CurrentBounds[1].RightWay = gameObject;

        CurrentBounds[0].CreateNextWay();
        CurrentBounds[1].CreateNextWay();
    }


}
