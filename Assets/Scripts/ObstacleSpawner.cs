using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle; // The object to be spawned  

    public int numberOfObstacles; //Number of victims to spawn
    public int minIndexX = -11; // The minimum index of the spawn points array on X axis
    public int maxIndexX = 11; // The maximum index of the spawn points array on X axis
    public int minIndexY = 8; // The minimum index of the spawn points array on Y axis
    public int maxIndexY = -6; // The maximum index of the spawn points array on Y axis


    public void Start()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            SpawnObject(obstacle);

        }
    }

    public ObstacleSpawner(GameObject obstacle, int numberOfObstacles)
    {
        this.obstacle = obstacle;
        this.numberOfObstacles = numberOfObstacles;
    }



    public void Update()
    {

    }

    public void SpawnObject(GameObject objectToSpawn)
    {
        int safety = 0;
        Vector3 randomSpawnPoint = new Vector3((int)Random.Range(minIndexX, maxIndexX + 1), (int)Random.Range(minIndexY, maxIndexY + 1), 0);

        Vector3 boxSize = objectToSpawn.GetComponent<BoxCollider>().bounds.size;

        while (Physics.CheckBox(randomSpawnPoint, boxSize, Quaternion.identity) && safety < 100)
        {
            randomSpawnPoint = new Vector3((int)Random.Range(minIndexX, maxIndexX + 1), (int)Random.Range(minIndexY, maxIndexY + 1), 0);
            safety++;
        }

        Instantiate(objectToSpawn, randomSpawnPoint, Quaternion.identity);

    }
}




