using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public void Delete_bubble()
    {
        Destroy(gameObject);
    }

    IEnumerator Deleter()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        Delete_bubble();
    }

    int xSpeed, ySpeed;
    const int Sc = 3;


    void Start()
    {
        StartCoroutine(Deleter());
        xSpeed = Random.Range(-Sc, Sc);
        ySpeed = Random.Range(-Sc, Sc);
    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + xSpeed, gameObject.transform.position.y + ySpeed);
        if (gameObject.transform.position.x < 0 || gameObject.transform.position.x > Screen.width || gameObject.transform.position.y < 0 || gameObject.transform.position.y > Screen.height) { Delete_bubble(); }
    }



}
