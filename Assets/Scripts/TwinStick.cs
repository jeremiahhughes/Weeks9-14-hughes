using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStick : MonoBehaviour
{
    public float speed = 10;
    public Vector2 movement;
    public Vector2 direction;
    public bool isRotating;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        transform.eulerAngles = (Vector3)direction * speed * Time.deltaTime;
        //transform.position = movement;
    }

    public void OnMovie(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnDirection(InputAction.CallbackContext context)
    {
        direction = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void SetRotation(float angle)
    {
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
