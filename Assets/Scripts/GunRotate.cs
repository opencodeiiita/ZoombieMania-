
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{   public Camera tppCam;
    public Transform bulletSpawnPoint;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(tppCam.transform.position, tppCam.transform.forward, out hit))
    {
       transform.LookAt(hit.point, Vector3.right);
     }

    }
}
