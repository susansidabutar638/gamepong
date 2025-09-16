using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1 = true;
    public float speed = 5f;
    public float boundY = 4.5f;  

    private Rigidbody2D rb;
    private float direction = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        HandleKeyboardInput();

        
        rb.linearVelocity = new Vector2(0, direction * speed);

        
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        transform.position = pos;

#elif UNITY_ANDROID || UNITY_IOS
        HandleTouchInput();  // di Android/iOS gerak langsung dengan jari
#endif
    }

    void HandleKeyboardInput()
    {
        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.W)) direction = 1f;
            else if (Input.GetKey(KeyCode.S)) direction = -1f;
            else direction = 0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) direction = 1f;
            else if (Input.GetKey(KeyCode.DownArrow)) direction = -1f;
            else direction = 0f;
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (isPlayer1 && t.position.x < Screen.width / 2)
                {
                    if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
                    {
                        Vector3 worldPos = Camera.main.ScreenToWorldPoint(t.position);
                        transform.position = new Vector3(
                            transform.position.x,
                            Mathf.Clamp(worldPos.y, -boundY, boundY),
                            transform.position.z
                        );
                    }
                }
                else if (!isPlayer1 && t.position.x > Screen.width / 2)
                {
                    if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
                    {
                        Vector3 worldPos = Camera.main.ScreenToWorldPoint(t.position);
                        transform.position = new Vector3(
                            transform.position.x,
                            Mathf.Clamp(worldPos.y, -boundY, boundY),
                            transform.position.z
                        );
                    }
                }
            }
        }
    }
}
