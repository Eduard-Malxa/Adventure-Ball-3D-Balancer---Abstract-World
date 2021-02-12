using System.Collections;
using UnityEngine;
public class Booster : MonoBehaviour
{
    public float velocityY;

    public float velocityX;

    public float gravity;

    public float boosterTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            BallMovementForEveryBall.velocityY = velocityY;
            BallMovementForEveryBall.velocityX = velocityX;
            Physics.gravity = new Vector3(0, gravity, 0);
            StartCoroutine(BoostStoper());
        }
    }

    internal IEnumerator BoostStoper()
    {
        yield return new WaitForSeconds(boosterTime);
        BallMovementForEveryBall.velocityY = 4f;
        BallMovementForEveryBall.velocityX = 4f;
        Physics.gravity = new Vector3(0, -30, 0);
    }
}
