using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class lifesScript : MonoBehaviour
{
    public Image[] life;

    public Animator checkpointAnimation;

    public GameObject ball;

    public GameObject gameOverMenu;

    public GameObject buttonCanvas;

    [HideInInspector]
    public static int lifesCount = 5;

    [HideInInspector]
    public static Vector3 curPos = new Vector3(-3, -6, 10);

    [HideInInspector]
    public bool isAnimating;

    private void Start()
    {
        isAnimating = true;
        lifesCount = 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            lifesCount--;
            if (lifesCount == 4)
            {
                life[0].gameObject.SetActive(false);
            }
            if (lifesCount == 3)
            {
                life[1].gameObject.SetActive(false);
            }
            if (lifesCount == 2)
            {
                life[2].gameObject.SetActive(false);
            }
            if (lifesCount == 1)
            {
                life[3].gameObject.SetActive(false);
            }
            if (lifesCount == 0)
            {
                life[4].gameObject.SetActive(false);
            }
            if (lifesCount < 0)
            {
                isAnimating = false;
                Time.timeScale = 0f;
                buttonCanvas.gameObject.SetActive(false);
                gameOverMenu.gameObject.SetActive(true);
                lifesCount = 5;
            }
            checkpointAnimation.Play(Tags.TAG_checkpontAnimation);
            StartCoroutine(checkpointCor());
        }

        if (other.gameObject.tag == Tags.TAG_objectAny)
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            if (isAnimating)
            {
                checkpointAnimation.Play(Tags.TAG_checkpointOutAnimtion);
            }
        }
    }

    public IEnumerator checkpointCor()
    {
        yield return new WaitForSeconds(0.80f);
        if (isAnimating)
        { 
            // can be 

            //if (saveCheckpoint.lastPosition == new Vector3(0, 0, 0))
            //{
            //    ball.transform.position = curPos;
            //}
            //else
            //{
            //    ball.transform.position = saveCheckpoint.lastPosition;
            //}

            ball.transform.position = saveCheckpoint.lastPosition;
        }
    }
}
