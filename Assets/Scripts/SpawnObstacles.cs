using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    //public GameObject obstacle;
    //public float maxX;
    //public float minX;
    //public float maxY;
    //public float minY;
    [SerializeField]
    public Obstacle[] obstacles;
    public float timeBetweenSpawnStart;
    public float timeBetweenSpawnEnd;
    private float spawnTime;
    private float removeTime;
    public float timeBetweenRemove;
    List<GameObject> spawnList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameFinished || GameManager.GameStarted == false) return;
        if(Time.time > spawnTime)
        {
            var randomObstacleId = Random.Range(0,obstacles.Length);
            Spawn(obstacles[randomObstacleId]);
            var timeBetweenSpawn = Random.Range(timeBetweenSpawnStart, timeBetweenSpawnEnd);
            spawnTime = Time.time + timeBetweenSpawn;
        }
        var spawnedObject = spawnList.FirstOrDefault();
        if (spawnedObject != null && spawnedObject.transform?.position.x  < (this.transform.position.x -30))
        {
            var el = spawnList[0];
            spawnList.RemoveAt(0);
            Destroy(el);

            removeTime = Time.time + timeBetweenRemove;
        }
    }
    void Spawn(Obstacle obstacle)
    {
        float randomX = Random.Range(obstacle.minX, obstacle.maxX);
        float randomY = Random.Range(obstacle.minY, obstacle.maxY);

        spawnList.Add(Instantiate(obstacle.enemyPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation));

    }
}
