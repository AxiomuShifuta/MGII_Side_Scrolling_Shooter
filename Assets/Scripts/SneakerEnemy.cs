using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakerEnemy : Controller_Enemy
{
    Rigidbody rb;
    public float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnTimer = 5f;
    }

    // Update is called once per frame
   override public void Update()
    {
        spawnTimer -= Time.deltaTime;
    }

    public void Spawn()
    {
        if(spawnTimer >= 0)
        {
            if(Random.Range(0,5) == 1)
            Instantiate(this, new Vector3(-30, 15, 0), Quaternion.identity);
        }
        spawnTimer = 5;
    }
}
