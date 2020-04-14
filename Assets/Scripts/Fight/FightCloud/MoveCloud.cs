using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCloud : MonoBehaviour
{
    static public bool MoveLeft = true;
    GameObject PrefabCloud;
    int maxCount;
    List<GameObject> clouds;
    void Start()
    {
        PrefabCloud = gameObject.transform.GetChild(0).gameObject;
        //PrefabCloud.SetActive(false);
        maxCount = Random.Range(10, 20);
        MoveLeft = Random.Range(0, 2) == 1;
        clouds = new List<GameObject>();
        PrefabCloud.transform.localPosition = new Vector3((Screen.width / 2 + gameObject.transform.localScale.x) * (MoveLeft ? 1 : -1),
                                                          Random.Range(0f, gameObject.transform.parent.localScale.y));
        clouds.Add(PrefabCloud);
        clouds[0].SetActive(true);
    }

    void Update()
    {
        for (int i = 0; i < clouds.Count;)
            if (!clouds[i].transform.GetComponent<Cloud>().aLife)
            {
                Destroy(clouds[i]);
                clouds.RemoveAt(i);
            }
            else
                i++;

        if (clouds.Count < maxCount)
        {
            int count = Random.Range(0, maxCount - clouds.Count);
            for (int i = 0; i < count; i++)
            {

                clouds.Add(Instantiate(clouds[0],
                                       new Vector3(),
                                       new Quaternion(),
                                       gameObject.transform));
                clouds[clouds.Count - 1].transform.localPosition = new Vector3((Screen.width / 2 + clouds[0].transform.localScale.y * 200) * (MoveLeft ? 1 : -1),
                                                                                Random.Range(0f, gameObject.transform.localScale.x));
                clouds[clouds.Count - 1].name = "Cloud";
            }
        }


    }
}
