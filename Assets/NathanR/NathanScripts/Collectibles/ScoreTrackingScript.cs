﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrackingScript : MonoBehaviour
{
    public int Wood = 0;
    public int Stone = 0;
    public int Dogs = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainCollectibles(int W, int S, int D)
    {
        Debug.Log("ScoreTrackingScript used");
        Wood += W;
        Stone += S;
        Dogs += D;
    }
}