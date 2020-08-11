using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    const float Offset = 0.05f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 newPos = transform.position;
        if (SpiritDash.MoveDown) newPos.y += Offset;
        if (SpiritDash.MoveUp) newPos.y -= Offset;
        if (SpiritDash.MoveLeft) newPos.x += Offset;
        if (SpiritDash.MoveRight) newPos.x -= Offset;

        transform.position = newPos;
    }
}
