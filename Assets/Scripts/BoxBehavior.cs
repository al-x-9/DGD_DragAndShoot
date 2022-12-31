using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IF THE BOX LEAVES THE SPACE OF A GAME OBJECT TAGGED BOUNDARY THEN DO SOMETHING
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("DESTROY!");

            //DESTROY THE OBJECT THE SCRIPT IS ATTACHED TO
            Destroy(this.gameObject);
        }
    }
}
