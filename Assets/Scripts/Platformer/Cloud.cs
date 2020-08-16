using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Enums.AllDerection derection = Enums.AllDerection.Up;

    private void OnTriggerStay2D(Collider2D collision)
    {

        collision.attachedRigidbody.velocity = Vector3.zero;
        collision.attachedRigidbody.angularVelocity = 0;
        collision.attachedRigidbody.AddForce(Enums.VectorDerections.VectorDerection[(int)derection] * 400);
    }
}
