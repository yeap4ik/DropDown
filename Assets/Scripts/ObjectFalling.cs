using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{

    public static int PlayerScore = 0; // Глобальная переменная, которую можно достичь легко из другого скрипта

    public GameObject pearPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //spawndelay();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DEL_PEAR_HIT_FLOR()
    {
        Destroy(gameObject);
    }
    public float countPear = 0;
    public void PearSpawn()
    {
        float randomX = Random.Range(-8.5f, 8.5f); //Случайная координата по Х
        Instantiate(pearPrefab, new Vector3(randomX, 4.5f, 0), Quaternion.identity); //Создаём грушу
        //Потом привязать к счётчику съеденных груш, чтобы увеличить сложность
    }




    public void aloGEY()
    {
        Debug.Log("АЛО ГЕЙ");
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Cat(player)"){ //Если груша коснулась игрока
            PlayerScore++;
            //FindObjectOfType<NewBehaviourScript>().UpdatePlayerScore(PlayerScore); //Отправляем счёт в другой скрипт
            Debug.Log("Счёт: " + PlayerScore);

            PearSpawnController behaviourScript = FindObjectOfType<PearSpawnController>();
                behaviourScript.DifficultLevelController();

        
           
            //Мне чтобы у клона были те же параметры, что и у оригинала. Однако клонируй не клона, а префаб
            //GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
           // GameObject prefab = Instantiate(gameObject);
            PearSpawn();
            DEL_PEAR_HIT_FLOR();}
        else if (col.gameObject.name == "Floor") //Если груша коснулась пола
        {
            PearSpawn();
            DEL_PEAR_HIT_FLOR();
        }
}
}