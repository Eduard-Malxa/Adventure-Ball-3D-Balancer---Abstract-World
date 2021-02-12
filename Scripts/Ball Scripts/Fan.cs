using UnityEngine;
public class Fan : MonoBehaviour
{
    public float velocityY;

    public float velocityX;

    public float gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            BallMovementForEveryBall.velocityY = velocityY;
            BallMovementForEveryBall.velocityX = velocityX;
            Physics.gravity = new Vector3(0, gravity, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BallMovementForEveryBall.velocityY = 4f;
        BallMovementForEveryBall.velocityX = 4f;
        Physics.gravity = new Vector3(0, -30, 0);
    }
}
