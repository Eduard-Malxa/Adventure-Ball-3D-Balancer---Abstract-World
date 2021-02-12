using UnityEngine;
public class QualityController : MonoBehaviour
{
    public TMPro.TMP_Dropdown mP_DropdownResolution;

    public void Start()
    {
        mP_DropdownResolution.value = GameManager.instance.setQuality;
    }

    public void SetQualityResolution(int qualityResolution)
    {
        GameManager.instance.setQuality = qualityResolution;
        QualitySettings.SetQualityLevel(GameManager.instance.setQuality);
    }
}
