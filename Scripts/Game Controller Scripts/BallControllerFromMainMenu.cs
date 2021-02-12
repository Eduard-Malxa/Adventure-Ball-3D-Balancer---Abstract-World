using UnityEngine;
public class BallControllerFromMainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public MeshRenderer meshRendererBall;

    public Material[] materials;

    public void Start()
    {
        audioSource.volume = GameManager.instance.volumeFrom;
        meshRendererBall.sharedMaterial = materials[GameManager.instance.setBall];
    }
}
