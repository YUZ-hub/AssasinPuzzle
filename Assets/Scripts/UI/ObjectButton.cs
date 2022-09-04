using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider2D))]
public class ObjectButton : MonoBehaviour
{
    [SerializeField]
    private Sound hoverSound, clickSound;

    [SerializeField]
    private Sprite originalSprite, hoverSprite, clickSprite;
    
    [SerializeField]
    private UnityEvent onClick;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        FindObjectOfType<AudioManager>().Play(hoverSound);
        spriteRenderer.sprite = hoverSprite;
    }
    private void OnMouseExit()
    {
        spriteRenderer.sprite = originalSprite;
    }
    private void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play(clickSound);
        spriteRenderer.sprite = clickSprite;
        onClick.Invoke();
    }
}
