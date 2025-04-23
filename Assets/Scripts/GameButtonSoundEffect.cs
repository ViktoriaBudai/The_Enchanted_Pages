using UnityEngine;

public class GameButtonSoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Button sound played successfully!");
        }
        else
        {
            Debug.LogError("AudioSource is not assigned.");
        }
    }
}
