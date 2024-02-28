using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    public int PlayerScore = 0;

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
    public int countPear = 0;
    public void PearSpawn()
    {
        float randomX = Random.Range(-8.5f, 8.5f);
        Instantiate(pearPrefab, new Vector3(randomX, 4.5f, 0), Quaternion.identity);
        if (countPear < 5)
        {
            //spawndelay();
        }
        //Потом привязать к счётчику съеденных груш, чтобы увеличить сложность
    }

    public void spawndelay()
    {
        Debug.Log("СПААААВн");
        Invoke("PearSpawn", 20000f);
        countPear++;
        PearSpawn();
        
    }

    public void increaseDifficulty_pearspawn()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Зашёл в функцию");
        if (col.gameObject.name == "Cat(player)"){
           PlayerScore++;
           Debug.Log("Счёт: " + PlayerScore);
        }
           
            //Мне чтобы у клона были те же параметры, что и у оригинала. Однако клонируй не клона, а префаб
            //GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
           // GameObject prefab = Instantiate(gameObject);
            PearSpawn();
            DEL_PEAR_HIT_FLOR();
    }
}
