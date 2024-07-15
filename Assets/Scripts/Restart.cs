using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Restart : MonoBehaviour
{
    public AudioMixerSnapshot startSnapshot;
    public Controller_Player playerController;


    private void Start()
    {

    }


    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerController.musicCount = 0;
            startSnapshot.TransitionTo(0f); 
            Controller_Player._Player.gameObject.SetActive(true);

        }
        
        /*Si corro esta variable acá, el restart funciona bien luego del Game Over.
         Sin embargo, además de no entender bien por qué, no me convence que quede
        independiente del if del input, porque implicaría que esa variable se asigna
        sí o sí en cada frame y desconozco las consecuencias que podría traer en
        otro escenario. Me llama la atención que si directamente está declarada, el reinicio
        tampoco funcione y recuerdo que en otras oportunidades en las que utilicé la carga
        de escena, no hizo falta.*/
    }
}
