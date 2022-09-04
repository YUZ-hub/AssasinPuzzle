using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionLadder : MonoBehaviour, TriggerObject
{
    [SerializeField]
    private GameObject nextLadder;

    private GlowingControll glowingControll;
    public bool isTrigger { get; set; }

    private void Start()
    {
        isTrigger = false;
        gameObject.TryGetComponent<GlowingControll>(out glowingControll);
    }

    public void Trigger()
    {
        if (isTrigger)
        {
            return;
        }
        if (glowingControll != null)
        {
            glowingControll.SetGlow(false);
        }
        isTrigger = true;
        if ( nextLadder != null )
        {
            StartCoroutine(OpenNextLadder());
        }
    }
    IEnumerator OpenNextLadder()
    {
        yield return new WaitForSeconds(0.5f);
        nextLadder.SetActive(true);
        if (nextLadder.TryGetComponent<ExtensionLadder>(out ExtensionLadder next))
        {
            next.Trigger();
        }
    }

}
