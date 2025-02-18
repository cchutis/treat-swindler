using UnityEngine;
using TMPro; // For TextMeshPro UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime = 1200f; // 20-minute timer
    public TMP_Text timerText; // Assign this in the Inspector
    private bool gameEnded = false; // Prevents multiple GameOver calls
    private float startTime; // Stores the starting time

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        startTime = Time.time; // Store the starting game time
        gameTime = 1200f; // Ensures timer is set correctly

        if (timerText == null)
        {
            GameObject foundTimer = GameObject.Find("Timer");
            if (foundTimer != null)
            {
                timerText = foundTimer.GetComponent<TMP_Text>();
            }
        }
    }

    void Update()
    {
        if (gameEnded) return; // Stop updating if the game is over

        // Calculate time based on the actual time elapsed since the game started
        gameTime = 1200f - (Time.time - startTime);

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        timerText.text = $"Time Left: {minutes:D2}:{seconds:D2}";

        if (gameTime <= 0.01f)
        {
            gameTime = 0;
            GameOver();
        }
    }

    public void GameOver()
    {
        if (gameEnded) return; // Prevent multiple calls
        gameEnded = true;

        // OPTIONAL: Disable player movement after game over
        if (BellaController.Instance != null)
        {
            BellaController.Instance.enabled = false;
        }
    }
}
