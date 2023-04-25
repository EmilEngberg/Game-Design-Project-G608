using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
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
}