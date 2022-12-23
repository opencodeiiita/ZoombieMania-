
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour

{ 
    public CharacterController controller;
    public float speed = 1f;
    public Vector3 moveVector;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");
        controller.Move (moveVector * speed * Time.deltaTime);
    }
}
