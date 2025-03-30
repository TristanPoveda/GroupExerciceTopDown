using Sirenix.OdinInspector;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] int movementPoints;

    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;

    [Header("References")]
    [SerializeField] RSO_MovementPoints rSO_MovementPoints;
    [SerializeField] RSE_OpenScene rSE_OpenScene;
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
    private void Start()
    {
       rSO_MovementPoints.Value = movementPoints;
    }
    private void SetupTimers()
    {
        movementTimer = new CountdownTimer(moveSpeed);
    }

    private void Update()
    {
        HandleTimers();
        if(rSO_MovementPoints.Value <= 0)
        {
            rSE_OpenScene.Call("MainMenu");
        }
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
        movementInput = Vector2Int.zero;
        rSO_MovementPoints.Value--;
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