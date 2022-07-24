using UnityEngine;

public class GlowingControll : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Material defaultMaterial, glowMaterial;
    

    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
        SetGlow(true);
    }

    public void SetGlow(bool set)
    {
        if (set)
            spriteRenderer.material = glowMaterial;
        else
            spriteRenderer.material = defaultMaterial;
    }
}
