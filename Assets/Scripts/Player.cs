using TMPro;
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
    public int score = 0;
    public TextMeshProUGUI scoreText;
   
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
                // spawns particles
                GetComponent<TargetParticle>().SpawnEffect(sensor.currentTarget);

                score++;
                UpdateScoreUI();
                // triggers the coruotine on the target
                TargetColor targetscript = sensor.currentTarget.GetComponent<TargetColor>();
                if(targetscript != null)
                {
                    targetscript.StartRespawn();
                }
                // unlocks the players right stick so they can aim at another target
                sensor.currentTarget = null;
                isLocked = false;
            }
        }
    }
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
