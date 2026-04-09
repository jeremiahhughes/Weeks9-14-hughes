using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Events;

public class AimSensor : MonoBehaviour
{
    // used an array here so i can put all the target transforms in that array
    public Transform[] targetTransform;
    public float LockOnDistance = 1;
    private Player scriptPlayer;
    public Transform currentTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scriptPlayer = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null || scriptPlayer.crosshair == null) return;
        Vector3 crosshairPosition = scriptPlayer.transform.position + (Vector3)scriptPlayer.aimDirection.normalized * scriptPlayer.crosshairDistance;
        scriptPlayer.isLocked = false;
        // Reference for foreach loop logic: https://discussions.unity.com/t/foreach-and-transform-parent/466222
        foreach (Transform t in targetTransform) // loops through every target in the array
        {
            // skips this if the target no longer exists
            if (!t.gameObject.activeInHierarchy || !t.GetComponent<SpriteRenderer>().enabled) 
                continue;
            // calculate distance between the stick's crosshair direction and target position
            float distanceToTarget = Vector2.Distance(crosshairPosition, t.position);
            // Check if distance is within the LockOnDistance threshold
            if (distanceToTarget < LockOnDistance)
            {
                // Lock crosshair to target and stop checking other targets
                scriptPlayer.isLocked = true;
                scriptPlayer.crosshair.position = t.position;
                currentTarget = t;
                TargetColor colorChange = t.GetComponent<TargetColor>();
                if (colorChange != null)
                {
                    colorChange.ChangeColorToRed();
                }
                break;
            }
            else
            {
                TargetColor colorChange = t.GetComponent<TargetColor>();
                if (colorChange != null)
                {
                    colorChange.ResetColor();
                }
            }
        }
    }
}
