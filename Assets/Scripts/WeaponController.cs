using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    float attackIndex;
    bool can_attack = true;
    bool isStrafe = false ;
    Animator anim;

    public GameObject handWeapon;
    public GameObject backWeapon;
    private void Start()
    {
        anim = GetComponent<Animator>();  
    }
    void Update()
    {
        anim.SetBool("iS", isStrafe);
        if(Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }
        if(Input.GetKeyDown(KeyCode.E) && isStrafe && can_attack)
        {
            anim.SetFloat("attackIndex", 5.0f);
            anim.SetTrigger("attack");
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && isStrafe && can_attack)
        {
            attackIndex = Random.Range(0, 3);
            anim.SetFloat("attackIndex", attackIndex);
            anim.SetTrigger("attack");
        }

        if(isStrafe)
        {
            GetComponent<Move>().hareketTipi = Move.MovementType.Strafe;
            GetComponent<IkLook>().azal();
        }
        if (!isStrafe)
        {
            GetComponent<Move>().hareketTipi = Move.MovementType.Directional;
            GetComponent<IkLook>().art();
        }

    }

    void equip()
    {
        backWeapon.SetActive(false);
        handWeapon.SetActive(true);
    }
    void unequip()
    {
        backWeapon.SetActive(true);
        handWeapon.SetActive(false);
    }
}
