using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;

    public int PowerUpBoost = 10;

    public float speedBoostDuration = 5.0f;
    private Coroutine speedBoostCoroutine;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();

    }

    public void ApplySpeedBoost()
    {
        if (speedBoostCoroutine != null)
        {
        StopCoroutine(speedBoostCoroutine);
        }
        velocity = new Vector2(speed + PowerUpBoost, speed + PowerUpBoost);
        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine());
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        yield return new WaitForSeconds(speedBoostDuration);
        velocity = new Vector2(speed, speed);
    }
    
    void Update()
    {
        inputMovement = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")); 

    // Check for power-up collision
    Collider2D powerUpCollider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("PowerUp"));

    if (powerUpCollider != null)
    {
        // Apply speed boost and destroy power-up object
        ApplySpeedBoost();
        Destroy(powerUpCollider.gameObject);
    }
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