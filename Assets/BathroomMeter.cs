using UnityEngine;
using UnityEngine.UI;

public class BathroomMeter : MonoBehaviour
{
    public static BathroomMeter Instance;
    public Slider bathroomBar; // Assign this in the Inspector!
    private float bathroomLevel = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        // Auto-assign if not set manually
        if (bathroomBar == null)
        {
            bathroomBar = GameObject.Find("BathroomMeter").GetComponent<Slider>();
            if (bathroomBar == null)
                Debug.LogError("BathroomMeter: UI Slider 'BathroomMeter' not found! Assign it in Inspector.");
        }
    }
void Update()
{
    if (bathroomBar == null) return; // Prevents crashes if UI is missing

    float fillRate = 100f / 1200f; // Fill up evenly over 1200 seconds (20 minutes)
    bathroomLevel += Time.deltaTime * fillRate; // Adjusted fill rate
    bathroomBar.value = bathroomLevel;

    if (bathroomLevel >= 100)
    {
        Debug.LogWarning($"BathroomMeter triggered Game Over! BathroomLevel: {bathroomLevel} at {GameManager.Instance.gameTime} seconds left.");
        GameManager.Instance.GameOver();
    }
}


    public void ResetBathroomMeter()
    {
        bathroomLevel = 0;
    }
}
