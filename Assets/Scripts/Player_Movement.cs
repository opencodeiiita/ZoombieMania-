
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{    
    public CharacterController controller;
    public Vector3 moveVector;
    [SerializeField]
    private float playerSpeed = 5f;

    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private Camera followCamera;

    private float playerhealth = 10;
    public Slider slider;
  

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
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
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        controller.Move(movementDirection * playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero) 
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Enemy"))
        {
            playerhealth = playerhealth-0.1f;
        }

    }
}