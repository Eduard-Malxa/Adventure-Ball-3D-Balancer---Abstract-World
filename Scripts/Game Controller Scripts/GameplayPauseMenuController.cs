using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameplayPauseMenuController : MonoBehaviour
{
    public GameObject buttonCanvas;

    public GameObject pausePanel;

    public GameObject pauseButton;

    public Animator sceneReverseAnimation;

    public GameObject ball;

    [HideInInspector]
    public bool pauseBool;

    [HideInInspector]
    public bool mainMenuBool;

    [HideInInspector]
    public bool resumeGameBool;

    public void Start()
    {
        pauseBool = false;
    }

    public void pauseMenu()
    {
        pauseBool = !pauseBool;
        if (!pauseBool)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            buttonCanvas.SetActive(true);
        }
        else if (pauseBool)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            buttonCanvas.SetActive(false);
        }
    }

    public void mainMenu()
    {
        mainMenuBool = true;
        if (mainMenuBool == true)
        {
            StartCoroutine(waitForRevesreAnimation(false));
            Time.timeScale = 1f;
            sceneReverseAnimation.Play(Tags.TAG_ReverseSceneAnimation);
        }
    }

    public void restartGame()
    {
        StartCoroutine(waitForRevesreAnimation(true));
        Time.timeScale = 1f;
        lifesScript.lifesCount = 5;
        sceneReverseAnimation.Play(Tags.TAG_ReverseSceneAnimation);
    }

    public IEnumerator waitForRevesreAnimation(bool restartGame)
    {
        yield return new WaitForSeconds(1.3f);

        if (restartGame == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            saveCheckpoint.lastPosition = lifesScript.curPos;
        }
        else
        {
            SceneManager.LoadScene(Tags.TAG_MainMenu);
            saveCheckpoint.lastPosition = lifesScript.curPos;
        }
    }
}
