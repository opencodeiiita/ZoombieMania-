using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xdir = Input.GetAxis("Horizontal");
        float zdir = Input.GetAxis("Vertical");
        Vector3 movedir = new Vector3( xdir,0.0f, zdir );
        transform.position += movedir * speed * Time.deltaTime;
    }
}
