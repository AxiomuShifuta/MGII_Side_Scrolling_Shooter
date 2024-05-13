using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float xLimit = 30; //No coincidía con el valor en el inspector, el cual figuraba en 20.
    public float yLimit = 20;
    
    virtual public void Update()
    {
       // CheckLimits();
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
            if(collider.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
    }


    internal virtual void CheckLimits()
    {
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y < -yLimit)
        {
            Destroy(this.gameObject);
        }

    }

}
