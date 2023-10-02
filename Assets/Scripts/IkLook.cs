using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkLook : MonoBehaviour
{
    Animator anim;
    float weight = 1;
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;

    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weight, .5f, 1.2f, .5f, .5f);

        Ray lookAtRay = new Ray(transform.position, mainCam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }
    public void art()
    {
        weight = Mathf.Lerp(weight, 1f, Time.deltaTime);
    }
    public void azal()
    {
        weight = Mathf.Lerp(weight, 0f, Time.deltaTime);
    }
}
