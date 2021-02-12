using System.Collections;
using UnityEngine;
public class LevelAnimations : MonoBehaviour
{
    public Animator[] blacks;

    public bool ifDestroyGameobject;

    public string animationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            for (int i = 0; i < blacks.Length; i++)
            {
                blacks[i].Play(animationName);
                StartCoroutine(deactiveBlacks(i));
            }
        }
    }

    internal IEnumerator deactiveBlacks(int i)
    {
        yield return new WaitForSeconds(3f);

        if (ifDestroyGameobject)
        {
            blacks[i].gameObject.SetActive(false);
        }
    }
}
