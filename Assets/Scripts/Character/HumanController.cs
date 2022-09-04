using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public bool isAlive { get; private set; } = true;

    [SerializeField] protected Animator animator;

    virtual public void Die()
    {
        animator.SetTrigger("die");
        isAlive = false;
    }
}
