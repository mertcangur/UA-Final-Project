using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camTurn : MonoBehaviour
{
    AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void firstScence()
    {
        audioS.PlayOneShot(audioS.clip);
        //SceneManager.LoadScene();
    }

    public void toOption()
    {
        audioS.PlayOneShot(audioS.clip);
        Debug.Log("pressed to option");
    }

    public void toExit()
    {
        audioS.PlayOneShot(audioS.clip);
        Debug.Log("pressed to exit");

    }


}
