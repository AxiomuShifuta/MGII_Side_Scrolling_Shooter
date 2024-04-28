using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Wall : MonoBehaviour
{
    Rigidbody rb;
    public float wallSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(-wallSpeed,0f,0f);
    }
}
