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
        controller.Move(new Vector3(lastMovementInput.x, 0, lastMovementInput.y) * Time.deltaTime);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        lastMovementInput = context.ReadValue<Vector2>();
    }

    public void MouseInput(InputAction.CallbackContext context)
    {
        Debug.Log("Mouse position:" + context.ReadValue<Vector2>());

        Ray ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(ray, out hit, 100f))
        {

            Vector2 hitPosition;
            hitPosition.x = hit.point.x;
            hitPosition.y = hit.point.z;

            Vector2 playerPosition;
            playerPosition.x = this.transform.position.x;
            playerPosition.y = this.transform.position.z;


            Vector2 direction = hitPosition - playerPosition;
            direction.Normalize();  
            float rotationDirection = Mathf.Atan2(direction.x, direction.y);
            Debug.Log("Looking direction: " + rotationDirection);

            Quaternion rot = Quaternion.Euler(new Vector3(0, rotationDirection * Mathf.Rad2Deg, 0));
            this.transform.rotation = rot;
        }
    }

}
