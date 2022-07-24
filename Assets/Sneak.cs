using System.Collections;
using UnityEngine;

public class Sneak : MonoBehaviour
{
    private bool isUsed = false;
    [SerializeField] private float fadeTime;
    [SerializeField] Animator animator;
    [Range(0f, 1f)] [SerializeField] private float opacity;
    [Range(1,32)][SerializeField] private int playerLayer, sneakLayer;


    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.A) && isUsed == false )
        {
            Hide();
        }
        if( Input.GetKeyDown(KeyCode.Z) && isUsed )
        {
            ExitSneak();
        }
    }
    private void Hide()
    {
        if( isUsed)
        {
            return;
        }
        isUsed = true;
        gameObject.layer = sneakLayer;
        animator.SetTrigger("skill");
        StartCoroutine(Fade());
    }
    private void ExitSneak()
    {
        gameObject.layer = playerLayer;
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach( SpriteRenderer sprite in sprites)
        {
            Color temp = sprite.color;
            temp.a = 1;
            sprite.color = temp;
        }
        Destroy(this);
    }
    IEnumerator Fade()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        float a = 1f;
        while ( a > opacity)
        {
            a -= (1 - opacity) * Time.deltaTime / fadeTime; 
            foreach( SpriteRenderer sprite in sprites)
            {
                Color temp = sprite.color;
                temp.a = a;
                sprite.color = temp;
            }
            yield return null;
        }

    }
}
