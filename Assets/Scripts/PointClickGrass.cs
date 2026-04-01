using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using System.Collections;
public class PointClickGrass : MonoBehaviour
{
    public Vector2 targetPos;
    public Vector2 movement;
    public float speed = 5;
    public AudioSource sfxSource;
    public AudioClip[] footsteps;
    public Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform.localPosition = Vector2.zero;
        StartCoroutine(PointMove());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        //transform.position = movement;
    }

    public void RandoFootsteps()
    {
        sfxSource.clip = footsteps[Random.Range(0, footsteps.Length)];
        sfxSource.Play();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnPoint (InputAction.CallbackContext context)
    {
        targetPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnClick (InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse was pressed!");
            movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            //transform.position += (Vector3)movement * speed * Time.deltaTime;
        }
    }

    IEnumerator PointMove()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            playerTransform.localPosition = Vector2.one * t;
            yield return null;
        }
    }
}
