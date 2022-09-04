using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour, TriggerObject
{
    [SerializeField]
    private GameEvent foundGold;
    [SerializeField] private GlowingControll glow;
    private Animator animator;

    public bool isTrigger { get; set; }
    private void Start()
    {
        isTrigger = false;
        animator = GetComponent<Animator>();
    }

    public void Trigger()
    {
        if( isTrigger )
        {
            return;
        }
        isTrigger = true;
        animator.SetTrigger("open");
        foundGold.Raise();
        glow.SetGlow(false);
    }
}
