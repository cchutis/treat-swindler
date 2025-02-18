using UnityEngine;
using UnityEngine.UI;

public class SuspicionSystem : MonoBehaviour
{
    public static SuspicionSystem Instance;
    public Slider suspicionBar;
    private float suspicionLevel = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void IncreaseSuspicion(float amount)
    {
        suspicionLevel = Mathf.Clamp(suspicionLevel + amount, 0, 100);
        suspicionBar.value = suspicionLevel;
    }

    public float GetSuspicionLevel()
    {
        return suspicionLevel;
    }
}
