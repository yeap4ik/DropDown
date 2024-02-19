using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDaytime : MonoBehaviour
{
    
    public Image backgroundImage;
    public Sprite morningImage;
    public Sprite dayImage;
    public Sprite eveningImage;
    public Sprite nightImage;

    int counting = 0;
    public bool ready = false;
    public bool ready2 = false;
    public float alphaBCKP;

    // Start is called before the first frame update
    void Start()
    {
    backgroundImage.material.color = new Color(1, 1, 1, 1);
    

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
        StartCoroutine(FadeOut());
        }

        if (Input.GetKeyDown("g"))
        {
        StartCoroutine(FadeIn(alphaBCKP));
        }
    }

    public void ChangeDayTime()
    {
        if (backgroundImage.sprite == morningImage)
            backgroundImage.sprite = dayImage;

        else if (backgroundImage.sprite == dayImage)
                backgroundImage.sprite = eveningImage;
        
        else if (backgroundImage.sprite == eveningImage)
            backgroundImage.sprite = nightImage;
        
        else if (backgroundImage.sprite == nightImage)
            backgroundImage.sprite = morningImage;
        

    }

    public void DayTimeAnimation(){
    StartCoroutine(FadeOut());

    }


    IEnumerator FadeOut()
{
    Color c = backgroundImage.material.color;
    for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
    {
        c.a = alpha;
        backgroundImage.material.color = c;
        if (alpha > .2f){
            ready2 = true;
            //Debug.Log("FadeOut" + ready2);
        }
        else{
            ready2 = false;
        }
        alphaBCKP = c.a;
        //Debug.Log(alphaBCKP);
        yield return new WaitForSeconds(0.02f);
    }
    // После завершения исчезновения, передайте alphaBCKP в FadeIn
    StartCoroutine(FadeIn(alphaBCKP));
    ChangeDayTime();
}

    IEnumerator FadeIn(float alphaBCKP)
{
    Color c = backgroundImage.material.color;
    Debug.Log("Я перед циклом");
    for (float alpha = alphaBCKP; alpha <= 1f; alpha += 0.1f)
    {
        c.a = alpha;
        backgroundImage.material.color = c;
        if (alpha >= 0.9f){
            ready = true;
            Debug.Log("FadeIN" + ready);
        }
        else{
            ready = false;
            Debug.Log("FadeIN" + ready);
        }
        yield return new WaitForSeconds(0.02f);
    }
    }




}
