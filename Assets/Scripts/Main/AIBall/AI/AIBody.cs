using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBody : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.GetComponent<Collider2D>().enabled = false;
        gameObject.transform.parent.rotation *= Quaternion.Euler(0f, 0f, 180f + Random.Range(-90f, 90f));
        if (collision.gameObject.GetComponent<AIWeapun>() != null)
        {
            gameObject.GetComponentInParent<BallAI>().Damage();
        }
        gameObject.transform.GetComponent<Collider2D>().enabled = true;

    }
}
