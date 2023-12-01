using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrash = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !hasCrash)
        {
            hasCrash = true;
            FindObjectOfType<PlayerController>().DisabledControls(); 
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("reloadLevel", reloadDelay);
            
        }
    }

    void reloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
