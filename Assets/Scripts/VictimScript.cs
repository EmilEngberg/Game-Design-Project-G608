using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimScript : MonoBehaviour
{
    //Placeholder for new position
    private Vector3 newPosition;
    //Boolean to keep movement change from right to left
    private bool changeDirection;

    //Movement measured in lenght
    public float movement = 0.1f;
    //Waiting time between each movement
    public float waitingTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {   
        //Starts the movement or "shaking" of each victim
        StartCoroutine(ShakeVictim());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to make the victims move
    private IEnumerator ShakeVictim()
    {
        //Makes sure the corutine keeps going
        while (true)
        {
            //If else statement that changes the direction each time it is called
            if (changeDirection == true)
            {
                //Moves the victim to the right
                newPosition = transform.position + new Vector3(movement, 0f, 0f);
            }
            else
            {
                //Moves the victim to the left
                newPosition = transform.position + new Vector3(-movement, 0f, 0f);
            }

            //Assigns the new position
            transform.position = newPosition;

            //Waits to keep the "animation" look better
            yield return new WaitForSeconds(waitingTime);

            //Switches between right and left
            changeDirection = !changeDirection;
        }

    }
}
