using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
    //the enemy to spawn
    [SerializeField] GameObject enemyPrefab;
    //the path on which the enemy will move
    [SerializeField] GameObject pathPrefab;

    //time between each enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //random difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in wave
    [SerializeField] int numberOfEnemies = 5;
    //enemy move speed
    [SerializeField] float enemyMoveSpeed = 2f;

    //encapsulation methods
   public GameObject getEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> getWaypoints()
    {
        //each wave can have a different number of waypoints
        var waveWaypoints = new List<Transform>();

        //go into path prefab and for each child, add it to the List
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float getSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float getEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
