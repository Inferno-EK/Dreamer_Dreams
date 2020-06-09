using UnityEngine;

[ExecuteInEditMode]
public class CameraSize : MonoBehaviour
{
    Camera _thisCamera;
    Transform _transform;

    void Start()
    {
        _thisCamera = GetComponent<Camera>();
        _transform = transform;
    }

    void Update()
    {
        _thisCamera.orthographicSize = 0.5f * Screen.height;
        _transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f);

    }
}
