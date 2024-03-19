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
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DEL_PEAR_HIT_FLOR()
    {
        Destroy(gameObject);
    }
    public void PearSpawn()
    {
        float randomX = Random.Range(-8.5f, 8.5f); //Случайная координата по Х
        Instantiate(pearPrefab, new Vector3(randomX, 4.5f, 0), Quaternion.identity); //Создаём грушу
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Cat(player)"){ //Если груша коснулась игрока
            PlayerScore++;
            Debug.Log("Счёт: " + PlayerScore);
            PearSpawnController behaviourScript = FindObjectOfType<PearSpawnController>(); //Подключаем все функции из другого скрипта
            behaviourScript.DifficultLevelController(); //Вызываем функцию из другого скрипта, чтобы увеличить сложность игры и спавнить больше груш
            PearSpawn(); //Спавним новую грушу
            DEL_PEAR_HIT_FLOR(); //Убираем старую грушу (которую типа съел игрок)
}

        else if (col.gameObject.name == "Floor") //Если груша коснулась пола
        {
            PearSpawn();
            DEL_PEAR_HIT_FLOR();
        }
}
}