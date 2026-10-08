using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    private void FixedUpdate()
    {
        if (playerTransform == null)
            return;
        
        Vector2 direction =
            ((Vector2)playerTransform.position - rb.position).normalized;
        // Tai sao lai can phai chuan hoa lai direction?? (tham khao lai tai lieu)
        
        Vector2 targetPostion =
            rb.position +
            direction * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPostion);
    }
}
