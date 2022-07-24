using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Stage", menuName = "StageInfo")]
public class StageInfo : ScriptableObject
{
    public int sceneIndex;

    private int enemyNum;
    public StageInfo nextStage = null;

    public int record;
    public int currentRecord;

    public bool stagePass;
    public bool goldIsFound;
    public bool stageIsOpen;


    public void LoadStage()
    {
        enemyNum = 0;
        record = currentRecord;
        currentRecord = 0;
        stagePass = false;
        goldIsFound = false;
        GameManager.instance.currentStage = this;
        SceneManager.LoadScene(sceneIndex);
    }
    public void StageClear()
    {
        if (stagePass == true)
        {
            currentRecord += 1;
            if (goldIsFound == true)
                currentRecord += 1;
            if (enemyNum == 0)
                currentRecord += 1;
            if (nextStage != null)
                nextStage.stageIsOpen = true;
        }
    }
    public void RegisterGuard()
    {
        enemyNum += 1;
    }
    public void UnRegisterGuard()
    {
        enemyNum -= 1;
    }
}
