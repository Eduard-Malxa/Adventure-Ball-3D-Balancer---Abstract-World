using UnityEngine;
public class GraphicsController : MonoBehaviour
{
    public TMPro.TMP_Dropdown mP_Dropdown;

    public void Start()
    {
        mP_Dropdown.value = GameManager.instance.setGraphics;
    }

    public void SetQuality(int quality)
    {
        GameManager.instance.setGraphics = quality;
    }

   
}
