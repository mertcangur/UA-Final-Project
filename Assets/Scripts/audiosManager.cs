using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosManager : MonoBehaviour
{
    public int health = 100;
    public AudioClip[] clips;
    private AudioSource audioS;
    private bool canStep = true;
    private bool is_left = true;
    

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    IEnumerator footStep(float speed)
    {
        canStep = false;
        if (is_left)
        {
            audioS.PlayOneShot(clips[0]);
            is_left = false;
        }
        else
        {
            audioS.PlayOneShot(clips[1]);
            is_left = true;

        }
        yield return new WaitForSeconds(speed);
        canStep = true;
        yield return null;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");



        float speed = Mathf.Abs(inputY) + Mathf.Abs(inputX);

        if(speed> 0 && canStep)
        {
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(footStep(0.4f));
            else
                StartCoroutine(footStep(0.7f));

        }

    }
    public void takeHit()
    {
        health -= 20;
        Debug.Log("Asuan Health = " + health);
    }
}
