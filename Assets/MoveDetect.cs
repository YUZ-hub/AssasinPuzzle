using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDetect : MonoBehaviour
{
    [SerializeField] private GameObject moveTutorial, interactTutorial;
    void Update()
    {
        if( Input.GetAxisRaw("Horizontal") != 0)
        {
            moveTutorial.SetActive(false);
            interactTutorial.SetActive(true);
            Destroy(this);
        }
    }
}
