using System.Net.Http;
using System.Net.WebSockets;
using System.Net;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Shoot : MonoBehaviour
{   public Camera tppCam;
    public TextMeshProUGUI bulletsUI;
    private Transform playerTransform;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed =10f;
    public float fireRate;
    private float time=0f;
    private float nextTimeFire;
    public int maxAmmo = 20;
    private int currentAmmo;
    public float reloadTime = 5f;
    private bool isReloading = false;
    private float currentTime = 2.0f;
    input_system _input;

  
    void Start()
    { 
       currentAmmo = maxAmmo;
       _input = GetComponent<input_system>();
    }
   
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        shoot();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading......");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo =  maxAmmo;
        isReloading = false;


    }

    void shoot()
    {   
      
       time += Time.deltaTime;

       nextTimeFire = 1/fireRate;

        currentTime -= Time.deltaTime;  


        if ( _input.fire && time >= nextTimeFire )
        {  
            RaycastHit hit;
            Physics.Raycast(tppCam.transform.position , tppCam.transform.forward , out hit );
           
            
            currentAmmo--;
            bulletsUI.text = currentAmmo.ToString();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = (hit.point - bulletSpawnPoint.position).normalized * bulletSpeed;
            currentTime = 2.0f;
            time =0f;
        }
        if(currentTime <=0)
        {   
            Debug.Log(currentAmmo);
            currentAmmo = maxAmmo;
            bulletsUI.text = currentAmmo.ToString();
            currentTime = 2.0f;
        }
    }

    
}
