using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public AudioSource Click;

    public AudioClip ClickClip;

    public GameObject mainMenu;

    public GameObject allLevelsMenu;

    public GameObject ballSkinMenu;

    public GameObject settings;

    public GameObject SettingButton;

    public Animator sceneReverseAnimation;

    private void Awake()
    {
        allLevelsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ballSkinMenu.SetActive(false);
        settings.SetActive(false);
        StartCoroutine(SettingsButtonSetActiv());
    }

    public void openAllLevelsMenu()
    {
        Click.PlayOneShot(ClickClip);
        allLevelsMenu.SetActive(true);
        mainMenu.SetActive(false);
        ballSkinMenu.SetActive(false);
        settings.SetActive(false);
    }

    public void openMainMenu()
    {
        Click.PlayOneShot(ClickClip);
        allLevelsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ballSkinMenu.SetActive(false);
        settings.SetActive(false);
    }

    public void openBallSkinMenu()
    {
        Click.PlayOneShot(ClickClip);
        allLevelsMenu.SetActive(false);
        mainMenu.SetActive(false);
        ballSkinMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void openSettingsMenu()
    {
        Click.PlayOneShot(ClickClip);
        allLevelsMenu.SetActive(false);
        mainMenu.SetActive(false);
        ballSkinMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void loadCurrentLevel(string level)
    {
        Click.PlayOneShot(ClickClip);
        sceneReverseAnimation.Play(Tags.TAG_ReverseSceneAnimation);
        StartCoroutine(waitForRevesreAnimation(level));
    }

    internal IEnumerator waitForRevesreAnimation(string level)
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(level);
    }

    IEnumerator SettingsButtonSetActiv()
    {
        yield return new WaitForSeconds(0.1f);
        SettingButton.SetActive(true);
    }
}
