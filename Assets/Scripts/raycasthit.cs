
using UnityEngine;

public class raycasthit : MonoBehaviour
{
    public Camera tppCam;
    public Transform debugTransform;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(tppCam.transform.position, tppCam.transform.forward, out hit, 100f))
        {
           debugTransform.position = hit.point;
        }
    }
}
