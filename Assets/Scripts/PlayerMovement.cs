using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();

    }
    
    void Update()
    {
        inputMovement = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
        ); 
    }

    private void FixedUpdate()
    {
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SafeZone"))
        {
            scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
            scoreManager.GetComponent<ScoreManager>().AddPoints();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision) //Function when the character enters the water
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ocean")) //Is triggered when something enters the water
        {
            velocity = velocity * 0.5f; //Makes speed 0.5 times the original speed
            Debug.Log(speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Function when the character exits the water
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ocean")) //Is triggered when something enters the water
        {
            velocity = velocity * 2f; //Speed is set back to normal
            Debug.Log(speed);
        }
    }
}