using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;

public class InputHandler : MonoBehaviour, IPlayerActions
{
    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;

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
        if(movement.x != 0)
        {
            movement.y = 0;
        }
        if (movement.y != 0)
        {
            movement.x = 0;
        }

        rseMovementInput.Call(Vector2Int.RoundToInt(movement));
    }
}