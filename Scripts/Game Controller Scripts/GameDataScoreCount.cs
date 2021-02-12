using UnityEngine;
public class GameDataScoreCount : MonoBehaviour
{
    public static GameDataScoreCount instance;

    public Animator sceneReverseAnimation;

    [HideInInspector]
    public bool levelPassed;

    [HideInInspector]
    public int money;

    public void Start()
    {
        MakeInstance();
        money = PlayerPrefs.GetInt(Tags.TAG_money);
        money = GameManager.instance.moneySingelton;
    }

    public void Update()
    {
        saveMoney();
    }

    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void saveMoney()
    {
        if (GameDataScoreCount.instance.levelPassed == true)
        {
            PlayerPrefs.SetInt(Tags.TAG_money, money);
            GameManager.instance.moneySingelton = money;
            sceneReverseAnimation.Play(Tags.TAG_ReverseSceneAnimation);
        }
    }
}
