using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 20f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

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
        CheckForHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }

    private void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Get input
        inputVector.Normalize(); // To prevent faster diagonal movement
        inputVector = transform.TransformDirection(inputVector); // Convert local to global direction

        movementVector = (inputVector * PlayerSpeed) + (Vector3.up * myGravity); // Combine movement and gravity
    }

    private void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime); // Move the player
    }

    void CheckForHeadBob()
    {
        if (myCC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

    }
}
