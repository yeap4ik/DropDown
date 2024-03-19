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

    public bool ready = false;
    public bool ready2 = false;
    public float alphaBCKP;

    // Start is called before the first frame update
    void Start()
    {

    backgroundImage.material.color = new Color(1, 1, 1, 1); //По дефолту устанавливаем прозрачность на 1, чтобы было видно
    

    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectFalling.PlayerScore == 1 && ready == false){ // Костыль для того, чтобы менять картинку в зависимости от счёта
            ready = true;
            DayTimeAnimation(); 
        }
 

        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(FadeOut());
        }

        if (Input.GetKeyDown("g"))
        {
            StartCoroutine(FadeIn(alphaBCKP));
        }
    }

    public void ChangeDayTime() //Смена картинок (спрайтов)
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
            StartCoroutine(FadeOut()); //Затухаем картинку

    }


    IEnumerator FadeOut() //Затухание картинки
{
    Color c = backgroundImage.material.color;
    for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
    {
        c.a = alpha;
        backgroundImage.material.color = c;
        alphaBCKP = c.a; //Сохраняем значение прозрачности, чтобы с такой же прозрачности начинала появлялась картинка
        yield return new WaitForSeconds(0.02f);
    }
    // После завершения исчезновения, передайте alphaBCKP в FadeIn
    StartCoroutine(FadeIn(alphaBCKP)); //Появляем картинку
    ChangeDayTime(); //Меняем картинку
}

    IEnumerator FadeIn(float alphaBCKP) //Появление картинки
{
    Color c = backgroundImage.material.color;
    for (float alpha = alphaBCKP; alpha <= 1f; alpha += 0.1f)
    {
        c.a = alpha;
        backgroundImage.material.color = c;
        yield return new WaitForSeconds(0.02f);
    }
    }

   




}
