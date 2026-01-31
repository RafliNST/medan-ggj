using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;
    
    private Transform targetPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPoint = pointA; // Target awal ke Point B
    }

    void Update()
    {
        // Hitung jarak hanya berdasarkan sumbu X dan Y (Vector2)
        float distance = Vector2.Distance(transform.position, targetPoint.position);

        // Jika jarak ke target kurang dari 0.7 unit, ganti target
        if (distance < 0.7f)
        {
            if (targetPoint == pointB)
            {
                targetPoint = pointA;
                Flip(false); // Hadap Kiri
            }
            else
            {
                targetPoint = pointB;
                Flip(true); // Hadap Kanan
            }
            Debug.Log("Target berganti ke: " + targetPoint.name);
        }
    }

    void FixedUpdate()
    {
        if (targetPoint != null)
        {
            // Tentukan arah (Kanan = 1, Kiri = -1)
            float direction = (targetPoint.position.x > transform.position.x) ? 1 : -1;
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    void Flip(bool faceRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = faceRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}