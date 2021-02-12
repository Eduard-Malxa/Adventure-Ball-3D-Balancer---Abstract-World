using UnityEngine;
public class CameraFollowUpdate : MonoBehaviour
{
    private Vector3 offset;

    [HideInInspector]
    public float cameraY_Rotation;

    private Transform lookAt;

    private Vector3 desiredPosition;

    private float smoothSpeed = 6f;

    public void Start()
    {
        offset = new Vector3(0, 2.2f, -3.7f);
        lookAt = GameObject.FindGameObjectWithTag(Tags.TAG_Ball).GetComponent<Transform>();
    }

    public void Update()
    {
        cameraY_Rotation = transform.localEulerAngles.y;
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up);
    }

    public void SlideCamera(Vector3 rotation)
    {
        offset = Quaternion.Euler(rotation) * offset;
    }
}
