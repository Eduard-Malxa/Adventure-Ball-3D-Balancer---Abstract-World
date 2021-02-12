using UnityEngine;
public class GraphicControllerFromMainMenu : MonoBehaviour
{
    public GameObject gameObjectLMH;

    public int value;

    public void Start()
    {
        if (GameManager.instance.setGraphics == value)
        {
            gameObjectLMH.SetActive(true);
        }
        else
        {
            gameObjectLMH.SetActive(false);
        }
    }
}
