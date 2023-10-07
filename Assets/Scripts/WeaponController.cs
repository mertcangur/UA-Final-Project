using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool can_attack = true;
    bool isStrafe = false ;
    Animator anim;
    private AudioSource audioS;

    public AudioClip slashClip;
    public GameObject handWeapon;
    public GameObject backWeapon;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }
    public IEnumerator slashAudio()
    {
        can_attack = false;
        yield return new WaitForSeconds(0.7f);
        audioS.PlayOneShot(slashClip);
        can_attack = true;
    }

    void Update()
    {
        anim.SetBool("iS", isStrafe);
        if(Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && isStrafe )
        {
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
