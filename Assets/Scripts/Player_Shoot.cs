
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    private Transform playerTransform;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed =10f;
 

  
    void Start(){
      
    }
   
    void Update()
    {   
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position , bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        
        }
        
        
    }

    
}
