using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    Animator anim;

    public Transform target;

    public Transform attackRange;

    NavMeshAgent agent;

    public float distance;

    bool canChange = true;

    int health = 100;

    public ParticleSystem blood;

    AudioSource audioS;

    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        
        if (distance < 2)
        {
            if(canChange)
                agent.isStopped = true;
            anim.SetFloat("speed", 0f); 
            anim.SetBool("attack", true);
        }
        else if(distance > 2 && distance < 15)
        {
            if(canChange)
                agent.isStopped = false;
            anim.SetFloat("speed", agent.velocity.magnitude); 
            anim.SetBool("attack", false);
            agent.SetDestination(target.position); 
        }
        if(health <= 0)
        {
            canChange = false;
            agent.isStopped = true;
            anim.SetTrigger("death");
            Invoke(nameof(isDeath), 1f);
            isDeath();
        }
    }
    public IEnumerator takeHit(int damage)
    {
        canChange = false;
        agent.isStopped = true;
        anim.SetTrigger("take damage");
        blood.Play();
        yield return new WaitForSeconds(1f);
        health -= damage;
        agent.isStopped = false;
        canChange = true;
    }
    public void attackRay()
    {

        RaycastHit hit;
        if (Physics.Raycast(attackRange.position, transform.forward, out hit, 4.0f))
        {
            if(hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<audiosManager>().takeHit();
            }
        }
    }
    void isDeath()
    {
        CapsuleCollider col;
        col = gameObject.GetComponent<CapsuleCollider>();
        col.enabled = false;
    }
    public void deathAudio()
    {

        audioS.PlayOneShot(clip);
    }
}
