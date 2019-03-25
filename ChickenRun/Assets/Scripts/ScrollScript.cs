using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public Transform centerBackground;
    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= centerBackground.position.x + 10f)
            centerBackground.position = new Vector2(centerBackground.position.x + 10f, centerBackground.position.y);
    }
}
