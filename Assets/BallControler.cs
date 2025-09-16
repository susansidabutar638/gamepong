using UnityEngine;

public class BallControler : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector3.zero;

        float xDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        float yDirection = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;

        rb.linearVelocity = direction * speed;
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            float paddleY = col.transform.position.y;
            float contactY = transform.position.y;
            float paddleHeight = col.collider.bounds.size.y;

            float yDiff = (contactY - paddleY) / (paddleHeight / 2f);  

            // cek paddle kiri atau kanan (x lebih kecil dari 0 berarti kiri)
            float xDir = col.transform.position.x < 0 ? 1 : -1;

            Vector2 newDir = new Vector2(xDir, yDiff).normalized;
            rb.linearVelocity = newDir * speed;
        }
    }
}
