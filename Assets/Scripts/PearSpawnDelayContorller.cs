using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearSpawnController : MonoBehaviour
{
    public GameObject pearPrefab;
    public ObjectFalling PlayerScoreObjectFalling; //Подключаем скрипт счёта
    // Start is called before the first frame update

    int PlayerScore123;

    

    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore123 = ObjectFalling.PlayerScore;
    }

    public void DifficultLevelController() //Получаем счёт из другого скрипта
    {
            Debug.Log("СчётNEW: " + PlayerScore123);


        if (PlayerScore123 == 3)
        {
            Invoke("CallPearSpawn", 2f); //Вызываем статичную функцию, которая преобразована из динамической
        }

        else if (PlayerScore123 == 7)
        {
            Invoke("CallPearSpawn", 2f); //Вызываем статичную функцию, которая преобразована из динамической
        }

        else if (PlayerScore123 == 12)
        {
            Invoke("CallPearSpawn", 1f); //Вызываем статичную функцию, которая преобразована из динамической
        }
        
    }

    void CallPearSpawn()
{
    ObjectFalling script = FindObjectOfType<ObjectFalling>(); //Ебучий костыль. Подключаю функцию из другого скрипта, она считается как динамическая, 
    script.PearSpawn();//поэтмоу invoke её не может вызвать. Поэтому существует этот костыль, чтобы она стала типа 
                        //статической и invoke мог её вызвать. 
    
}

}
