using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI messageText; // UI Text element for displaying messages
    public GameObject promptPanel; // UI panel for showing prompts

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowPrompt(string message)
    {
        promptPanel.SetActive(true);
        messageText.text = message;
    }

    public void HidePrompt()
    {
        promptPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        Invoke("ClearMessage", 2f); // Clears the message after 2 seconds
    }

    private void ClearMessage()
    {
        messageText.text = "";
    }
}
