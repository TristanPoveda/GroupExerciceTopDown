using Sirenix.OdinInspector;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private float moveSpeed = 0.25f;

    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;

    private Vector2Int movementInput;

    private CountdownTimer movementTimer;

    private void OnEnable()
    {
        rseMovementInput.action += OnMoveInput;
    }

    private void OnDisable()
    {
        rseMovementInput.action -= OnMoveInput;
    }

    private void Awake()
    {
        SetupTimers();
    }

    private void SetupTimers()
    {
        movementTimer = new CountdownTimer(moveSpeed);
    }

    private void Update()
    {
        HandleTimers();
    }

    private void HandleTimers()
    {
        movementTimer.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(CanMove() && !movementTimer.IsRunning)
        {
            movementTimer.Start();
            Move();
        }
    }

    private void OnMoveInput(Vector2Int direction)
    {
        movementInput = direction;
    }

    private void Move()
    {
        transform.position += new Vector3(movementInput.x, 0, movementInput.y);
    }

    private bool CanMove()
    {
        if (movementInput.magnitude == 0) return false;

        Collider[] colliders = Physics.OverlapBox(transform.position + new Vector3(movementInput.x, 0, movementInput.y), Vector3.zero);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall")) return false;
        }

        return true;
    }
}