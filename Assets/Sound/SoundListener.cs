using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundListener : MonoBehaviour
{
    [SerializeField] private UnityEvent onHeard;

    public Vector3 source { get; private set; }

    public void OnHeard(Vector3 sourcePosition)
    {
        source = sourcePosition;
        onHeard.Invoke();
    }
}
