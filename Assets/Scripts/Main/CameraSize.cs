using UnityEngine;

public class CameraSize : MonoBehaviour
{
    Camera thisCamera;
    void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        thisCamera.orthographicSize = 0.5f * Screen.height;
    }
}
