using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class DisplayText : MonoBehaviour
{

    public TMP_Text PearCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     PearCount.text = "SCORE: " + ObjectFalling.PlayerScore.ToString();

    }
}
