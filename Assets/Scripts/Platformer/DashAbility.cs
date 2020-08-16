using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    IEnumerator cd(HeroMove hm)
    {
        //hm.EnableMove = false;
        yield return new WaitForSeconds(1f);
        //hm.EnableMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<HeroMove>() != null)
        {
            StartCoroutine(cd(collision.transform.GetComponent<HeroMove>()));
            Dasher.Enabled = true;
            Destroy(gameObject);
        }
    }
}
