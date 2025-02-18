using UnityEngine;

public class BackDoor : MonoBehaviour
{
    private bool isBellaNear = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Bella enters trigger area
        {
            isBellaNear = true;
            UIManager.Instance.ShowPrompt("Press [Bark] to ask Mom to open the door."); // Show UI Prompt
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Bella leaves trigger area
        {
            isBellaNear = false;
            UIManager.Instance.HidePrompt(); // Hide UI Prompt
        }
    }

    void Update()
    {
        if (isBellaNear && Input.GetKeyDown(KeyCode.Space)) // Bella barks
        {
            AttemptToOpenDoor();
        }
    }

    void AttemptToOpenDoor()
    {
        if (SuspicionSystem.Instance.GetSuspicionLevel() >= 80) // High suspicion = no response
        {
            UIManager.Instance.ShowMessage("Mom ignores Bella..."); // Show message
            return;
        }

        MomAI.Instance.ReactToBark(); // Mom decides whether to watch or ignore
    }
}
