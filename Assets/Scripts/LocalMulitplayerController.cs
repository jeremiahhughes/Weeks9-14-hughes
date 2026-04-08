using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMulitplayerController : MonoBehaviour
{
    public LocalMultiplayerManager manager;
    public float speed = 5;
    public Vector2 movementInput;
    public PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player" + playerInput.playerIndex + ": Attacking!");
            manager.playerAttacking(playerInput);
        }
    }
}
