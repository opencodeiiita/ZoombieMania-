using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{    
    public CharacterController controller;
    public Vector3 moveVector;
    [SerializeField]
    private float playerAcceleration = 5f;
    public float playerMaxSpeed = 5f;
    public float playerDeceleration = -5f;
    public float forwardSpeed = 0f;

    private float lastTime = 0f;
    public float gravity = -9.8f;

    [SerializeField]
    LayerMask ground;

    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private Camera followCamera;

    private float playerhealth = 10;
    public Slider slider;
  

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        controller = GetComponent<CharacterController>();    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        slider.value = 10;
    }

    private void Update() 
    {   
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");
        Movement();
        slider.value =  playerhealth;
     

    }

    void Movement() 
    {
        float t = Time.time - lastTime;
        lastTime = Time.time;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        if(moveVector == Vector3.zero){
                   
            forwardSpeed  += t * playerDeceleration;
            forwardSpeed = Mathf.Max(0,forwardSpeed);

        }
        
        else{        
            forwardSpeed  += t * playerAcceleration;
            forwardSpeed = Mathf.Min(playerMaxSpeed,forwardSpeed);
        }

       

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput,0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        if (movementDirection != Vector3.zero)
        {

            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


        controller.Move(movementDirection * forwardSpeed * Time.deltaTime);

        if(!IsGrounded()){
            controller.Move(Vector3.up * gravity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Enemy"))
        {
            playerhealth = playerhealth-0.1f;
        }
          
       
    }

    bool IsGrounded(){
        return Physics.CheckSphere(transform.position, .1f , ground);
    }
}