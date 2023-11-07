using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float viewAngles = 90f;
    [SerializeField] private Transform isGround;
    private Transform playerCamera;
    private float rotationX = 0;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isRunning = false;

    private Animator playerMoveAnim;

    void Start()
    {
        playerMoveAnim = GetComponentInChildren<Animator>();
        playerCamera = GameObject.Find("playerCamera").GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        if (characterController.isGrounded) { moveDirection.y = 0; }
        if (!Input.GetButtonDown("Fire1"))
        {


            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            playerMoveAnim.SetFloat("speedHorizontal", horizontalInput);
            playerMoveAnim.SetFloat("speedVertical", verticalInput);
            playerMoveAnim.SetBool("shoot", false);

            Vector3 forward = transform.forward * verticalInput;
            Vector3 right = transform.right * horizontalInput;

            moveDirection = (forward + right).normalized;

            if (characterController.isGrounded)
            {
                

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerMoveAnim.SetBool("jump", true);
                    moveDirection.y = jumpForce;
                }
                playerMoveAnim.SetBool("jump", false);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerMoveAnim.SetFloat("speedHorizontal", 2);
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
            }

            float speed = isRunning ? runSpeed : moveSpeed;
            characterController.Move(moveDirection * speed * Time.deltaTime);

            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -viewAngles, viewAngles);

            playerCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        }
        else
            playerMoveAnim.SetBool("shoot", true);

      

    }
}
