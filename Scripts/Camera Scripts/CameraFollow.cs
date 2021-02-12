using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public static Vector3 offset;

    [HideInInspector]
    public Vector3 labirintOffset;

    private Quaternion labirintCameraRotation;

    [HideInInspector]
    public static bool LabrintMode;

    [HideInInspector]
    public float cameraY_Rotation;

    private Transform lookAt;

    private Vector3 desiredPosition;

    private float smoothSpeed;

    public GameObject lightBall;

    private Quaternion lightOffset;

    private Quaternion lightOffsetLabirintMode;

    public Vector3 off;

    public void Start()
    {
        Application.targetFrameRate = 320;
        smoothSpeed = 6f;
        offset = new Vector3(0, 2.2f, -3.7f);
        labirintOffset = new Vector3(0, 35f, 0);
        labirintCameraRotation = Quaternion.Euler(90f, 0, 0);
        LabrintMode = false;
        lightOffset = Quaternion.Euler(30f, 0, 0);
        lightOffsetLabirintMode = Quaternion.Euler(350f, 0, 0);
        lookAt = GameObject.FindGameObjectWithTag(Tags.TAG_Ball).GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        if (!LabrintMode)
        {
            if (PlatformAttach.isUpdateMode == false)
            {
                cameraNormalOffset();
            }
        }
        else if (LabrintMode == true)
        {
            if (PlatformAttach.isUpdateMode == false)
            {
                cameraLabirintMode();
            }
        }
    }

    public void LateUpdate()
    {
        if (!LabrintMode)
        {
            if (PlatformAttach.isUpdateMode == true)
            {
                cameraNormalOffset();
            }
        }
        else if (LabrintMode == true)
        {
            if (PlatformAttach.isUpdateMode == true)
            {
                cameraLabirintMode();
            }
        }
    }

    public void cameraNormalOffset()
    {
        cameraY_Rotation = transform.localEulerAngles.y;
        desiredPosition = lookAt.position + offset;
        lightBall.transform.rotation = transform.rotation * lightOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up);
    }

    public void cameraLabirintMode()
    {
        transform.rotation = labirintCameraRotation;
        transform.position = Vector3.Lerp(transform.position, lookAt.position + labirintOffset, smoothSpeed * Time.deltaTime);
        lightBall.transform.rotation = transform.rotation * lightOffsetLabirintMode;
    }

    public void SlideCamera(Vector3 rotation)
    {
        offset = Quaternion.Euler(rotation) * offset;
    }
}
