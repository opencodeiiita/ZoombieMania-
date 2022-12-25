
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Shoot : MonoBehaviour
{
    public TextMeshProUGUI bulletsUI;
    private Transform playerTransform;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed =10f;
    public int maxAmmo = 20;
    private int currentAmmo;
    public float reloadTime = 5f;
    private bool isReloading = false;
    private float currentTime = 2.0f;

  
    void Start()
    { 
       currentAmmo = maxAmmo;
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
        currentTime -= Time.deltaTime;  


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            currentAmmo--;
            bulletsUI.text = currentAmmo.ToString();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            currentTime = 2.0f;
        }
        if(currentTime <=0)
        {
            currentAmmo = maxAmmo;
            bulletsUI.text = currentAmmo.ToString();
            currentTime = 2.0f;
        }
    }

    
}
