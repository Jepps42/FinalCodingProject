using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find the object every frame and make a vector
        Vector2 pos = transform.position;


        //If I press right arrow, make the object move to the right
        //If is called every time I press the right arrow
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        //If I press left arrow, make the object move left
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }

        //If I press down arrow, make the object go down
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed * Time.deltaTime;
        }

        //If I press up arrow, make the object go up
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed * Time.deltaTime;
        }

        //Transform position needs to be in the last line for it to function (hiearchy)
        transform.position = pos;
    }
}
