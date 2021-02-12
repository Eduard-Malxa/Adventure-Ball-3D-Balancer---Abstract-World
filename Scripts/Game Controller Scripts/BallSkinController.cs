using UnityEngine;
using UnityEngine.UI;
public class BallSkinController : MonoBehaviour
{
    public AudioSource Click;

    public AudioClip ClickClip;

    public AudioClip SuccessBuy;

    public TMPro.TMP_Text[] Text;

    public Button[] Button;

    public Button[] BuyButton;

    public Material[] materials;

    public MeshRenderer meshRendererBall;

    public Sprite choosenBallSprite;

    public Sprite selectBallSprite;

    public Text moneyText;

    public Text moneyTextMainMenu;

    [HideInInspector]
    public int BuyFireBall = 0;

    [HideInInspector]
    public int BuyDirtiBall = 0;

    [HideInInspector]
    public int BuyRustBall = 0;

    [HideInInspector]
    public int BuyLavaBall = 0;

    [HideInInspector]
    public int BuyStoneBall = 0;

    [HideInInspector]
    public int BuyRedBall = 0;

    [HideInInspector]
    public int BuyYellowBall = 0;

    [HideInInspector]
    public int BuyChocoBall = 0;

    [HideInInspector]
    public int BuyMetalBall = 0;

    [HideInInspector]
    public int BuyPurpuleBall = 0;

    [HideInInspector]
    public int BuyGreenBall = 0;

    public void Start()
    {
        BuyFireBall = PlayerPrefs.GetInt(Tags.TAG_BuyFireBall);
        BuyDirtiBall = PlayerPrefs.GetInt(Tags.TAG_BuyDirtiBall);
        BuyRustBall = PlayerPrefs.GetInt(Tags.TAG_BuyRustBall);
        BuyLavaBall = PlayerPrefs.GetInt(Tags.TAG_BuyLavaBall);
        BuyStoneBall = PlayerPrefs.GetInt(Tags.TAG_BuyStoneBall);
        BuyRedBall = PlayerPrefs.GetInt(Tags.TAG_BuyRedBall);
        BuyYellowBall = PlayerPrefs.GetInt(Tags.TAG_BuyYellowBall);
        BuyChocoBall = PlayerPrefs.GetInt(Tags.TAG_BuyChocoBall);
        BuyMetalBall = PlayerPrefs.GetInt(Tags.TAG_BuyMetalBall);
        BuyPurpuleBall = PlayerPrefs.GetInt(Tags.TAG_BuyPurpuleBall);
        BuyGreenBall = PlayerPrefs.GetInt(Tags.TAG_BuyGreenBall);
    }

    public void Update()
    {

        for (int i = 0; i < 14; i++)
        {
            BallSelector_ButtonChanger(i);
        }

        moneyText.text = "" + GameManager.instance.moneySingelton;
        moneyTextMainMenu.text = "" + GameManager.instance.moneySingelton;

        buySkinBallSaver_FireBall(0, 2, "FireBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyFireBall, BuyFireBall);

        buySkinBallSaver_DirtiBall(1, 4, "DirtiBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyDirtiBall, BuyDirtiBall);

        buySkinBallSaver_RustBall(2, 5, "RustBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyRustBall, BuyRustBall);

        buySkinBallSaver_LavaBall(3, 6, "LavaBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyLavaBall, BuyLavaBall);

        buySkinBallSaver_StoneBall(4, 7, "StoneBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyStoneBall, BuyStoneBall);

        buySkinBallSaver_RedBall(5, 8, "RedBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyRedBall, BuyRedBall);

        buySkinBallSaver_YellowBall(6, 9, "YellowBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyYellowBall, BuyYellowBall);

        buySkinBallSaver_ChocoBall(7, 10, "ChocoBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyChocoBall, BuyChocoBall);

        buySkinBallSaver_MetalBall(8, 11, "MetalBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyMetalBall, BuyMetalBall);

        buySkinBallSaver_PurpuleBall(9, 12, "PurpuleBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyPurpuleBall, BuyPurpuleBall);

        buySkinBallSaver_GreenBall(10, 13, "GreenBall");
        PlayerPrefs.SetInt(Tags.TAG_BuyGreenBall, BuyGreenBall);
    }

    public void selectSkin(int num)
    {
        Click.PlayOneShot(ClickClip);
        GameManager.instance.setBall = num;
        meshRendererBall.sharedMaterial = materials[GameManager.instance.setBall];
    }

    public void BallSelector_ButtonChanger(int num)
    {
        if (GameManager.instance.setBall == num)
        {
            Text[num].text = "";
            Button[num].image.sprite = choosenBallSprite;
        }
        else
        {
            Text[num].text = "Select";
            Button[num].image.sprite = selectBallSprite;
        }
    }

    public void buySkin_FireBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyFireBall += 1;
        }
    }
    public void buySkinBallSaver_FireBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyFireBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyFireBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_DirtiBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyDirtiBall += 1;
        }
    }
    public void buySkinBallSaver_DirtiBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyDirtiBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyDirtiBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_RustBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyRustBall += 1;
        }
    }
    public void buySkinBallSaver_RustBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyRustBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyRustBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_LavaBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyLavaBall += 1;
        }
    }
    public void buySkinBallSaver_LavaBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyLavaBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyLavaBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_StoneBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyStoneBall += 1;
        }
    }
    public void buySkinBallSaver_StoneBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyStoneBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyStoneBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_RedBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyRedBall += 1;
        }
    }
    public void buySkinBallSaver_RedBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyRedBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyRedBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_YellowBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyYellowBall += 1;
        }
    }
    public void buySkinBallSaver_YellowBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyYellowBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyYellowBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_ChocoBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyChocoBall += 1;
        }
    }
    public void buySkinBallSaver_ChocoBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyChocoBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyChocoBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_MetalBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyMetalBall += 1;
        }
    }
    public void buySkinBallSaver_MetalBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyMetalBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyMetalBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_PurpuleBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyPurpuleBall += 1;
        }
    }
    public void buySkinBallSaver_PurpuleBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyPurpuleBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyPurpuleBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }

    public void buySkin_GreenBall(int money)
    {
        if (GameManager.instance.moneySingelton >= money)
        {
            Click.PlayOneShot(SuccessBuy);
            GameManager.instance.moneySingelton -= money;
            zeroController();
            BuyGreenBall += 1;
        }
    }
    public void buySkinBallSaver_GreenBall(int Buynum, int ButtonNum, string Name)
    {
        if (BuyGreenBall == 0)
        {
            BuyButton[Buynum].gameObject.SetActive(true);
            Button[ButtonNum].gameObject.SetActive(false);
        }
        else if (BuyGreenBall >= 1)
        {
            BuyButton[Buynum].gameObject.SetActive(false);
            Button[ButtonNum].gameObject.SetActive(true);
        }
    }






    public void removeMoney()
    {
        GameManager.instance.moneySingelton -= 500;
        zeroController();
    }

    public void giveMoney()
    {
        GameManager.instance.moneySingelton += 500;
    }

    public void zeroController()
    {
        if (GameManager.instance.moneySingelton < 0)
        {
            GameManager.instance.moneySingelton = 0;
        }
    }
}

