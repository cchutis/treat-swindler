using UnityEngine;

public class TreatManager : MonoBehaviour
{
    public static TreatManager Instance;
    public int treatCount = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void RewardTreat()
    {
        treatCount++;
        Debug.Log("Bella earned a treat! Total: " + treatCount);
    }

    public void CheckForScam()
    {
        if (!MomAI.Instance.IsWatching())
        {
            RewardTreat();
        }
        else
        {
            SuspicionSystem.Instance.IncreaseSuspicion(15);
            Debug.Log("Bella got caught! No treat.");
        }
    }
}
