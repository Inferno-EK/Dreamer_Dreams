using System.Collections;
using UnityEngine;
using System.Threading;
public class Writer : MonoBehaviour
{
    [SerializeField] public GameObject CurrentGameObject;
    [SerializeField] public UnityEngine.UI.Text CurrentTextContainer;
    [SerializeField] public UnityEngine.UI.Text NameContainer;
    [SerializeField] private float SimbolsPerSecond;

    public int isWriting = 0;

    public void TurnOn()
    {
        CurrentGameObject.SetActive(true);
    }

    public void TurnOff()
    {
        CurrentGameObject.SetActive(false);
    }

    IEnumerator writing(string text, UnityEngine.UI.Text container)
    {
        isWriting++;
        float stopTime = 1 / SimbolsPerSecond;
        container.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(stopTime);
            container.text += text[i];
        }
        isWriting--;
    }

    public IEnumerator WriteText(Pair<string, string> text, bool y)
    {
        Coroutine a = StartCoroutine(writing(text.Second, CurrentTextContainer));
        Coroutine b = StartCoroutine(writing(text.First, NameContainer));
        if (y)
        {
            yield return a;
            yield return b;
        }
    }
}
