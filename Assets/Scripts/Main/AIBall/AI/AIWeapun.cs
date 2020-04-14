using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapun : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.GetComponent<Collider2D>().enabled = false;
        gameObject.transform.parent.rotation *= Quaternion.Euler(0f, 0f, 180f + Random.Range(-90f, 90f));
        if (collision.gameObject.GetComponent<AIBody>() != null)
        {
            try
            {
                int id = collision.transform.parent.gameObject.GetComponent<BallAI>().Id;
                BallAI aI = AIContainer.ais[id];
                if (!aI.isAlife())
                {
                    aI.Killing();
                }
            }
            catch (System.Exception) {}
        }
        gameObject.transform.GetComponent<Collider2D>().enabled = true;

    }
}
