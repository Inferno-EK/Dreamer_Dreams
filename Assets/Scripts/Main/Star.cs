using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Delete_Star()
    {
        Destroy(gameObject);
    }

    IEnumerator Deleter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        Delete_Star();
    }

    float MinAlpha, Speed, MaxAlpha, Time;

    void Start()
    {
        StartCoroutine(Deleter());
        MaxAlpha = gameObject.GetComponent<UnityEngine.UI.Image>().color.a;
        MinAlpha = Random.Range(0f, MaxAlpha);
        Time = Random.Range(0.5f, 2.5f);
        Speed = (MaxAlpha - MinAlpha) / Time;
    }



    void FixedUpdate()
    {
        if (Speed > 0)
        {
            if (gameObject.GetComponent<UnityEngine.UI.Image>().color.a > MinAlpha)
            {
                gameObject.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(gameObject.GetComponent<UnityEngine.UI.Image>().color.r, gameObject.GetComponent<UnityEngine.UI.Image>().color.g, gameObject.GetComponent<UnityEngine.UI.Image>().color.b, gameObject.GetComponent<UnityEngine.UI.Image>().color.a + Speed);
            }
            else
            {
                Speed = -Speed;
            }
        }
        else
        {
            if (gameObject.GetComponent<UnityEngine.UI.Image>().color.a < MaxAlpha)
            {
                gameObject.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(gameObject.GetComponent<UnityEngine.UI.Image>().color.r, gameObject.GetComponent<UnityEngine.UI.Image>().color.g, gameObject.GetComponent<UnityEngine.UI.Image>().color.b, gameObject.GetComponent<UnityEngine.UI.Image>().color.a + Speed);
            }
            else
            {
                Speed = -Speed;
            }
        }

    }
}
