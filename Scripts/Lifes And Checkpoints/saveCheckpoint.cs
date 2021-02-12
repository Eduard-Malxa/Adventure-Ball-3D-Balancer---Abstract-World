using UnityEngine;
public class saveCheckpoint : MonoBehaviour
{
    public  GameObject[] checkpointPosition;

    public  GameObject[] checkpoint;

    [HideInInspector]
    public static Vector3 lastPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Checkpoint_First_Pos)
        {
            lastPosition = checkpointPosition[3].transform.position;
        }
        if (other.gameObject.tag == Tags.TAG_Checkpoint)
        {
            lastPosition = checkpointPosition[0].transform.position;
            checkpoint[0].gameObject.SetActive(false);
        }
        if (other.gameObject.tag == Tags.TAG_Checkpoint_1)
        {
            lastPosition = checkpointPosition[1].transform.position;
            checkpoint[1].gameObject.SetActive(false);
        }
        if (other.gameObject.tag == Tags.TAG_Checkpoint_2)
        {
            lastPosition = checkpointPosition[2].transform.position;
            checkpoint[2].gameObject.SetActive(false);
        }
    }
}
