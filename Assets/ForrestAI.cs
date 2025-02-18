using UnityEngine;

public class ForrestAI : MonoBehaviour
{
    public static ForrestAI Instance; // Singleton Instance

    public Transform[] restingSpots; // Assign these in the Inspector
    private Transform currentSpot;
    private int barkCount = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject); // Prevent duplicate instances
    }

    void Start()
    {
        if (restingSpots.Length == 0)
        {
            Debug.LogError("ForrestAI: No resting spots assigned! Add them in the Inspector.");
            return;
        }

        MoveToRandomSpot();
    }

    void MoveToRandomSpot()
    {
        if (restingSpots.Length == 0)
        {
            Debug.LogWarning("ForrestAI: No resting spots available to move to.");
            return;
        }

        currentSpot = restingSpots[Random.Range(0, restingSpots.Length)];

        if (currentSpot == null)
        {
            Debug.LogError("ForrestAI: Chosen resting spot is null!");
            return;
        }

        Debug.Log("Forrest moves to: " + currentSpot.position);
        transform.position = currentSpot.position; // Move to new spot
    }

    public void ReactToBark()
    {
        barkCount++;

        if (barkCount >= 3) // Takes multiple barks to move him
        {
            Debug.Log("Forrest Reacted! Moving...");
            MoveToRandomSpot();
            barkCount = 0;
        }
    }
}
