using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forSword : MonoBehaviour
{

    bool canHit = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy") && canHit)
        {
            canHit = false;
            StartCoroutine(other.gameObject.GetComponent<enemyAI>().takeHit(50));
            StartCoroutine(attacckDelay());

        }
    }
    IEnumerator attacckDelay()
    {
        yield return new WaitForSeconds(2f);
        canHit = true;
        yield return null;
    }
}
