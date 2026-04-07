using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector2 aimDirection;
    public Transform crosshair;
    public float crosshairDistance = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handles Movment
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        // Handles Aim Input
        if (crosshair != null)
        {
            crosshair.position = transform.position + new Vector3(aimDirection.x, aimDirection.y, 0) * crosshairDistance;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 stickInput = Gamepad.current.rightStick.ReadValue();
        if (stickInput.magnitude > 0.1f)
        {
            aimDirection = stickInput;
        }
    }
}
