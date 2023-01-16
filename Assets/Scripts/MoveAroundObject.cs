
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 3.0f;
    public float _adsMouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;
    
    [SerializeField]
    public float _CameraZoom = 3.0f;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;
    private float _shoulderDistance; 
    public float zoomShoulderDistance   = 3.0f; 
    public float _defaultShoulderDistance = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);
    
    void Start(){
        _shoulderDistance =_defaultShoulderDistance;
    }
   
    void Update()
    {   
        float mouseX,mouseY;
        if (Input.GetMouseButton(1)){
           mouseX = Input.GetAxis("Mouse X") * _adsMouseSensitivity;
           mouseY = Input.GetAxis("Mouse Y") * _adsMouseSensitivity;
        }
        else{
           mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
           mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;
        }
        

        _rotationY += mouseX;
        _rotationX -= mouseY;

       
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

       
        transform.position = _target.position - transform.forward * _distanceFromTarget - transform.right * _shoulderDistance;
        
        if (Input.GetMouseButton(1)) // right-click held down
    {
        _shoulderDistance = Mathf.Lerp(_shoulderDistance, zoomShoulderDistance, Time.deltaTime * 5); 
    }
    else
    {
        _shoulderDistance = Mathf.Lerp(_shoulderDistance, _defaultShoulderDistance, Time.deltaTime * 5); 
    }
    }
       
    }
