using UnityEngine;
using System.Collections;

public class GuardController : HumanController
{
    [SerializeField] private SoundSource dieSound;
    [SerializeField] private SoundListener listener;
    [SerializeField] private GameObject alertSign;
    [SerializeField] private float attackRange, reactTime;
    [SerializeField] private LayerMask detectLayer;

    private void Start()
    {
        GameManager.instance.currentStage.RegisterGuard();
    }

    private void Update()
    {
        if( isAlive == false)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,Mathf.Infinity,detectLayer);
        if( hit && hit.collider.TryGetComponent(out HumanController human) && human.isAlive )
        {
            Attack(human);
        }
    }


    public override void Die()
    {
        base.Die();
        dieSound.MakeSound();
        GameManager.instance.currentStage.UnRegisterGuard();
        Destroy(this);
    }
    private void Attack( HumanController human )
    {
        Vector3 targetPos = human.transform.position;
        float offset = attackRange * (targetPos.x > transform.position.x ? -1 : 1);
        float targetX = targetPos.x + offset;
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        animator.SetTrigger("attack");
        human.Die();
    }
    public void Alert()
    {
        alertSign.SetActive(true);
        StartCoroutine(React());
    }
    IEnumerator React()
    {
        yield return new WaitForSeconds(reactTime);
        if((listener.source.x - transform.position.x) * transform.localScale.x < 0)
        {
            Flip();
        }
        alertSign.SetActive(false);
    }

    private void Flip()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
