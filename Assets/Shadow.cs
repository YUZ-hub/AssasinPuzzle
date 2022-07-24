using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private bool isUsed = false;
    private GameObject clone;

    [SerializeField] private GameObject shadowPrefab;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.S) )
        {
            if( isUsed )
            {
                ShadowSwitch();
            }
            else
            {
                ShadowCast();
            }
        }
    }
    private void ShadowCast()
    {
        isUsed = true;
        animator.SetTrigger("skill");
        clone = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
    }
    private void ShadowSwitch()
    {
        transform.position = clone.transform.position;
        Destroy(clone);
        Destroy(this);
    }
}
