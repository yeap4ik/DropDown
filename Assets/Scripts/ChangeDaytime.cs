using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDaytime : MonoBehaviour
{
    
    public Image morningImage;
    public Sprite dayImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToDay()
    {
        morningImage.sprite = dayImage;
    }
}
