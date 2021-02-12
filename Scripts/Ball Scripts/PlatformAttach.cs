using UnityEngine;
public class PlatformAttach : MonoBehaviour
{
    public static bool isUpdateMode;

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            other.gameObject.transform.parent = transform;
            isUpdateMode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            other.gameObject.transform.parent = null;
            isUpdateMode = false;
        }
    }
}
