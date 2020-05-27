using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class moveTouch : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private void Start()
    {

        _rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        _rigidBody.AddForce(new Vector2(axis, 0)*5);
    }
}
