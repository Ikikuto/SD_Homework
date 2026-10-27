using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float patrolSpeed = 1.5f;
    private Rigidbody2D rb;
    // private Transform playerTransform;
    private EnemyAI enemyAI;
    private float knockbackEndTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();

        // GameObject playerObject = 
        //     GameObject.FindGameObjectWithTag("Player");

        // if (playerObject != null)
        //     playerTransform = playerObject.transform;
    }

    // private void FixedUpdate()
    // {
    //     // if(playerTransform == null) return;
    //     if (Time.time < knockbackEndTime) return;

    //     Transform player;
    //     float speed;
    //     bool isFoundPlayer;

    //     if (enemyAI.IsChasing)
    //     {
    //         player = enemyAI.Player;
    //         speed = moveSpeed;
    //     }
    //     else if (enemyAI.IsPatrolling)
    //     {
    //         player = enemyAI.CurrentPatrolPoint;
    //         speed = patrolSpeed;

    //         if (player == null) return;
    //         isFoundPlayer = Vector2
    //         .Distance(rb.position, player.position)
    //         <= enemyAI.ReachDistance;

    //         if (isFoundPlayer)
    //         {
    //             enemyAI.AdvancePatrolPoint();
    //             return;
    //         }
    //     }
    //     else { return; }
    //     // if (!enemyAI.IsChasing) return;
    //     // Transform player = enemyAI.Player;
    //     // if (player == null) return;

    //     // Vector2 direction = ((Vector2)playerTransform.position - rb.position).normalized;
    //     Vector2 direction = ((Vector2)player.position - rb.position).normalized;


    //     // Vector2 targetPostion =
    //     //     rb.position +
    //     //     direction * moveSpeed * Time.fixedDeltaTime;
    //     Vector2 targetPostion =
    //         rb.position +
    //         direction * speed * Time.fixedDeltaTime;

    //     rb.MovePosition(targetPostion);
    // }
    private void FixedUpdate()
    {
        if (Time.time < knockbackEndTime) return;

        Transform player;
        float speed;
        bool isFoundPlayer;

        if (enemyAI.IsChasing)
        {
            player = enemyAI.Player;
            speed = moveSpeed;
        }
        else if (enemyAI.IsPatrolling)
        {
            player = enemyAI.CurrentPatrolPoint;
            speed = patrolSpeed;

            if (player == null) return;
            isFoundPlayer = Vector2
            .Distance(rb.position, player.position)
            <= enemyAI.ReachDistance;

            if (isFoundPlayer)
            {
                enemyAI.AdvancePatrolPoint();
                return;
            }
        }
        else { return; }

        Vector2 direction =
        ((Vector2)player.position - rb.position)
        .normalized;

        Vector2 targetPosition =
        rb.position +
        speed * Time.fixedDeltaTime * direction;

        rb.MovePosition(targetPosition);
    }

    public void ApplyKnockbackDelay(float duration)
    {
        knockbackEndTime = Time.time + duration;
    }


}
