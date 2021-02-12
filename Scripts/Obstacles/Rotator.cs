using UnityEngine;
public class Rotator : MonoBehaviour
{
    public float speedX;

    public float speedY;

    public float speedZ;

    internal void FixedUpdate()
    {
        transform.Rotate(speedX * Time.deltaTime / 0.01f, speedY * Time.deltaTime / 0.01f, speedZ * Time.deltaTime / 0.01f, Space.Self);
    }
}
