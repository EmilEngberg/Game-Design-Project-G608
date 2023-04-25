using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cred: https://www.youtube.com/watch?v=-V1O5FGQVY8&ab_channel=SmartPenguins

public class PickUp : MonoBehaviour
{
    // location of pot when holding it
    public Transform holdSpot;
    // filter the objects that are just in the layer mask pick up
    public LayerMask pickUpMask;
    public LayerMask safeZone;
    // which direction is the player facing
    public Vector3 Direction {get; set;}
    // store the game object so we can access it when we need to drop it
    private GameObject itemHolding;

    private GameObject scoreManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //check if an item is being held
            if(itemHolding)
            {
                // logic for dropping the item
                // item is placed in front of the player:
                itemHolding.transform.position = transform.position + Direction;
                // remove item from the player
                itemHolding.transform.parent = null;

                if (Physics2D.OverlapCircle(transform.position + Direction, .4f, safeZone))
                {                
                        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
                        //Adds a point if the Victim is within the safezone
                        scoreManager.GetComponent<ScoreManager>().AddPoints();
                        //Destroys the item, so the player cant get infinite points  
                        Destroy(itemHolding);

                }

                //check for rigidbody --> set simulated to true 
                if (itemHolding.GetComponent<Rigidbody2D>())
                 {
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                 }

                //clear the item holding the game object:
                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                // logic for pick up the item
                // if there is an item we can pick up then:
                if (pickUpItem)
                {
                    //store it
                    itemHolding = pickUpItem.gameObject; 
                    // change the pos of the item to the holding spot
                    itemHolding.transform.position = holdSpot.position; 
                    //set the parent of that item to our player
                    itemHolding.transform.parent = transform;
                    //check if we have a rigidbody2D
                    if (itemHolding.GetComponent<Rigidbody2D>())
                    {
                        // simulated has to be false, otherwise object wont follow player
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;

                    }
                }
            
            }

        }
    }

}
