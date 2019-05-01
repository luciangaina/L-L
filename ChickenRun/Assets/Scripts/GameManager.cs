using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * for restart
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        thePlayer.gameObject.SetActive(false);
    }
}
