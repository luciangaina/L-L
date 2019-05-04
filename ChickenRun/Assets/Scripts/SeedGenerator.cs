using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    public ObjectPooler seedPool;

    public float distanceBetweenSeeds;

    public void SpawnSeeds(Vector3 startPosition)
    {
        GameObject seed1 = seedPool.GetPooledObject();
        seed1.transform.position = startPosition;
        seed1.SetActive(true);

        GameObject seed2 = seedPool.GetPooledObject();
        seed2.transform.position = new Vector3(startPosition.x - distanceBetweenSeeds, startPosition.y, startPosition.z);
        seed2.SetActive(true);

        GameObject seed3 = seedPool.GetPooledObject();
        seed3.transform.position = new Vector3(startPosition.x + distanceBetweenSeeds, startPosition.y, startPosition.z);
        seed3.SetActive(true);
    }
}
