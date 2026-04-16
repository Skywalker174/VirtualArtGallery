using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class SimpleMove : MonoBehaviour
{
    [Header("References")]
    public SimpleJoystick moveJoystick;
    public Transform playerCamera;

    [Header("Movement Settings")]
    public float moveSpeed = 25f;
    public float gravity = -9.81f;

    [Header("Look Settings (Drag to Look)")]
    public float mouseSensitivity = 2f;
    public float verticalLimit = 45f;

    private CharacterController _controller;
    private float _rotX;
    private float _vVelocity;
    
    // Tracks if we started our click on the UI
    private bool _isDraggingUI = false; 

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
        // Failsafe to find the camera if you forgot to assign it
        if (playerCamera == null) 
            playerCamera = GetComponentInChildren<Camera>().transform;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        // 1. Check if we JUST clicked this frame
        if (Input.GetMouseButtonDown(0))
        {
            // If the mouse is over a UI element (like the joystick), lock rotation
            if (EventSystem.current.IsPointerOverGameObject())
                _isDraggingUI = true;
            else
                _isDraggingUI = false;
        }

        // 2. Unlock rotation when we let go of the mouse
        if (Input.GetMouseButtonUp(0))
        {
            _isDraggingUI = false;
        }

        // 3. Only rotate if holding click AND we didn't start the click on the UI
        if (Input.GetMouseButton(0) && !_isDraggingUI)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotate Player Body (Left/Right)
            transform.Rotate(Vector3.up * mouseX);

            // Rotate ONLY the Camera Child (Up/Down)
            _rotX -= mouseY;
            _rotX = Mathf.Clamp(_rotX, -verticalLimit, verticalLimit);
            playerCamera.localRotation = Quaternion.Euler(_rotX, 0f, 0f);
        }
    }

    private void HandleMovement()
    {
        // Combine Keyboard (WASD) and Joystick input
        float h = Input.GetAxis("Horizontal") + (moveJoystick != null ? moveJoystick.input.x : 0);
        float v = Input.GetAxis("Vertical") + (moveJoystick != null ? moveJoystick.input.y : 0);

        Vector3 move = (transform.right * h + transform.forward * v).normalized;

        // Apply Gravity
        if (_controller.isGrounded && _vVelocity < 0) 
            _vVelocity = -2f;
            
        _vVelocity += gravity * Time.deltaTime;

        Vector3 finalVelocity = (move * moveSpeed) + (Vector3.up * _vVelocity);
        _controller.Move(finalVelocity * Time.deltaTime);
    }

    // Called by CameraController when focusing on a painting
    public void ResetVerticalRotation()
    {
        _rotX = 0f;
        if (playerCamera != null) playerCamera.localRotation = Quaternion.identity;
    }
}