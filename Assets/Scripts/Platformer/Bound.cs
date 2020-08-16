using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Bound : MonoBehaviour
{
    public GameObject RightWay;
    public GameObject LeftWay;
    public int Id;

    [SerializeField] private GameObject[] _rightWays;
    [SerializeField] private GameObject[] _leftWays;

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
            LeftWay.GetComponent<Way>().CurrentRightBounds.DestroyWay(Derection.Left);
        }
        if (_rightBound.isOn)
        {
            RightWay.GetComponent<Way>().CurrentLeftBounds.DestroyWay(Derection.Right);
        }
        
    }


    public void CreateNextWay()
    {
        if (_rightWays.Length == 0 || _leftWays.Length == 0) return;
        int leftIndex = -1;
        int rightIndex = -1;
        int idLeft = int.MinValue;
        int idRight = int.MinValue;

        if (RightWay != null)
        {
            idRight = RightWay.transform.GetComponent<Way>().Id;
        }

        if (LeftWay != null)
        {
            idLeft = LeftWay.transform.GetComponent<Way>().Id;
        }

        for (int i = 0; i < _leftWays.Length; i++)
        {
            var wayI = _leftWays[i].transform.GetComponent<Way>().Id;
            

            if (wayI == idLeft)
            {
                leftIndex = i;
            }
        }

        for (int i = 0; i < _rightWays.Length; i++)
        {
            var wayI = _rightWays[i].transform.GetComponent<Way>().Id;

            if (wayI == idRight)
            {
                rightIndex = i;
            }

        }
        

        if (leftIndex == int.MinValue || LeftWay == null)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _leftWays.Length);
            } while (newIndex == leftIndex);
            leftIndex = newIndex;
            var newWay = Instantiate(_leftWays[newIndex], new Vector3(_leftWays[newIndex].transform.GetComponent<BoxCollider2D>().size.x / 2 + transform.position.x, 0 , 0), Quaternion.identity);
            newWay.GetComponent<Way>().CurrentLeftBounds = this;
            LeftWay = newWay;
        }

        if (rightIndex == int.MinValue || RightWay == null)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _rightWays.Length);
            } while (newIndex == rightIndex);
            var newWay = Instantiate(_rightWays[newIndex], new Vector3(-_rightWays[newIndex].transform.GetComponent<BoxCollider2D>().size.x / 2 + transform.position.x, 0, 0), Quaternion.identity);
            newWay.GetComponent<Way>().CurrentRightBounds = this;
            RightWay = newWay;
        }
    }

}

