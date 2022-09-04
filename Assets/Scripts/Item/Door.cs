using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, TriggerObject
{
    [SerializeField]
    private GameEvent pass;
    [SerializeField]
    private Animator animator;
    public bool isTrigger { get; set; }
    [SerializeField]
    private GlowingControll glowingControll;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        gameObject.TryGetComponent<GlowingControll>(out glowingControll);
        isTrigger = false;
    }

    public void Trigger()
    {
        if (isTrigger)
        {
            return;
        }
        isTrigger = true;
        if( glowingControll != null )
            glowingControll.SetGlow(false);
        animator.SetTrigger("openDoor");
    }
    public void Pass()
    {
        pass.Raise();
    }
}
