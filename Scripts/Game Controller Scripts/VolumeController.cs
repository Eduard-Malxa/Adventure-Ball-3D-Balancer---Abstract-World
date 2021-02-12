using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;

    public Slider slider;

    public void Start()
    {
        slider.value = GameManager.instance.volumeFrom;
    }

    public void VolumeControl(float volume)
    {
        GameManager.instance.volumeFrom = volume;
        audioSource.volume = GameManager.instance.volumeFrom;
        GameManager.firstTimeMusic += 0.001f;
    }
}
