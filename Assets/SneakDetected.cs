using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakDetected : MonoBehaviour
{
    [SerializeField] private GameEvent SneakEvent;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SneakEvent.Raise();
        }
    }
}
