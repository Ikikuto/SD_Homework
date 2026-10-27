using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Chase,
    Attack,
    Patrol
}

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float reachDistance = 0.1f;
    // private EnemyState currentState = EnemyState.Idle;
    private EnemyState currentState = EnemyState.Patrol;
    private Transform currentPatrolPoint;
    public bool IsChasing => currentState == EnemyState.Chase;
    public bool IsPatrolling => currentState == EnemyState.Patrol;
    private EnemyCombat enemyCombat;
    public Transform Player => player;
    public Transform CurrentPatrolPoint => currentPatrolPoint;
    public float ReachDistance => reachDistance;

    private void Awake()
    {
        enemyCombat = GetComponent<EnemyCombat>();

        if (player == null)
        {
            GameObject playerObject =
                GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
        
        currentPatrolPoint = pointA;
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log(gameObject.name + " State: " + currentState);
    }

    private void UpdateState()
    {
        if (player == null)
        {
            ChangeState(EnemyState.Patrol);
            return;
        }

        float distance = Vector2.Distance(
            transform.position, player.position);
        if (distance > chaseRange)
            ChangeState(EnemyState.Idle);
        else if (distance <= attackRange)
            ChangeState(EnemyState.Attack);
        else
            ChangeState(EnemyState.Chase);
    }

    private void Update()
    {
        if (player == null)
        {
            ChangeState(EnemyState.Idle);
            return;
        }
        UpdateState();

        switch (currentState)
        {
            case EnemyState.Idle:
                HandleIdle();
                break;
            case EnemyState.Patrol:
                HandlePatrol();
                break;
            case EnemyState.Chase:
                HandleChase();
                break;
            case EnemyState.Attack:
                HandleAttack();
                break;
        }
    }

    private void HandleIdle()
    {

    }

    private void HandleChase()
    {

    }

    private void HandleAttack()
    {
        if (enemyCombat != null)
        {
            enemyCombat.TryAttack(player);
        }
        
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, chaseRange);

    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackRange);
    // }
#if UNITY_EDITOR
    // private void OnDrawGizmosSelected()
    private void OnDrawGizmos() // bo chu Selected
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(
            transform.position,
            Vector3.forward,
            chaseRange
        );

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(
            transform.position,
            Vector3.forward,
            attackRange
        );

        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        }
    }
#endif

    private void HandlePatrol()
    {
        
    }

    public void AdvancePatrolPoint()
    {
        if(pointA == null || pointB == null) return;

        currentPatrolPoint = 
            (currentPatrolPoint == pointA) ? pointB : pointA;
    }

    private void OnValidate()
    {
        chaseRange = Mathf.Max(0f, chaseRange);
        attackRange = Mathf.Clamp(attackRange, 0f, chaseRange);
        reachDistance = Mathf.Max(0.01f, reachDistance);
    }

    public void SetPatrolPoints(Transform a, Transform b)
    {
        pointA = a;
        pointB = b;
        currentPatrolPoint = pointA;
    }
}
