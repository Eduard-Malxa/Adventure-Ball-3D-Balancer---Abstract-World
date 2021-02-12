using UnityEngine;
using UnityEngine.UI;
public class LevelUnlockController : MonoBehaviour
{
    public Button[] lvlButtons;

    public void Start()
    {
        int levelAt = PlayerPrefs.GetInt(Tags.TAG_levelAt, 2);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            //if (i + 1 > 0)
            //    lvlButtons[i].interactable = true;
            // use this
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
}
