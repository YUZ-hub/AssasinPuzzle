using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialUI;
    [SerializeField] private Tutorial [] tutorials;
    [SerializeField] private float fadeTime;
    private bool stop = false;

    IEnumerator Start()
    {
        foreach ( Tutorial tutorial in tutorials)
        {
            if( stop)
            {
                break;
            }
            Show(tutorial);
            yield return new WaitForSeconds(fadeTime);
        }
        Hide();
    }

    public void Show(Tutorial tutorial)
    {
        if( tutorial.played )
        {
            return;
        }
        tutorialUI.text = tutorial.content;
        tutorial.played = true;
    }
    public void Hide()
    {
        tutorialUI.text = string.Empty;
    }
    public void StopTutorial()
    {
        stop = true;
        Hide();
        foreach( Tutorial tutorial in tutorials)
        {
            tutorial.played = true;
        }
    }
}
