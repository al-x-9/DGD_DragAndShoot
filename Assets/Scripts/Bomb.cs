using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //DEFINE A VARIABLE THAT DETERMINES HOW QUICKLY THE BOMB DISSAPEARS FROM THE GAME SPACE
    public float bombLife;
    //DEFINE A VARIABLE THAT DETERMINES HOW LONG BEFORE THE BOMB EXPLODES
    public float countDownTimer;
    //DEFINE A VARIABLE FOR HOW FAST THE BOMB FLASHES BEFORE EXPLODING
    public float flashSpeed;
    public GameObject particleEffect;

    //DEFINE THE FIRST/START COLOR FOR THE FLASH
    private Color startColor = Color.black;
    //DEFINE THE SECOND/END COLOR FOR THE FLASH
    private Color endColor = Color.white;

    //DEFINE VARIABLE FOR THE POINT EFFECTOR WE WILL BE USING TO CAUSE A EXPLOSION FORCE
    private PointEffector2D pe2d;
    //DEFINE A RENDERED FOR THE FLASHING EFFECT
    private Renderer myRenderer;

    //DEFINE WHETHER THE BOMB IS EXPLODING OR NOT
    private bool isExploding;

    // Start is called before the first frame update
    void Start()
    {
        //ACCESS THE POINT EFFECTOR COMPONENT
        pe2d = GetComponent<PointEffector2D>();
        //ACCESS THE RENDERER COMPONENT
        myRenderer = GetComponent<Renderer>();
        //START THE BOMB AS NOT EXPLODING
        isExploding = false;
    }

    // Update is called once per frame
    void Update()
    {
       //IF THE BOMB IS SET TO EXPLODE THEN DO SOMETHING
       if(isExploding == true)
        {
            //COUNT DOWN TIMER BEFORE BOMB EXPLODES
            countDownTimer -= Time.deltaTime;
            //SET UP THE BOMB TO FLASH
            myRenderer.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * flashSpeed, 1));
            particleEffect.SetActive(true);

            //IF THE COUNTDOWN TIMER IS LESS THAN ZERO THEN DO SOMETHING 
            if(countDownTimer <= 0)
            {
                //TURN ON THE POINT EFFECTOR COMPONENT 
                pe2d.enabled = true;
                //THEN DESTORY THE BOMB
                Destroy(gameObject, bombLife);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //IF THE OBJECT THAT HAS ENTERED THE TRIGGER AREA HAS PLAYER TAG ASSIGNED THEN...
        if (collision.CompareTag("Player"))
        {
            
            //SET THE BOMB TO EXPLODE
            isExploding = true;

            //FIND THE "endless_game_manager_01" SCRIPT IN THE SCENE AND TRIGGER THE GameOver FUNCTION ASSOCIATE WITH IT
            //pe2d.enabled = true;
            //Destroy(gameObject, destroyTime);


        }

    }

}
