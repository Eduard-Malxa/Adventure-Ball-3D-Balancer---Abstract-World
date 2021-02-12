using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OnTriggerBallScript : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;

    public AudioSource[] Sound;

    public AudioClip[] SoundClip;

    public AudioSource MainMusic;

    [HideInInspector]
    public static bool EndKey;

    public AdMob adMob;

    public GameObject ButtonCanvas;

    public Canvas animCanvas;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        EndKey = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Cloud)
        {
            GameDataScoreCount.instance.money++;
            Sound[0].PlayOneShot(SoundClip[0]);
            StartCoroutine(GameobjectSetActive(false, 0.5f, other));
        }

        if (other.gameObject.tag == Tags.TAG_LevelPassed)
        {
            GameDataScoreCount.instance.levelPassed = true;
            Sound[2].PlayOneShot(SoundClip[2]);
            if (SceneManager.GetActiveScene().buildIndex == 20)
            {
                StartCoroutine(lastStagePass());
                PlayerPrefs.SetInt(Tags.TAG_levelAt, nextSceneLoad);
                StartCoroutine(AdMob_Cor());
                ButtonCanvas.SetActive(false);
                animCanvas.sortingOrder = 0;
                MainMusic.Stop();
            }
            else
            {
                //Move to next level
                StartCoroutine(levelPassCorutine());
                StartCoroutine(AdMob_Cor());
                ButtonCanvas.SetActive(false);
                animCanvas.sortingOrder = 0;
                MainMusic.Stop();
                //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt(Tags.TAG_levelAt))
                {
                    PlayerPrefs.SetInt(Tags.TAG_levelAt, nextSceneLoad);
                }
            }
        }

        if (other.gameObject.tag == Tags.TAG_CheckpointVoice)

        {
            Sound[1].PlayOneShot(SoundClip[1]);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == Tags.TAG_CheckpointVoice_1)

        {
            Sound[1].PlayOneShot(SoundClip[1]);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == Tags.TAG_CheckpointVoice_2)

        {
            Sound[1].PlayOneShot(SoundClip[1]);
            other.gameObject.SetActive(false);
        }


        if (other.gameObject.tag == Tags.TAG_BigKey)
        {
            Sound[3].PlayOneShot(SoundClip[3]);
            StartCoroutine(GameobjectSetActive(false, 10f, other));
        }

        if (other.gameObject.tag == Tags.TAG_NormalKey)
        {
            Sound[3].PlayOneShot(SoundClip[3]);
            StartCoroutine(GameobjectSetActive(false, 10f, other));
        }

        if (other.gameObject.tag == Tags.TAG_RealBigiKey)
        {
            Sound[3].PlayOneShot(SoundClip[3]);
            StartCoroutine(GameobjectSetActive(false, 10f, other));
        }

        if (other.gameObject.tag == Tags.TAG_EndRoad)
        {
            Sound[4].PlayOneShot(SoundClip[4]);
            StartCoroutine(GameobjectSetActive(false, 4f, other));
            EndKey = true;
        }

        if (other.gameObject.tag == Tags.TAG_Labirint)
        {
            CameraFollow.LabrintMode = true;
        }

        if (other.gameObject.tag == Tags.TAG_FallBall)
        {
            FallBall.closeCameraButtonForFallAnyObjectMode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Labirint)
        {
            CameraFollow.LabrintMode = false;
        }

        if (other.gameObject.tag == Tags.TAG_FallBall)
        {
            FallBall.closeCameraButtonForFallAnyObjectMode = false;
        }
    }


        public IEnumerator levelPassCorutine()
    {
        yield return new WaitForSeconds(4.2f);
        SceneManager.LoadScene(nextSceneLoad);
    }

    IEnumerator AdMob_Cor()
    {
        yield return new WaitForSeconds(3.2f);
        adMob.Level_Finished_AD();
    }

    internal IEnumerator lastStagePass()
    {
        yield return new WaitForSeconds(4.2f);
        SceneManager.LoadScene(Tags.TAG_MainMenu);
    }

    IEnumerator GameobjectSetActive( bool setActive, float time, Collider other)
    {
        yield return new WaitForSeconds(time);
        other.gameObject.SetActive(setActive);
    }
}
