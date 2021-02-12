using UnityEngine;
using UnityEngine.UI;
public class BallMovementForEveryBall : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public CameraFollow cameraFollow0;

    public CameraFollow cameraFollow1;

    public CameraFollow cameraFollow2;

    public Button CameraButtonLeft;

    public Button CameraButtonRight;

    [HideInInspector]
    public static float velocityX = 4f;

    [HideInInspector]
    public static float velocityY = 4f;

    [HideInInspector]
    public bool moveLeft;

    [HideInInspector]
    public bool moveRight;

    [HideInInspector]
    public bool moveUp;

    [HideInInspector]
    public bool moveDown;

    [HideInInspector]
    public bool degree_0 = true;

    [HideInInspector]
    public bool degree_270 = true;

    [HideInInspector]
    public bool degree_180 = true;

    [HideInInspector]
    public bool degree_90 = true;

    public void Awake()
    {
        rigidbody = GameObject.FindGameObjectWithTag(Tags.TAG_Ball).GetComponent<Rigidbody>();
        FallBall.closeCameraButtonForFallAnyObjectMode = false;
    }

    public void FixedUpdate()
    {
        if (!CameraFollow.LabrintMode)
        {
            if (GameManager.instance.setGraphics == 0)
            {
                MoveBallWidthButton(cameraFollow0);
                MoveBallWidthKeyBoard(cameraFollow0);
            }
            else if (GameManager.instance.setGraphics == 1)
            {
                MoveBallWidthButton(cameraFollow1);
                MoveBallWidthKeyBoard(cameraFollow1);
            }
            else if (GameManager.instance.setGraphics == 2)
            {
                MoveBallWidthButton(cameraFollow2);
                MoveBallWidthKeyBoard(cameraFollow2);
            }
        }
        else
            if (CameraFollow.LabrintMode == true)
        {
            LabirintModeMoveWhidthKeyboard();
            LabirintModeMoveWidthButton();
        }

        if (!FallBall.closeCameraButtonForFallAnyObjectMode || !CameraFollow.LabrintMode)
        {
            CameraButtonLeft.gameObject.SetActive(true);
            CameraButtonRight.gameObject.SetActive(true);
        }

        if (FallBall.closeCameraButtonForFallAnyObjectMode == true || CameraFollow.LabrintMode == true)
        {
            CameraButtonLeft.gameObject.SetActive(false);
            CameraButtonRight.gameObject.SetActive(false);
        }

      
    }

    public void moveLeftButton()
    {
        moveLeft = true;
    }

    public void moveLeftButtonStop()
    {
        moveLeft = false;
    }

    public void moveRightButton()
    {
        moveRight = true;
    }

    public void moveRightButtonStop()
    {
        moveRight = false;
    }

    public void moveUpButton()
    {
        moveUp = true;
    }

    public void moveUpButtonStob()
    {
        moveUp = false;
    }

    public void moveDownButton()
    {
        moveDown = true;
    }

    public void moveDownButtonStop()
    {
        moveDown = false;
    }

    public void MoveBallWidthButton(CameraFollow cameraFollowScript)
    {
        if (cameraFollowScript.cameraY_Rotation > -20f && cameraFollowScript.cameraY_Rotation < 20f || cameraFollowScript.cameraY_Rotation > 335f && cameraFollowScript.cameraY_Rotation < 365f)
        {
            degree_180 = false;
            degree_270 = false;
            degree_90 = false;
            degree_0 = true;
            if (moveLeft == true)
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            if (moveRight == true)
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            if (moveUp == true)
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            if (moveDown == true)
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 60f && cameraFollowScript.cameraY_Rotation < 120f)
        {
            degree_90 = true;
            degree_270 = false;
            degree_180 = false;
            degree_0 = false;
            if (moveLeft == true)
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            if (moveRight == true)
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            if (moveUp == true)
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            if (moveDown == true)
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 150f && cameraFollowScript.cameraY_Rotation < 210f)
        {
            degree_180 = true;
            degree_270 = false;
            degree_90 = false;
            degree_0 = false;
            if (moveLeft == true)
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            if (moveRight == true)
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            if (moveUp == true)
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            if (moveDown == true)
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 230f && cameraFollowScript.cameraY_Rotation < 310f)
        {
            degree_270 = true;
            degree_180 = false;
            degree_90 = false;
            degree_0 = false;
            if (moveLeft == true)
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            if (moveRight == true)
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            if (moveUp == true)
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            if (moveDown == true)
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
        }
    }

    public void LabirintModeMoveWidthButton()
    {
        if (moveLeft == true)
            rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
        if (moveRight == true)
            rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
        if (moveUp == true)
            rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
        if (moveDown == true)
            rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
    }

    public void MoveBallWidthKeyBoard(CameraFollow cameraFollowScript)
    {
        if (cameraFollowScript.cameraY_Rotation > -20f && cameraFollowScript.cameraY_Rotation < 20f || cameraFollowScript.cameraY_Rotation > 335f && cameraFollowScript.cameraY_Rotation < 365f)
        {
            degree_180 = false;
            degree_270 = false;
            degree_90 = false;
            degree_0 = true;
            if (Input.GetKey(KeyCode.A))
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.D))
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.W))
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.S))
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 65f && cameraFollowScript.cameraY_Rotation < 120f)
        {
            degree_90 = true;
            degree_270 = false;
            degree_180 = false;
            degree_0 = false;
            if (Input.GetKey(KeyCode.A))
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.D))
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.W))
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.S))
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 160f && cameraFollowScript.cameraY_Rotation < 210f)
        {
            degree_180 = true;
            degree_270 = false;
            degree_90 = false;
            degree_0 = false;
            if (Input.GetKey(KeyCode.A))
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.D))
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.W))
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.S))
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
        }
        if (cameraFollowScript.cameraY_Rotation > 240f && cameraFollowScript.cameraY_Rotation < 310f)
        {
            degree_270 = true;
            degree_180 = false;
            degree_90 = false;
            degree_0 = false;
            if (Input.GetKey(KeyCode.A))
                rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.D))
                rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.W))
                rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
            else if (Input.GetKey(KeyCode.S))
                rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
        }
    }

    public void LabirintModeMoveWhidthKeyboard()
    {
        if (Input.GetKey(KeyCode.A))
            rigidbody.AddForce(new Vector3(-velocityX, 0, 0), ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.D))
            rigidbody.AddForce(new Vector3(velocityX, 0, 0), ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.W))
            rigidbody.AddForce(new Vector3(0, 0, velocityY), ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.S))
            rigidbody.AddForce(new Vector3(0, 0, -velocityY), ForceMode.Impulse);
    }
}
