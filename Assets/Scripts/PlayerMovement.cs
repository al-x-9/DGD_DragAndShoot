using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //DEFINE A VARIABLE FOR THE POWER OF THE PLAYER
    public float power = 2.5f;
    //DEFINE A VARIABLE FOR THE rigidbody 2d ATTACHED TO THE PLAYER
    public Rigidbody2D rb;

    //DEFINE A VARIABLE FOR THE MINIMUM POWER OF THE PLAYER
    public Vector2 minPower;
    //DEFINE A VARIABLE FOR THE MAXIMUM POWER OF THE PLAYER
    public Vector2 maxPower;

    TrajectoryLine tl;

    //DEFINE A VARIABLE FOR THE CAMERA USED IN THE GAME
    private Camera cam;
    ////DEFINE A VARIABLE FOR THE FORCE APPLIED TO THE PLAYER
    private Vector2 force;
    //DEFINE A VARIABLE FOR THE START POINT OF THE TRAJECTORY LINE
    private Vector3 startPoint;
    //DEFINE A VARIABLE FOR THE END POINT OF THE TRAJECTORY LINE
    private Vector3 endPoint;


    // Start is called before the first frame update
    void Start()
    {
        //ACCESS THE GAME CAMERA
        cam = Camera.main;
        //ACCESS THE TRAJECTORY LINE COMPONENT
        tl = GetComponent<TrajectoryLine>();
    }

    // Update is called once per frame
    void Update()
    {
        //startPoint = gameObject.transform.position;

        //IF THE RIGHT MOUSE BUTTON IS HELD DOWN THEN DO SOMETHING...
        if (Input.GetMouseButtonDown(0))
        {
            //SET THE START POINT TO WHERE THE MOUSE POSITION WAS HELD DOWN
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            //startPoint = gameObject.transform.position;
            //THIS IS USED TO HELP WITH THE DISPLAY OF THE TRAGECTORY LINE
            startPoint.z = 15;
            //Debug.Log("Right mouse button down.");
            //Debug.Log("startPoint is: " + startPoint);

        }
        //IF THE RIGHT MOUSE BUTTON IS CLICKED THEN DO SOMETHING...
        if (Input.GetMouseButton(0))
        {
            //DEFINE A VARIABLE THAT WILL TEMPORARILY STORE THE VALUE OF THE CURRENT MOUSE POSITION
            Vector3 currentpoint = cam.ScreenToWorldPoint(Input.mousePosition);
            //THIS IS USED TO HELP WITH THE DISPLAY OF THE TRAGECTORY LINE
            currentpoint.z = 15;
            //DRAW THE LINE USING THE START AND CURRENT POINT VARIABLES. THIS ADDRESSES THE RENDERLINE FUCNTION IN TRAJECTORYLINE SCRIPT
            tl.RenderLine(startPoint, currentpoint);
        }
        //IF THE RIGHT MOUSE BUTTON IS RELEASED THEN DO SOMETHING...
        if (Input.GetMouseButtonUp(0))
        {
            //SET THE END POINT TO WHERE THE MOUSE POSITION WAS RELEASED. THIS IS USED IN ESTABLISHING HOW MUCH FORCE IS APPLIED
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            //THIS IS USED TO HELP WITH THE DISPLAY OF THE TRAGECTORY LINE
            endPoint.z = 15;
            //STOP RENDERING THE TRAGJECTORY LINE
            tl.EndLine();

            //ESTABLISH THE FORCE ON THE PLAYER OBJECT BASED TRAJECTORY LINE VARIABLES AND OTHER VARIABLES SUCH AS MIN AND MAX POWER
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            //APPLY THE FORCE TO THE RIGIDB
            rb.AddForce(force * power, ForceMode2D.Impulse);
          

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //IF THE PLAYER OBJECT COLLIDES WITH AN OBJECT TAGGED POINT THEN DO SOMETHING
        if (collision.gameObject.tag == "Point")
        {
            Debug.Log("POINT!");

            //FIND THE GAME MANANGER SCRIPT IN THE SCENE AND TRIGGER THE INCRESESCORE FUNCTION ASSOCIATED WITH IT
            FindObjectOfType<GameManager>().IncreaseScore();

            //THEN DESTROY THE POINT OBJECT
            Destroy(collision.gameObject);
        }
    }

    //IF THE PLAYER LEAVES THE SPACE OF A GAME OBJECT TAGGED BOUNDARY THEN DO SOMETHING
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("GAME OVER !");

            //FIND THE GAMEMANAGER SCRIPT IN THE SCENE AND TRIGGER THE GAMEOVER FUNCTION ASSOCIATE WITH IT
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}

