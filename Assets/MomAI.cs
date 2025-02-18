using UnityEngine;

public class MomAI : MonoBehaviour
{
    public static MomAI Instance;
    public Transform watchPosition;
    public Transform insidePosition;
    private bool isWatching = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ReactToBark()
{
    float watchChance = (SuspicionSystem.Instance.GetSuspicionLevel() > 50) ? 80f : 60f;
    bool isWatching = Random.Range(0f, 100f) < watchChance;

    if (isWatching)
    {
        transform.position = watchPosition.position; // Move Mom to door
        UIManager.Instance.ShowMessage("Mom is watching...");
    }
    else
    {
        UIManager.Instance.ShowMessage("Mom stays inside...");
    }

    DoorOpens(); // Bella can go outside
}

void DoorOpens()
{
    // Code to let Bella move outside
    UIManager.Instance.ShowMessage("Door opens! Bella can go outside.");
}


    public bool IsWatching()
    {
        return isWatching;
    }

   
}
