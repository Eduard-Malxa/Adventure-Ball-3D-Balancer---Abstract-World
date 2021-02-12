using UnityEngine;
public class CameraDirectionChanger : MonoBehaviour
{
    public CameraFollow CameraFollow_0;

    public CameraFollow CameraFollow_1;

    public CameraFollow CameraFollow_2;

    public void moveCamera(float num)
    {
        if (GameManager.instance.setGraphics == 0)
        {
            CameraFollow_0.SlideCamera(Vector3.up * num);

        }
        else if (GameManager.instance.setGraphics == 1)
        {
            CameraFollow_1.SlideCamera(Vector3.up * num);
        }
        else if (GameManager.instance.setGraphics == 2)
        {
            CameraFollow_2.SlideCamera(Vector3.up * num);
        }
    }
}
