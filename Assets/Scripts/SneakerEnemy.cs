using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakerEnemy : Controller_Enemy
{
    Rigidbody rb;
    public float stopPositionX;
    public float waitingTime;
    bool shooted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SneakerMovement());
    }

    // Update is called once per frame


    IEnumerator SneakerMovement()
    {
        while (transform.position.x < stopPositionX)
        {
            rb.AddForce(new Vector3(enemySpeed * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
            /*En principio quise moverlo a trav�s de rb.Velocity, pero no ten�a ning�n efecto.
            Desconozco por qu�*/
            yield return null;
        }

        rb.velocity = Vector3.zero;
        ShootPlayer();
        yield return new WaitForSeconds(waitingTime);

        while (transform.position.x > xLimit)
        {
            rb.AddForce(new Vector3( -enemySpeed * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
            yield return null;
        }

        /*La corrutina hace que el enemigo llegue hasta el punto de detenci�n (cuyo valor se
          especifica desde el inspector) para disparar, esperar dos segundos y retirarse.*/
    }

    public override void ShootPlayer()
    {
        if (transform.position.x >= stopPositionX && Controller_Player._Player != null && shooted == false)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            shooted = true;
        }
      /*Cuando alcanza la posici�n de detenci�n, se queda ah� dos segundos mientras lanza un disparo 
       y vuelve por donde ingres�.*/
    }
}
