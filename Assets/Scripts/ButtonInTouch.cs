using UnityEngine;

public class ButtonInTouch : MonoBehaviour
{
    static public bool isCanPressed = true;

    [SerializeField] KeyCode keyCodeNum = KeyCode.Alpha1;
    [SerializeField] KeyCode keyCodeKaypad = KeyCode.Alpha1;


    void Update()
    {
        if ((Input.GetKeyDown(keyCodeNum) || Input.GetKeyDown(keyCodeKaypad)) && isCanPressed)
        {
            isCanPressed = false;
            gameObject.transform.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        }
    }
}

