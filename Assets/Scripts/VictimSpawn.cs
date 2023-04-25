using UnityEngine;

public class VictimSpawn : MonoBehaviour
{
    public GameObject[] victimsToSpawn; // The object to be spawned  

    public int numberOfVictims = 5; //Number of victims to spawn
    public int minIndexX = -11; // The minimum index of the spawn points array on X axis
    public int maxIndexX = 11; // The maximum index of the spawn points array on X axis
    public int minIndexY = 8; // The minimum index of the spawn points array on Y axis
    public int maxIndexY = -6; // The maximum index of the spawn points array on Y axis
    

    public void Start()
    {
        //Spawn X number of victims on start
        for (int i = 0; i < numberOfVictims; i++)
        {   
            
            SpawnObject(victimsToSpawn[Random.Range(0, victimsToSpawn.Length)]);

        }
    }



    public void Update()
    {
        
    }

    public void SpawnObject(GameObject objectToSpawn) //Function to sapwn a victim
    {   
        int safety = 0; //Number that secures the while loop stops

        //Creates random spawnpoint to spawn the victim at
        Vector2 randomSpawnPoint = new Vector2((int)Random.Range(minIndexX, maxIndexX + 1), (int)Random.Range(minIndexY, maxIndexY + 1));
        
        //Gets the victims collider
        //Vector3 boxSize = objectToSpawn.GetComponent<BoxCollider2D>().bounds.size;
        
        Vector2 boxSize = objectToSpawn.GetComponent<BoxCollider2D>().bounds.size;

        //Check if the victim is colliding with any other object
        //If not it tries to find a new spot
        while (Physics2D.OverlapBox(randomSpawnPoint, boxSize, 0f, LayerMask.GetMask("Obstacle")) != null && safety < 100)
        {
            randomSpawnPoint = new Vector2((int)Random.Range(minIndexX, maxIndexX + 1), (int)Random.Range(minIndexY, maxIndexY + 1));
            safety++; //When safety reaches 100 the object is spawned regardless. Should not be a problem as long as there is only 5-10 victims
        }
      

        //Instantiates the victim
        Instantiate(objectToSpawn, randomSpawnPoint, Quaternion.identity);
    }



}




