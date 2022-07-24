using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private Sound hoverSound, clickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play(clickSound);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.Play(hoverSound);
    }

}
