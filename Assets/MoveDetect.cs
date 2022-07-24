using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDetect : MonoBehaviour
{
    [SerializeField] private GameEvent moveEvent;
    void Update()
    {
        if( Input.GetAxisRaw("Horizontal") != 0)
        {
            moveEvent.Raise();
        }
    }
}
