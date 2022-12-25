
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent zombie;
    public Transform PlayerTarget;
    private int health = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        zombie.SetDestination(PlayerTarget.position);

    }
    private void OnCollisionEnter(Collision collision)
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
