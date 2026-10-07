using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5f;
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float horizontal = Input.GetAxisRaw("Horizontal");
//         float vertical = Input.GetAxisRaw("Vertical");

//         Vector2 direction = new Vector2(horizontal, vertical);
//         if(direction.sqrMagnitude > 1f)
//         {
//             direction.Normalize();
//         }

//         Vector3 movement = new Vector3(direction.x, direction.y, 0f);

//         transform.position += movement * moveSpeed * Time.deltaTime;
//     }
// }

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);
        if(direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }
    }

    void FixedUpdate()
    {
        Vector2 targetPosition = 
        rb.position + (direction * moveSpeed * Time.fixedDeltaTime);

        rb.MovePosition(targetPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision detected!!");
        Debug.Log("You hit: " + collision.gameObject.name);
    }
}
