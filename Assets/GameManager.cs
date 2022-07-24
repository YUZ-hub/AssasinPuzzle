using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StageInfo currentStage;
    public GameEvent pass, gameOver;
    
    [SerializeField]
    private int menuIndex;

    private void Awake()
    {
        if( instance != null )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FoundGold()
    {
        currentStage.goldIsFound = true;
    }
    public void StageClear()
    {
        currentStage.stagePass = true;
        currentStage.StageClear();
    }
    public void GameOver()
    {
        currentStage.StageClear();
    }
    public void NextStage()
    {
        if( currentStage.nextStage != null )
        {
            currentStage = currentStage.nextStage;
            StageStart();
        }
        else
        {
            Debug.Log("There is no next stage");
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(menuIndex);
    }
    public void StageStart()
    {
        currentStage.LoadStage();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
