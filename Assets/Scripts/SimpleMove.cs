using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleMove : MonoBehaviour {
    [Header("Movement Settings")]
    public SimpleJoystick moveJoystick;
    public float moveSpeed = 15f;

    [Header("Sensitivity Settings")]
    public float mouseSensitivity = 2f;
    public float touchSensitivity = 0.5f; 

    private CharacterController _controller;
    private Transform _cam;
    private float _vVel;
    private float _rotX;
    private float _lookX;
    private float _lookY;

    void Start() {
        _controller = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>().transform;
        
        if (!Application.isMobilePlatform) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update() {
        _lookX = 0;
        _lookY = 0;

        if (Application.isMobilePlatform) {
            HandleMobileTouch();
        } else {
            HandlePCMouse();
        }

        ApplyMovement();
        ApplyRotation();
    }

    void HandlePCMouse() {
        _lookX = Input.GetAxis("Mouse X") * mouseSensitivity;
        _lookY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    void HandleMobileTouch() {
        for (int i = 0; i < Input.touchCount; i++) {
            Touch t = Input.GetTouch(i);
            
            if (!EventSystem.current.IsPointerOverGameObject(t.fingerId)) {
                if (t.position.x > Screen.width / 2.0f) {
                    if (t.phase == TouchPhase.Moved) {
                        _lookX = t.deltaPosition.x * touchSensitivity;
                        _lookY = t.deltaPosition.y * touchSensitivity;
                    }
                }
            }
        }
    }

    void ApplyMovement() {
        float h = Input.GetAxis("Horizontal") + (moveJoystick ? moveJoystick.input.x : 0);
        float v = Input.GetAxis("Vertical") + (moveJoystick ? moveJoystick.input.y : 0);
        
        if (_controller.isGrounded && _vVel < 0) _vVel = -2f;
        _vVel += Physics.gravity.y * Time.deltaTime;

        Vector3 move = (transform.right * h + transform.forward * v) * moveSpeed;
        _controller.Move((move + new Vector3(0, _vVel, 0)) * Time.deltaTime);
    }

    void ApplyRotation() {
        transform.Rotate(Vector3.up * _lookX);
        
        _rotX -= _lookY;
        _rotX = Mathf.Clamp(_rotX, -90f, 90f);
        _cam.localRotation = Quaternion.Euler(_rotX, 0, 0);
    }
}