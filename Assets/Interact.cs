using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer, triggerLayer;
    [SerializeField] private Transform interactPoint;
    [SerializeField] private float interactRange, interval;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private SoundSource knifeHitSound;

    void Update()
    {
        if( controller.isAlive == false || controller.state == PlayerController.State.stop )
        {
            return;
        }
        if( Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("stab");
            controller.state = PlayerController.State.stop;
            StartCoroutine(controller.Free(interval));

            Collider2D hitEnemy = Physics2D.OverlapCircle(interactPoint.position, interactRange, enemyLayer);
            Collider2D hitTrigger = Physics2D.OverlapCircle(interactPoint.position, interactRange, triggerLayer);
            
            if( hitEnemy && hitEnemy.TryGetComponent(out HumanController humanController) && humanController.isAlive )
            {
                Attack(humanController);
            }
            
            if( hitTrigger && hitTrigger.TryGetComponent(out TriggerObject trigger))
            {
                Trigger(trigger);
            }
        }
    }
    private void Attack(HumanController human)
    {
         human.Die();       
    }
    private void Trigger(TriggerObject trigger)
    {
        knifeHitSound.MakeSound();
        trigger.Trigger();
    }

}
