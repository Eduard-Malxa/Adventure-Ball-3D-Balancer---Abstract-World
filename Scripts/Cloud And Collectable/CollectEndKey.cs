using UnityEngine;
public class CollectEndKey : MonoBehaviour
{
    public Animator collectEndKey;

    public Collider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            collectEndKey.SetBool(Tags.TAG_collected, true);
            boxCollider.enabled = false;
        }
    }
}
