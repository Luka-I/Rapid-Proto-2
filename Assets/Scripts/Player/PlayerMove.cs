using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 20f;
    private CharacterController myCC;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();
        MovePlayer();
    }

    private void GetInput()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Get input
        inputVector.Normalize(); // To prevent faster diagonal movement
        inputVector = transform.TransformDirection(inputVector); // Convert local to global direction

        movementVector = (inputVector * PlayerSpeed) + (Vector3.up * myGravity); // Combine movement and gravity
    }

    private void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime); // Move the player
    }
}
