using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Move : MonoBehaviour
{
    [Header("Metrics")]
    public float rotationSpeed;
    [Range(1, 20)]
    public float damp;
    [Range(1, 20)]
    public float StrafeTurnSpeed;

    float normalFov;
    public float sprintFov;
    float inputX;
    float inputY;
    float maxSpeed;

    Animator anim;    
    Vector3 StickDirection;
    Camera mainCam;

    public Transform Model;
    public KeyCode SprintButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;
    public enum MovementType
    {
        Directional,
        Strafe
    };
    public MovementType hareketTipi;

    void Start()
    {
       
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;

    }

    private void LateUpdate()
    {

        InputMove();
        InputRotation();
        Movement();
    }

    void Movement()
    {

        if(hareketTipi == MovementType.Strafe)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            anim.SetFloat("iX", inputX, damp, Time.deltaTime * 10);
            anim.SetFloat("iY", inputY, damp, Time.deltaTime * 10);
            anim.SetBool("strafeMoving", true);

            var hareketEdiyor = inputX != 0 || inputY != 0;
            if(hareketEdiyor)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), StrafeTurnSpeed * Time.fixedDeltaTime);
                anim.SetBool("strafeMoving", true);

            }
            else
            {
                anim.SetBool("strafeMoving", false);
            }

        }
        if (hareketTipi == MovementType.Directional)
        {
            //inputX = Input.GetAxis("Horizontal");
            //inputY = Input.GetAxis("Vertical");
            StickDirection = new Vector3(inputX, 0, inputY);

            if (Input.GetKey(SprintButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);
                maxSpeed = 2;
                inputX = 2 * Input.GetAxis("Horizontal");
                inputY = 2 * Input.GetAxis("Vertical");
            }
            else if (Input.GetKey(WalkButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 1f;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }
            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                maxSpeed = 0.2f;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }
        }


    }
    void InputMove()
    {
        anim.SetFloat("speed",Vector3.ClampMagnitude(StickDirection, maxSpeed).magnitude, damp ,Time.deltaTime * 10);
    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;
        Model.forward = Vector3.Slerp(Model.forward,rotOfset,Time.deltaTime * rotationSpeed);
    }
}
