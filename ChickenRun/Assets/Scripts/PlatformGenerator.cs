using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    public Transform maxHeightPoint;

    private SeedGenerator theSeedGenerator;
    public float randomSeedThreshold;

    public float randomSpikeThreshold;
    public ObjectPooler spikePool;

    public float powerupHeight;
    public float powerupThershold;
    public ObjectPooler powerupPool;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];

        for(int i=0;i<theObjectPools.Length;i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theSeedGenerator = FindObjectOfType<SeedGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange>maxHeight)
            {
                heightChange = maxHeight;
            } else if(heightChange<minHeight)
            {
                heightChange = minHeight;
            }

            //powerups
            if(Random.Range(0f, 100f) < powerupThershold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();

                Vector3 powerupPosition = new Vector3(1f, 2.5f, 0f); 

                newPowerup.transform.position = transform.position + powerupPosition;
                newPowerup.transform.rotation = transform.rotation;

                newPowerup.SetActive(true);

            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //seeds
            if (Random.Range(0f, 100f) < randomSeedThreshold)
            {
                theSeedGenerator.SpawnSeeds(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }

            //spikes
            if (Random.Range(0f, 100f) < randomSpikeThreshold && platformWidths[platformSelector]>3.1f)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector]/2 +1f, platformWidths[platformSelector]/2 -1f);

                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f,0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

            

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
