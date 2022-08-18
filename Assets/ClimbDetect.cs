using UnityEngine;

public class ClimbDetect : MonoBehaviour
{
    [SerializeField] private GameObject climbTutorial;
    private void Update()
    {
        if( Input.GetKey(KeyCode.UpArrow))
        {
            climbTutorial.SetActive(false);
            Destroy(this);
        }
    }
}
