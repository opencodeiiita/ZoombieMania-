
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent zombie;
    private Transform PlayerTarget;
    private int health = 5;
    private Animator zombieAnim;
    
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
        zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        zombie.SetDestination(PlayerTarget.position);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if (health <= 0)
            {
                zombieAnim.SetBool("Death", true);
                Destroy(gameObject, 2);
            }
            else{
                health-- ;
            }
        }
    }
}
