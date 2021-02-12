using UnityEngine;
public class CollectCloud : MonoBehaviour
{
    public Animator collectCloud;

    public Collider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            collectCloud.SetBool("collected", true);
            boxCollider.enabled = false;
        }
    }
}
