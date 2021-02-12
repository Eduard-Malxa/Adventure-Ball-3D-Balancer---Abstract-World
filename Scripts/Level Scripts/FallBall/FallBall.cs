using System.Collections;
using UnityEngine;
public class FallBall : MonoBehaviour
{
    public Vector3 offsetFallBall;

    public GameObject objectAny;

    public float minX;

    public float maxX;

    public float minY;

    public float maxY;

    public float minZ;

    public float maxZ;

    public float timeMin;

    public float timeMax;

    private bool isSpawning;

    [HideInInspector]
    public static bool closeCameraButtonForFallAnyObjectMode;

    internal void Start()
    {
    }

    internal void FixedUpdate()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            CameraFollow.offset = offsetFallBall;
            isSpawning = true;
            StartCoroutine(SpawnSpheres());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.TAG_Ball)
        {
            CameraFollow.offset = new Vector3(0, 2.2f, -3.7f);
            isSpawning = false;
        }
    }

    internal IEnumerator SpawnSpheres()
    {
        yield return new WaitForSeconds(Random.Range(timeMin, timeMax));
        if (isSpawning)
        {
            Instantiate(objectAny, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            StartCoroutine(SpawnSpheres());
        }
    }
}
