using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTimer = 5.0f;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnenemy());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator Spawnenemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }   
    }
}
