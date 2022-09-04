using UnityEngine;
using TMPro;
using System.Collections;

public class RecordPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;
    [SerializeField] private GameObject newRecordPanel;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private TextMeshProUGUI message;
    private void OnEnable()
    {
        StartCoroutine(SetPanel());
    }

    IEnumerator SetPanel()
    {
        StageInfo stageInfo = GameManager.instance.currentStage;
        yield return new WaitForSeconds(0.5f);
        for ( int i = 0; i < stageInfo.currentRecord; i += 1 )
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        if( stageInfo.currentRecord > stageInfo.record )
        {
            newRecordPanel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        buttonPanel.SetActive(true);
        
    }
    public void SetPassMessage()
    {
        message.text = "Stage Clear";
    }
    public void SetLoseMessage()
    {
        message.text = "You Lose";
    }
}
