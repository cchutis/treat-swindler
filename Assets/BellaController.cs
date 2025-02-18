using UnityEngine;
using System.Collections; // Required for IEnumerator

public class BellaController : MonoBehaviour
{
    public static BellaController Instance; // Singleton Instance

    public float moveSpeed = 3f;
    public float spinSpeed = 360f; // Degrees per second
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject); // Ensure there's only one instance
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("BellaController: Rigidbody2D not found! Did you forget to add it to Bella?");
        }
    }

    void Update()
    {
        if (rb == null) return; // Prevents crashes if Rigidbody2D is missing

        // Movement input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Barking
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BarkSystem.Instance != null)
            {
                BarkSystem.Instance.Bark(); // Call Bark System
            }
            else
            {
                Debug.LogError("BellaController: BarkSystem Instance is null!");
            }
        }

        // Spinning
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Spin());
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = movement * moveSpeed;
        }
    }

    IEnumerator Spin()
    {
        float time = 0.5f; // Spin duration
        float elapsed = 0;
        while (elapsed < time)
        {
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
