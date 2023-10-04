using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    Animator anim;

    public Transform target;

    NavMeshAgent agent;

    public float distance;

    bool canChange = true;

    int health = 100;


    // Start is called before the first frame update
    void Start()
    {
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
        else
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
        }
    }
    public IEnumerator takeHit(int damage)
    {
        canChange = false;
        agent.isStopped = true;
        anim.SetTrigger("take damage");
        yield return new WaitForSeconds(1f);
        health -= damage;
        agent.isStopped = false;
        canChange = true;
    }
}
