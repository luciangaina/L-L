using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPoints;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator =FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if(doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPoints*2;
                theScoreManager.shouldDouble = true;
            }

            if(safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0;
            }

            if(powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPoints;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;

                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float length)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = length;

        normalPoints = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;


        if(safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for(int i = 0; i<spikeList.Length ; i++)
            {
                if(spikeList[i].gameObject.name.Contains("spikes"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }
            }
        }

        powerupActive = true;
    }
}
