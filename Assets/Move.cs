using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed, climbSpeed;
    [SerializeField] private LayerMask groundLayer, ladderLayer, doorLayer;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private GameEvent moveEvent;

    private Rigidbody2D rb;
    private Collider2D cd;

    private void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb);
        TryGetComponent<Collider2D>(out cd);
    }
    private void Update()
    {
        AddGravity();
        if(controller.isAlive == false || controller.state == PlayerController.State.stop )
        {
            rb.velocity = Vector3.zero;
            return;
        }
        float inputX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        animator.SetBool("isWalking", rb.velocity.x != 0);

        if( transform.localScale.x * inputX < 0)
        {
            Flip();
        }
        if( Input.GetKey(KeyCode.UpArrow) )
        {
            if( cd.IsTouchingLayers(ladderLayer))
            {
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            }
            Collider2D hitDoor = Physics2D.OverlapCircle(transform.position, 1f, doorLayer);
            if ( hitDoor && hitDoor.TryGetComponent(out Door door) && door.isTrigger )
            {
                StartCoroutine(Enter(door));
            }
        }
    }
    IEnumerator Enter(Door door)
    {
        controller.state = PlayerController.State.stop;
        transform.position = new Vector3(door.transform.position.x, transform.position.y, transform.position.z);
        yield return StartCoroutine(EnterAnimation());
        door.Pass();
        gameObject.SetActive(false);
    }
    IEnumerator EnterAnimation()
    {    
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        float fadeTime = 2f;
        float a = 1f;
        while( a>0 )
        {
            a -= Time.deltaTime / fadeTime;
            foreach( SpriteRenderer sprite in sprites)
            {
                Color temp = sprite.color;
                temp.a = a;
                sprite.color = temp;
            }
            yield return null;
        }
    }
    private void AddGravity()
    {
        if(cd.IsTouchingLayers(groundLayer))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            return;
        }
        if(cd.IsTouchingLayers(ladderLayer) )
        {
            rb.velocity = new Vector2(rb.velocity.x, -9.8f);
        }
        else
        {
            Vector2 temp = rb.velocity;
            rb.velocity = new Vector2(temp.x, temp.y - (9.8f * Time.deltaTime));
        }
    }
    private void Flip()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;     
    }
}
