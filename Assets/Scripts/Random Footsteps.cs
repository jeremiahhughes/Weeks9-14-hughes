using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class RandomFootsteps : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip[] footsteps;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandoFootsteps()
    {
        sfxSource.clip = footsteps[Random.Range(0,footsteps.Length)];
        sfxSource.Play();

    }
}
