using UnityEngine;

public class ButtonSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Method to play the sound effect
    public void PlaySound()
    {
        audioSource.Play();
    }
}
