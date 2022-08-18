using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(fadeTime);
        gameObject.SetActive(false);
    }
}
