using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;

public class InputHandler : MonoBehaviour, IPlayerActions
{
    [Title("Settings")]
    [SerializeField] private float swipeMagnitude = 10f;

    [Title("RSE")]
    [SerializeField] private RSE_MovementInput rseMovementInput;

    private InputActions inputActions;

    private Vector2 currentPosition = Vector2.zero;
    private Vector2 initialPos;

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

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            initialPos = currentPosition;
        }
        if (context.canceled)
        {
            Vector2 offset = currentPosition - initialPos;
            Vector2 movement = Vector2.zero;

            if(Mathf.Abs(offset.x) > swipeMagnitude)
            {
                movement.x = Mathf.Clamp(offset.x, -1, 1);
            }
            if(Mathf.Abs(offset.y) > swipeMagnitude)
            {
                movement.y = Mathf.Clamp(offset.y, -1, 1);
            }

            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) movement.y = 0;
            else movement.x = 0;

            if (Mathf.Abs(movement.x) == Mathf.Abs(movement.y)) movement = new Vector2(movement.x, 0);

            if (movement != Vector2.zero)
            {
                rseMovementInput.Call(Vector2Int.RoundToInt(movement));
            }
                
        }
    }

    public void OnSwipe(InputAction.CallbackContext context)
    {
        currentPosition = context.ReadValue<Vector2>();
    }
}