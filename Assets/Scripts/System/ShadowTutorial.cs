using UnityEngine;
using TMPro;

public class ShadowTutorial : MonoBehaviour
{
    private bool castShadow = false;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;
    private void Update()
    {
        transform.position = playerTransform.position + new Vector3(0, offset, 0);
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!castShadow)
            {
                castShadow = true;
                content.text = "Switch";
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}
