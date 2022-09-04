using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HumanController
{
    public enum State { idle, stop };
    public State state = State.idle;

    [SerializeField] private GameEvent lose;

    public IEnumerator Free( float delay)
    {
        yield return new WaitForSeconds(delay);
        state = State.idle;
    }

    public override void Die()
    {
        base.Die();
        state = State.stop;
        lose.Raise();
    }
}
