using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomFOV = 20f; // adjust as needed

    private float defaultFOV;
  

    void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // right-click held down
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, Time.deltaTime * 5); 
    }
    else
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, Time.deltaTime * 5); 
    }
    }
}
