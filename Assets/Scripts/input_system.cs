using UnityEngine;
using UnityEngine.InputSystem;

public class input_system : MonoBehaviour
{  
       public bool fire;

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire ");
        if (context.started)
        {
            fire = true;
            Debug.Log("Fire Started");
        }
        if (context.performed)
        {
            fire = true;

        }
        if (context.canceled)
        {
            fire = false;
            Debug.Log("Fire Stop");
        }
    }
}
