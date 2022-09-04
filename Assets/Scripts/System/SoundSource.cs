using UnityEngine;

public class SoundSource : MonoBehaviour
{
    [SerializeField] private float range;

    [SerializeField] private Sound sound;

    public void MakeSound()
    {
        AudioManager.instance.Play(sound);
        Vector3 pos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos,range);
        if( colliders == null )
        {
            return;
        }

        foreach( Collider2D collider in colliders )
        {
            if( Vector3.Distance(pos, collider.gameObject.transform.position) < range &&
                collider.gameObject.TryGetComponent(out SoundListener listener) && collider.gameObject != gameObject )
            {
                listener.OnHeard(pos);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
