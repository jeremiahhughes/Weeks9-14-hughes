using NUnit.Framework;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class RandomFootsteps : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip[] footsteps;
    public ParticleSystem particles;
    public float speed = 5f;
    public Vector2 movement;
    public Vector2 direction;
    public CinemachineImpulseSource ImpulseSource;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        transform.eulerAngles = (Vector3)direction * speed * Time.deltaTime;
    }

    public void RandoFootsteps()
    {
        sfxSource.clip = footsteps[Random.Range(0,footsteps.Length)];
        sfxSource.Play();
        ImpulseSource.GenerateImpulse();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //public void OnDirection(InputAction.CallbackContext context)
    //{
    //    direction = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    //}
}
