
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{ 
    [SerializeField] GameObject[] goThere;
    int nextgoThere = 0;

    [SerializeField] float speed = 0.01f; 
   
    void Update()
    {
         if( Vector3.Distance(transform.position , goThere[nextgoThere].transform.position) < 0.1f){
            nextgoThere++;
            if(nextgoThere >= goThere.Length){
                nextgoThere = 0;
            }
         }
         transform.position = Vector3.MoveTowards(transform.position, goThere[nextgoThere].transform.position,speed);
    }
}
