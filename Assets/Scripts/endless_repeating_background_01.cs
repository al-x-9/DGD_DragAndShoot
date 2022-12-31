using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endless_repeating_background_01 : MonoBehaviour
{
    //DEFINE A VARIABLE THAT WILL SET THE SPEED OF THE BACKGROUND
    public float speed;
    //DEFINE A VARIABLE THAT WILL SET THE STARTING POSITION OF THE BACKGROUND
    public float startX;
    //DEFINE A VARIABLE THAT WILL SET THE ENDING POSITION OF THE BACKGROUND
    public float endX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //USING TRANSFORM MOVE THE BACKGROUND TO THE LEFT AT A GIVEN SPEED
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //IF THE X POSITION OF THE BACKGROUND IS GREATER THAN OR EQUAL TO ENDX THEN...
        if (transform.position.x <= endX)
        {
            //ASSIGN THE BACKGROUND A NEW POSITION BASED ON THE STARTX VARIABLE
            //DEFINE THE VARIABLE...
            Vector2 pos = new Vector2(startX, transform.position.y);
            //AND APPLY IT
            transform.position = pos;
   
        }
    }
}
