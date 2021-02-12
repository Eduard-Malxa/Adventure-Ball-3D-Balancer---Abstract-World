using System.Collections;
using UnityEngine;
public class CollectBigi : MonoBehaviour
{
    public Animator collectBigi;

    public Animator ball;

    public Collider boxCollider;

    public string animationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            ball.enabled = true;
            if (ball.enabled == true)
            {
                StartCoroutine(enabTrue());
            }
            ball.SetBool(animationName, true);
            collectBigi.SetBool(Tags.TAG_BigiKeyCollected, true);
            boxCollider.enabled = false;
        }
    }

    IEnumerator enabTrue()
    {
        yield return new WaitForSeconds(1f);
        ball.enabled = false;
    }
}
