
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    Player_Movement moveScript;
    
    public float dashSpeed;
    public float dashTime;
    public float dashCd;
    private float dashCdTimer;
    
    void Start()
    {
        moveScript = GetComponent<Player_Movement> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            StartCoroutine(Dash());
        }
        if(dashCdTimer >0){
            dashCdTimer -= Time.deltaTime;
        }
    }

    IEnumerator Dash()
    {    
        if(dashCdTimer>0) yield break;
        else dashCdTimer = dashCd;
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {  
            if(moveScript.moveVector == Vector3.zero){
                
                moveScript.controller.Move(transform.right* dashSpeed *Time.deltaTime);
            }
            else{
            moveScript.controller.Move(moveScript.moveVector * dashSpeed *Time.deltaTime);
            }
            yield return null;
        }
        
    }
}
