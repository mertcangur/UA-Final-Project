using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camTurn : MonoBehaviour
{
    AudioSource audioS;
    bool isPlayed = true;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void firstScence()
    {
        if(isPlayed)
            audioS.PlayOneShot(audioS.clip);
        isPlayed = false;
        SceneManager.LoadScene("firstLevel");
    }

    public void toOption()
    {
        audioS.PlayOneShot(audioS.clip);
        //Debug.Log("pressed to option");
    }

    public void toExit()
    {
        audioS.PlayOneShot(audioS.clip);
        Application.Quit();

    }


}
