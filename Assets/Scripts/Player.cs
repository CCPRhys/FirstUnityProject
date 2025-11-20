using System.Threading;
using UnityEngine;
public class Player : MonoBehaviour
{
    bool inputLock = false;
    public int health = 100;
    public int damageAmount = 10;
    public float walkSpeed = 10;

    private CharacterController characterController;


    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!inputLock && Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damageAmount);
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 inputDirection = new Vector3(vertical, 0, horizontal);

        inputDirection.Normalize();

        characterController.Move(inputDirection * Time.deltaTime * walkSpeed);


    }


    private bool TakeDamage(int amount)
    {
        // health = health - amount;

        health = Mathf.Clamp(health - amount, 0, 100);

        Debug.Log("Health: " + health);

        if(health <= 0)
        {
            return true;
        }
        return false;
    }
    // Change the function above from a void to a bool
    // Return true with player has died
}
