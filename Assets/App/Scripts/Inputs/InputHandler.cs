using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;

public class InputHandler : MonoBehaviour, IPlayerActions
{
    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;
    [SerializeField] private RSE_InteractInput rseInteractInput;
    [SerializeField] private RSE_AttackInput rseAttackInput;

    private InputActions inputActions;

    private void Awake()
    {
        if(inputActions == null)
        {
            inputActions = new InputActions();
            inputActions.Player.SetCallbacks(this);
        }
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        if(Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        rseMovementInput.Call(Vector2Int.RoundToInt(movement));
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                rseInteractInput.Call(true);
                break;
            case InputActionPhase.Canceled:
                rseInteractInput.Call(false);
                break;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                rseAttackInput.Call(true);
                break;
            case InputActionPhase.Canceled:
                rseAttackInput.Call(false);
                break;
        }
    }
}