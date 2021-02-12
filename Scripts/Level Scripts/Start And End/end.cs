using UnityEngine;
public class end : MonoBehaviour
{
    public Vector3 endPosition;

    internal void Update()
    {
        if (OnTriggerBallScript.EndKey == true)
        {
            gameObject.transform.position = endPosition;
        }
    }
}
