using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finisEffect;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            finisEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("reloadLevel", reloadDelay);
        }
    }
    void reloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
 