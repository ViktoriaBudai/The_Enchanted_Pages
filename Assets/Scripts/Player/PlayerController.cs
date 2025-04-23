using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator anim;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private Transform cameraTransform;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9f;
    private bool previousGroundedState = true;
    public Transform checkLocation;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround;

    private void Start()
    {
        // For some reasion my Character Controller component is only available in the inspector if I press play
        //so I added the radius, height and centre manually for this script
        //controller = gameObject.AddComponent<CharacterController>();
        controller = gameObject.GetComponent<CharacterController>();
        //controller.radius = 0.5f; // Set your desired radius
        //controller.height = 0.5f;  // Set your desired height
        //controller.center = new Vector3(0, 0.5f, 0); // Set your desired center
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {

        // Reset vertical velocity when grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get input and calculate movement direction
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;

        // Move the player
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Rotate the player to face the movement direction
        if (move != Vector3.zero)
        {
            anim.SetFloat("MoveSpeed", move.normalized.magnitude);
            //anim.Play("");
            gameObject.transform.forward = move;
        }
        else
        {
            anim.SetFloat("MoveSpeed", 0f);
        }

        // Handle jumping
        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            anim.SetTrigger("Jump");
            //anim.Play("Jump");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
        }

        if (groundedPlayer != previousGroundedState)
        {
            previousGroundedState = groundedPlayer;
            anim.SetBool("Grounded", groundedPlayer);
        }
        if (!groundedPlayer)
        {
            // Apply gravity
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        // Move the character controller based on vertical velocity
        controller.Move(playerVelocity * Time.deltaTime);

        // Optional: Set blending animation when the player is moving
        // anim.SetFloat("Blend", input.sqrMagnitude);
    }

    private void FixedUpdate()
    {

        groundedPlayer = CheckGrounded();
    }

    private bool CheckGrounded()
    {
        // Adjust the position and length of the raycast based on your character size
        return Physics.CheckSphere(checkLocation.position, checkRadius, whatIsGround);
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(checkLocation.position, checkRadius);
    }
}
