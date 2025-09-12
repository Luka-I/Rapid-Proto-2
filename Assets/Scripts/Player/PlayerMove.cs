using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 10f;
    public float momentunDamping = 5f;

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

        camAnim.SetBool("isWalking", isWalking);
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        { 
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Get input
            inputVector.Normalize(); // To prevent faster diagonal movement
            inputVector = transform.TransformDirection(inputVector); // Convert local to global direction

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentunDamping * Time.deltaTime); // Apply momentum damping
            isWalking = false;
        }

        movementVector = (inputVector * PlayerSpeed) + (Vector3.up * myGravity); // Combine movement and gravity
    }

    private void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime); // Move the player
    }
}
