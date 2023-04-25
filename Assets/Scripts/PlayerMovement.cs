using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    // private PickUp pickUp; 

    private GameObject scoreManager;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();
        /* pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1); */

    }
    
    void Update()
    {
        inputMovement = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
        ); 
        
        
        /*if (inputMovement.sqrMagnitude > .1f) 
        {
            pickUp.Direction = inputMovement;        
        }*/
      

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ocean"))
        {
            velocity = velocity * 0.5f;
            Debug.Log(speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ocean"))
        {
            velocity = velocity * 2f;
            Debug.Log(speed);
        }
    }
}