using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearSpawnController : MonoBehaviour
{
    int PlayerScore123 = 0;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore123 = ObjectFalling.PlayerScore; //По скольку там что-то типо глобальной переменной, её спокойно можно считать из друго скрипта
    }

    public void DifficultLevelController() //Получаем счёт из другого скрипта
    {
            Debug.Log("СчётNEW: " + (PlayerScore123 = PlayerScore123 + 1));


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
