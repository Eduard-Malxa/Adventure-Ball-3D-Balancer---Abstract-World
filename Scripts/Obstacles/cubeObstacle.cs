using System.Collections;
using UnityEngine;
public class cubeObstacle : MonoBehaviour
{
    public float LeftRightSpeed;

    private float waitModSpeed = 10f;

    public float rotatedModSpeed;

    public float rotatedModTime;

    public float LeftRightMaxTransform;

    public float LeftRightMinTransform;

    private int direction = 1;

    private float range;

    public float LeftRightRangeMin;

    public float LeftRightRangeMax;

    private bool changeDir;

    private bool go;

    private bool collisionFromRight;

    public bool rotatedMod;

    public bool leftRightMod;

    public bool waitMod;

    private Vector3 origin;

    private void Awake()
    {
        range = Random.Range(LeftRightRangeMin, LeftRightRangeMax);
        changeDir = true;
        go = false;
        origin = transform.position;
    }

    internal void FixedUpdate()
    {
        if (PlatformAttach.isUpdateMode == false)
        {
            if (rotatedMod)
            {
                directionRotatedMod();
            }
            else if (leftRightMod)
            {
                transform.Translate(LeftRightSpeed * direction * Time.deltaTime, 0, 0);
                directionLeftRightMod();
            }
            else if (waitMod && go)
            {
                directionWaitMod();
            }
        }
    }

    internal void LateUpdate()
    {
        if (PlatformAttach.isUpdateMode == true)
        {
            if (rotatedMod)
            {
                directionRotatedMod();
            }
            else if (leftRightMod)
            {
                transform.Translate(LeftRightSpeed * direction * Time.deltaTime, 0, 0);
                directionLeftRightMod();
            }
            else if (waitMod && go)
            {
                directionWaitMod();
            }
        }
    }
    public void directionLeftRightMod()
    {
        if (transform.position.x >= LeftRightMaxTransform)
        {
            transform.position = new Vector3(LeftRightMaxTransform, transform.position.y, transform.position.z);
            StartCoroutine(stopCorutine(1));
        }
        else if (transform.position.x <= LeftRightMinTransform)
        {
            transform.position = new Vector3(LeftRightMinTransform, transform.position.y, transform.position.z);
            StartCoroutine(stopCorutine(-1));
        }
    }

    public void directionRotatedMod()
    {
        if (changeDir)
        {
            transform.Translate(rotatedModSpeed * direction * Time.deltaTime, 0, 0);
            StartCoroutine(rotatedM(false));
        }
        else
        {
            transform.Translate(rotatedModSpeed * -direction * Time.deltaTime, 0, 0);
            StartCoroutine(rotatedM(true));
        }
    }

    public void directionWaitMod()
    {
        if (collisionFromRight)
        {
            transform.Translate(waitModSpeed * direction * Time.deltaTime, 0, 0);
            StartCoroutine(BringOrigin());
        }
        else if (!collisionFromRight)
        {
            transform.Translate(waitModSpeed * -direction * Time.deltaTime, 0, 0);
            StartCoroutine(BringOrigin());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            other.gameObject.transform.parent = transform;
            PlatformAttach.isUpdateMode = true;
            go = true;

            void checkCollidingSide()
            {
                if (transform.position.x > other.transform.position.x)
                {
                    collisionFromRight = true;
                }
                else
                {
                    collisionFromRight = false;
                }
            }
            checkCollidingSide();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            other.gameObject.transform.parent = null;
            PlatformAttach.isUpdateMode = false;
        }
    }

    internal IEnumerator stopCorutine(int num)
    {
        yield return new WaitForSeconds(range);
        direction = num;
    }

    internal IEnumerator rotatedM(bool dir)
    {

        yield return new WaitForSeconds(rotatedModTime);
        changeDir = dir;
    }

    internal IEnumerator BringOrigin()
    {
        yield return new WaitForSeconds(3f);
        transform.position = origin;
        go = false;
    }
}
