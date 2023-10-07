using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forSword : MonoBehaviour
{
    public GameObject canDamage;
    bool sword;
    bool canHit = true;
    private void OnTriggerEnter(Collider other)
    {
        sword = canDamage.gameObject.GetComponent<WeaponController>().can_attack;
        
        if(other.CompareTag("enemy") && canHit && !sword)
        {
            canHit = false;
            StartCoroutine(other.gameObject.GetComponent<enemyAI>().takeHit(50));
            StartCoroutine(attacckDelay());

        }
    }
    IEnumerator attacckDelay()
    {
        yield return new WaitForSeconds(1f);
        canHit = true;
        yield return null;
    }
}
