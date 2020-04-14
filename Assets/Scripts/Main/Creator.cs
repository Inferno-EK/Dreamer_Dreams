using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour
{
    UnityEngine.UI.Text saving;
    IEnumerator Save()
    {
        if (!Inside)
        {
            Inside = true;
            yield return new WaitForSeconds(2f);
            for (int i = 100; i != 0; i--)
            {
                yield return new WaitForSeconds(0.01f);
                saving.color = new Color(1f, 1f, 1f, (float)(i / 100));
            }
            Inside = false;
        }
        else
            yield return new WaitForSeconds(0f);
        
    }

    bool Inside = false;
    void Unsave()
    {
        if (!Inside)
        {
            saving.color = new Color(1f, 1f, 1f, 1f);
            StartCoroutine(Save());
        }
    }

    GameObject bubble, star;
    float ScConst, StarConst;
    void Start()
    {
        bubble = gameObject.transform.GetChild(gameObject.transform.childCount - 3).GetChild(0).gameObject;
        star = gameObject.transform.GetChild(gameObject.transform.childCount - 4).GetChild(0).gameObject;
        StarConst = star.transform.localScale.x;
        ScConst = bubble.transform.localScale.x;

        saving = gameObject.transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
        gameObject.transform.GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Unsave());
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
