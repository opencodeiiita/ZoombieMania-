
using UnityEngine;
using UnityEngine.InputSystem;

public class input_system : MonoBehaviour
{  
       public bool fire;
   
       public void OnFire(InputAction.CallbackContext context)
       {
              if(context.started){
                fire = true;
              }
              if(context.performed){
                fire = true;
              }
              if(context.canceled){
                fire = false;
              }

       }
}
