using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variables
    public float speed = 5; // player speed
    public Vector2 movement; // store movement input on the left stick
    public Vector2 aimDirection; // store aiming input on the right stick
    public Transform crosshair; // reference to crosshair sprite in scene
    public float crosshairDistance = 2; // distance crosshair is from the player
    public bool isLocked = false; // used to prevent stick input from moving when the crosshair is over the target
   
    // Update is called once per frame
    void Update()
    {
        // Handles Movment
        transform.position += (Vector3)movement * speed * Time.deltaTime; // changes player positon based on movement vector, speed, and time
        // Handles Aim Input
        if (crosshair != null && !isLocked) // updates crosshair position relative to the player if no lock is active
        {
                crosshair.position = transform.position + (Vector3)aimDirection.normalized * crosshairDistance; 
        }
    }

    // this controls player movement with left stick through player move input event also got this from reading 9.0 Input Actions at timestamp 21:39
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    // this controls crosshair movement with right stick through player look input event
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 stickInput = Gamepad.current.rightStick.ReadValue(); //reads right stick values from the controller
        if (stickInput.magnitude > 0.1f) // updates the aim direction to the stick movement
        {
            aimDirection = stickInput;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started && isLocked)
        {
            AimSensor sensor = GetComponent<AimSensor>();

            if(sensor.currentTarget != null)
            {
                GetComponent<TargetParticle>().SpawnEffect(sensor.currentTarget);
                GameObject targetToDestroy = sensor.currentTarget.gameObject;

                sensor.currentTarget = null;
                isLocked = false;

                Destroy(targetToDestroy);
            }
        }
    }
}
