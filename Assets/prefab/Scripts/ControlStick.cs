using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStick : MonoBehaviour, TriggerObject
{
    [SerializeField]
    private GameEvent target;
    private GlowingControll glowingControll;
    public bool isTrigger { get; set; }
    private void Start()
    {
        gameObject.TryGetComponent<GlowingControll>(out glowingControll);
    }

    public void Trigger()
    {
        if (isTrigger)
        {
            return;
        }
        if (glowingControll != null)
            glowingControll.SetGlow(false);
        isTrigger = true;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        target.Raise();
    }
}
