using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public float volumeFrom;

    [HideInInspector]
    public int setGraphics;

    [HideInInspector]
    public int setQuality;

    [HideInInspector]
    public int setBall;

    [HideInInspector]
    public int moneySingelton;

    [HideInInspector]
    public static float firstTimeMusic = 0;

    public void Start()
    {
        makeSingleton();
        volumeFrom = PlayerPrefs.GetFloat(Tags.TAG_volume);
        setGraphics = PlayerPrefs.GetInt(Tags.TAG_graphics);
        setQuality = PlayerPrefs.GetInt(Tags.TAG_quality);
        setBall = PlayerPrefs.GetInt(Tags.TAG_ball);
        moneySingelton = PlayerPrefs.GetInt(Tags.TAG_moneySingelton);
        firstTimeMusic = PlayerPrefs.GetFloat(Tags.TAG_FirstTimeMusic);
        
        if (firstTimeMusic == 0)
        {
            volumeFrom = 0.5f;
        }
    }

    public void Update()
    {
        PlayerPrefs.SetFloat(Tags.TAG_volume, volumeFrom);
        PlayerPrefs.SetInt(Tags.TAG_graphics, setGraphics);
        PlayerPrefs.SetInt(Tags.TAG_quality, setQuality);
        PlayerPrefs.SetInt(Tags.TAG_ball, setBall);
        PlayerPrefs.SetInt(Tags.TAG_moneySingelton, moneySingelton);
        PlayerPrefs.SetFloat(Tags.TAG_FirstTimeMusic, firstTimeMusic);
    }

    public void makeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
