﻿
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyStart))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private EnemyStart enemy;

    void Start()
    {
    	enemy = GetComponent<EnemyStart>();

    	target = Waypoints.points[0];
    }

    void Update()
    {
    	Vector3 dir = target.position - transform.position;
    	transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

    	if(Vector3.Distance(transform.position, target.position) <= 0.15f)
    	{
    		GetNextWaypoint();
    	}

    	enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
    	if(wavepointIndex >= Waypoints.points.Length - 1)
    	{
    		EndPath();
    		return;
    	}
    	wavepointIndex++;
    	target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);

    }
}
