using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7;
    // Start is called before the first frame update
    void Start()
    {

        
    }


    public IEnumerator movement()
    {
        yield return new WaitForSeconds(2);
    }

    // Update is called once per frame
    void Update()
    {
    float x = Input.GetAxis("Horizontal");
    //float z = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(x, 0);
    transform.Translate(movement * speed * Time.deltaTime);
    }
}
