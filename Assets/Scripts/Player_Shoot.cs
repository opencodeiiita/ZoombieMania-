using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public float rotationSpeed;
    float playerAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerAngle += Input.GetAxis("Mouse X") * rotationSpeed * -Time.deltaTime;
        playerAngle = Mathf.Clamp(playerAngle, 180, 360);
        transform.localRotation = Quaternion.AngleAxis(playerAngle, Vector3.up);
    }
}
