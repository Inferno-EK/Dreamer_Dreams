using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    
    GameObject bubble, star;
    float ScConst, StarConst;
    void Start()
    {
        bubble = gameObject.transform.GetChild(gameObject.transform.childCount - 2).GetChild(0).gameObject;
        star = gameObject.transform.GetChild(gameObject.transform.childCount - 3).GetChild(0).gameObject;
        StarConst = star.transform.localScale.x;
        ScConst = bubble.transform.localScale.x;
    }


    void Update()
    {
        if (gameObject.transform.GetChild(1).childCount <= 20)
        {
            bubble = gameObject.transform.GetChild(1).GetChild(0).gameObject;
            GameObject gO = Instantiate(bubble, new Vector3(UnityEngine.Random.Range(1f, Screen.width), UnityEngine.Random.Range(1f, Screen.height)), new Quaternion()) as GameObject;
            gO.name = "Bubble";
            float Sc = ScConst * Random.Range(0.25f, 1.5f);
            gO.transform.localScale = new Vector3(Sc, Sc);
            gO.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(1, 1, 1, Random.Range(0.25f, 0.75f));
            gO.transform.SetParent(gameObject.transform.GetChild(1));
        }

        if (gameObject.transform.GetChild(0).childCount <= 50)
        {
            star = gameObject.transform.GetChild(0).GetChild(0).gameObject;
            GameObject gO = Instantiate(star, new Vector3(UnityEngine.Random.Range(1f, Screen.width), UnityEngine.Random.Range(1f, Screen.height)), new Quaternion()) as GameObject;
            gO.name = "Star";
            float Sc = StarConst * Random.Range(0.5f, 1.2f);
            gO.transform.localScale = new Vector3(Sc, Sc);
            gO.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.25f, 0.75f));
            gO.transform.SetParent(gameObject.transform.GetChild(0));
        }

    }
}
