using UnityEngine;

public class SneakDetected : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;

    private void Update()
    {
        transform.position = playerTransform.position + new Vector3(0, offset, 0);
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
