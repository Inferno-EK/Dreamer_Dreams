using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Bound : MonoBehaviour
{
    public GameObject RightWay;
    public GameObject LeftWay;
    public int Id;

    [SerializeField] private GameObject[] _ways; 
    [SerializeField] private BoundOnDerection _leftBound;
    [SerializeField] private BoundOnDerection _rightBound;

    public void DestroyWay(Derection derection)
    {
        if (derection == Derection.Right) Destroy(RightWay);
        else Destroy(LeftWay);

        Destroy(gameObject);
    }

    public void CreateNewWay()
    {
        if (_leftBound.isOn)
        {
            RightWay.GetComponent<Way>().CreateOther();
        }

        if (_rightBound.isOn)
        {
            LeftWay.GetComponent<Way>().CreateOther();
        }
    }

    public void DeleteOldWay()
    {
        if (!(_leftBound.isOn ^ _rightBound.isOn)) return;

        if (_leftBound.isOn)
        {
            RightWay.GetComponent<Way>().CurrentBounds[0].DestroyWay(Derection.Right);
        }
        if (_rightBound.isOn)
        {
            LeftWay.GetComponent<Way>().CurrentBounds[1].DestroyWay(Derection.Left);
        }
    }


    public void CreateNextWay()
    {
        int leftIndex = -1;
        int rightIndex = -1;
        int idLeft = 0;
        int idRight = 0;

        if (RightWay != null)
        {
            idRight = RightWay.transform.GetComponent<Way>().Id;
        }

        if (LeftWay != null)
        {
            idLeft = LeftWay.transform.GetComponent<Way>().Id;
        }

        for (int i = 0; i < _ways.Length; i++)
        {
            var wayI = _ways[i].transform.GetComponent<Way>().Id;
            if (wayI == idRight)
            {
                rightIndex = i;
            }

            if (wayI == idLeft)
            {
                leftIndex = i;
            }
        }


        if (leftIndex == -1)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _ways.Length);
            } while (newIndex == rightIndex);
            leftIndex = newIndex;
            var newWay = Instantiate(_ways[newIndex], new Vector3(-_ways[newIndex].transform.localScale.x/2 + transform.position.x, 0 , 0), Quaternion.identity);
            newWay.GetComponent<Way>().CurrentBounds[0] = this;
            LeftWay = newWay;
        }

        if (rightIndex == -1)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _ways.Length);
            } while (newIndex == leftIndex);
            var newWay = Instantiate(_ways[newIndex], new Vector3(_ways[newIndex].transform.localScale.x / 2 + transform.position.x, 0, 0), Quaternion.identity);
            newWay.GetComponent<Way>().CurrentBounds[1] = this;
            RightWay = newWay;
        }
    }

}

