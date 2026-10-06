using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);
        if(direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }

        Vector3 movement = new Vector3(direction.x, direction.y, 0f);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
