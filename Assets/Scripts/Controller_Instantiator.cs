using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public float enemiesTimer=7;

    public float wallsTimer;

    public  List<GameObject> enemies;

    public GameObject wall;

    public GameObject instantiatePos;

    private float time = 0;

    private int multiplier = 20;

    void Start()
    {
        wallsTimer = 1;
    }

    void Update()
    {
        enemiesTimer -= Time.deltaTime;
        wallsTimer -= Time.deltaTime;
        SpawnEnemies();
        ChangeVelocity();
        SpawnWalls();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        if (time > multiplier)
        {
            multiplier *= 2;
            //Increase velocity
        }
    }

    private void SpawnEnemies()
    {
        if (enemiesTimer <= 0)
        {
            float offsetX = instantiatePos.transform.position.x;
            int rnd = UnityEngine.Random.Range(0, enemies.Count);
            for (int i = 0; i < 5; i++)
            {
                offsetX = offsetX + 4;
                Vector3 transform = new Vector3(offsetX, instantiatePos.transform.position.y, instantiatePos.transform.position.z);
                Instantiate(enemies[rnd], transform,Quaternion.identity);
            }
            enemiesTimer = 7;
        }
    }

    private void SpawnWalls()
    {
        if (wallsTimer <= 0)
        {
            Instantiate(wall, transform.position - new Vector3(50f,12f,0f),wall.transform.rotation);
            wallsTimer = 5;
        }
    }
}
