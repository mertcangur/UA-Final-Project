using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAudio : MonoBehaviour
{
    AudioSource audioS;
    void Start()
    {
        audioS = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ship"))
        {
            audioS.PlayOneShot(audioS.clip);
        }
    }
}
