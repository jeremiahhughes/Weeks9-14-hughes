using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStick : MonoBehaviour
{
    public float speed = 10;
    public Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        //transform.position = movement;
    }

    public void OnMovie(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
