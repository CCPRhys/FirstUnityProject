using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private CharacterController controller;


    private Vector2 lastMovementInput;

    private void Update()
    {
        controller.Move(lastMovementInput * Time.deltaTime);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        lastMovementInput = context.ReadValue<Vector2>();
    }
}
