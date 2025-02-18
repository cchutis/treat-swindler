using UnityEngine;

public class BarkSystem : MonoBehaviour
{
    public static BarkSystem Instance; // Singleton Reference
    public AudioSource audioSource;
    public AudioClip barkSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set instance
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void Bark()
    {
        if (audioSource != null && barkSound != null)
        {
            audioSource.PlayOneShot(barkSound);
        }
        else
        {
            Debug.LogError("BarkSystem: Missing AudioSource or Bark Sound!");
        }
    }
}
