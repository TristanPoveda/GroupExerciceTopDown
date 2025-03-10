using Sirenix.OdinInspector;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private float moveSpeed;

    [Title("References")]
    [SerializeField] private GridManager gridManager;

    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;
    [SerializeField] private RSE_InteractInput rseInteractInput;
    [SerializeField] private RSE_AttackInput rseAttackInput;

    private Vector2Int movementInput;

    private Cell currentCell;
    private Cell targetCell;

    private CountdownTimer movementTimer;

    private void OnEnable()
    {
        rseMovementInput.action += OnMoveInput;
        rseInteractInput.action += OnInteractInput;
        rseAttackInput.action += OnAttackInput;
    }

    private void OnDisable()
    {
        rseMovementInput.action -= OnMoveInput;
        rseInteractInput.action -= OnInteractInput;
        rseAttackInput.action -= OnAttackInput;
    }

    private void Awake()
    {
        currentCell = gridManager.Grid[gridManager.GetCoordinatesFromPosition(transform.position)];

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
        Move();
    }

    private void OnMoveInput(Vector2Int direction)
    {
        movementInput = direction;
    }

    private void OnInteractInput(bool performed)
    {
        Debug.Log("Interact -> " + performed);
    }

    private void OnAttackInput(bool performed)
    {
        Debug.Log("Attack -> " + performed);
    }

    private void Move()
    {
        if (movementInput == Vector2Int.zero || movementTimer.IsRunning) return;

        Vector2Int targetPos = currentCell.cords + movementInput;
        Cell targetCell = gridManager.GetCell(targetPos);

        if (targetCell != null && targetCell.type == CellType.Walkable)
        {
            movementTimer.Start();
            transform.position = gridManager.GetPositionFromCoordinates(targetCell.cords);
            currentCell = targetCell;
        }
    }
}