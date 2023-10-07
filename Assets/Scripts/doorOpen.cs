using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public GameObject forAnim;
    Animator anim;


    private void Start()
    {
        anim = forAnim.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", true);
        }
    }
}
