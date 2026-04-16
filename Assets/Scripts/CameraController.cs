using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    
    private bool isViewing;
    private CharacterController characterController;
    private Coroutine approachRoutine;

    [SerializeField] private SimpleMove simpleMove;
    [SerializeField] private float approachSpeed = 3f;

    private void Awake()
    {
        Instance = this;
        characterController = GetComponent<CharacterController>();
        
        // Failsafe: Automatically grab the SimpleMove script if it isn't assigned
        if (simpleMove == null) 
            simpleMove = GetComponent<SimpleMove>();
    }

    public void FocusOnArtwork(Transform viewPoint)
    {
        if (!isViewing) 
            approachRoutine = StartCoroutine(Approach(viewPoint));
        isViewing = true;
        Debug.Log("Calling");

    }

    private IEnumerator Approach(Transform viewPoint)
    {

        Debug.Log("Calling1");

        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        Vector3 targetPos = viewPoint.position;
        targetPos.y = transform.position.y;
        Quaternion targetRot = viewPoint.rotation;

        // characterController.enabled = false;
        
        if (simpleMove != null) simpleMove.ResetVerticalRotation();

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * approachSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        // characterController.enabled = true;
    }

    private void Update()
    {
        // FIX: Removed Input.GetMouseButtonDown(0). 
        // Now you will only exit viewing mode if you physically move away (WASD/Joystick) or press Escape!
        if (isViewing && (
                Input.GetAxisRaw("Horizontal") != 0f ||
                Input.GetAxisRaw("Vertical") != 0f ||
                Input.GetKeyDown(KeyCode.Escape)))
        {
            ExitViewing();
        }
    }

    private void ExitViewing()
    {
        isViewing = false;
        if (approachRoutine != null) StopCoroutine(approachRoutine);
        characterController.enabled = true;
    }
}