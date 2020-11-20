using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathiing : MonoBehaviour
{

    [SerializeField] List<Transform> waypointsList;

    [SerializeField] WaveConfig waveConfig;

    [SerializeField] float enemyMoveSpeed = 2f;

    //Save the waypoint in which we want to go to
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypointsList = waveConfig.getWaypoints();

        //sets start position of enemy to 1st waypoint
        transform.position = waypointsList[waypointIndex].transform.position;

        print(waypointsList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
    }

    private void enemyMove()
    {
        if (waypointIndex <= waypointsList.Count)
        {
            //set targetPosition to the waypoint where we want to go
            var targetPosition = waypointsList[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = enemyMoveSpeed * Time.deltaTime;

            //move enemy from current position to target postion at enemy speed 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            //if enemy reaches target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        //if enemy reaches last position
        else
        {
            print(waypointIndex);
            Destroy(gameObject);
        }
    }
}
