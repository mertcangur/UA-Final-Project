using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class gameFinish : MonoBehaviour
{
    AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        audioS.PlayOneShot(audioS.clip);
        StartCoroutine(finishedGame());
    }
    IEnumerator finishedGame()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("UI");
    }
}
