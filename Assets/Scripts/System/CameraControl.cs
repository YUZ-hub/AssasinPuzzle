using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float offset, smoothSpeed;

    private bool isDraging = false;
    private Vector3 origin;
    private Vector3 difference;

    private void Start()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = new Vector3(player.position.x, player.position.y + offset, transform.position.z);
    }

    private void FixedUpdate()
    {
        if( Input.GetMouseButton(0) )
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if( isDraging == false )
            {
                isDraging = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            isDraging = false;
        }

        if ( isDraging )
        {
            Camera.main.transform.position = origin - difference;
        }
        else
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + offset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothSpeed);
        }  
    }
}
