using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10; //The default speed
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;

    public int PowerUpBoost = 10; //Powerup speed

    public float speedBoostDuration = 5.0f; //Duration of the powerup in seconds
    private Coroutine speedBoostCoroutine;

    void Start()
    {   //Sets the speed in x and y, grabs the Rigidbody component from the inspector
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();

    }

    public void ApplySpeedBoost()
    {   //Creates a coroutine
        if (speedBoostCoroutine != null)
        {
        StopCoroutine(speedBoostCoroutine);
        } //Coroutine sets the velocity (speed) to the default speed + the boost speed
        velocity = new Vector2(speed + PowerUpBoost, speed + PowerUpBoost);
        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine()); 
    }

    private IEnumerator SpeedBoostCoroutine()
    {   //Waits for the value of the speed boost duration and stops the coroutine
        yield return new WaitForSeconds(speedBoostDuration);
        velocity = new Vector2(speed, speed); //The speed is set back to the default speed only
    }
    
    void Update()
    {   //Gets the keyboard input as the x and y (its a vector 2)
        inputMovement = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")); 

    // Checks for collision with the power-up object in the layer "PowerUp"
    Collider2D powerUpCollider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("PowerUp"));

    if (powerUpCollider != null)
        {
        // Calls ApplySpeedBoost and afterwards destroy power-up object
        ApplySpeedBoost();
        Destroy(powerUpCollider.gameObject);
        }
    }

    private void FixedUpdate()
    {   //Take the inputMovement, multiplies with speed, and multiplies with time (instead of every update)
        //Otherwise the character would move according to every time Update updates, resulting in a very fast character.
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition); //The new position for the player
    }

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