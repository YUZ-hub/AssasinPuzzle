using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class StageButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    private StageInfo stageInfo;
    [SerializeField]
    private Sound hoverSound, clickSound;
    [SerializeField]
    private Sprite lockSprite, openSprite, hoverSprite, clickSprite;
    [SerializeField]
    private Image image;
    private Button button;
    private TextMeshProUGUI stageNum;


    private void OnEnable()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate () { stageInfo.LoadStage(); });
        stageNum = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button.interactable = stageInfo.stageIsOpen;
        SetButton();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.IsInteractable())
        {
            FindObjectOfType<AudioManager>().Play(hoverSound);
            image.sprite = hoverSprite;
            stageNum.text = "";
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (button.IsInteractable())
        {
            image.sprite = clickSprite;
            FindObjectOfType<AudioManager>().Play(clickSound);
            stageNum.text = "";
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        SetButton();
    }
    private void SetButton()
    {
        if( stageInfo.stageIsOpen )
        {
            image.sprite = openSprite;
        }
        else
        {
            image.sprite = lockSprite;
        }
        stageNum.text = stageInfo.sceneIndex.ToString();
    }
}
