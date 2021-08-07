using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("General Variables")]
    [SerializeField] float forwardSpeed;

    [Header("Slide Control Variables")]
    [SerializeField] float horMovementMinMaxValue;
    [SerializeField] float sensitivityMultiplier;
    private Vector2 firstTouchPosition;
    private Vector2 currTouchPosition;
    private float finalTouchX;

    [Header("References")]
    private Rigidbody rbPlayer;

    void Start()
    {
        InitAttachments();

    } // Start()

    void Update()
    {
        HandleHorizontalMovement();

    } // Update()

    private void FixedUpdate()
    {
        HandleForwardMovement();

    } // FixedUpdate()

    private void InitAttachments()
    {
        rbPlayer = GetComponent<Rigidbody>();

    } // InitAttachments()

    private void HandleForwardMovement()
    {
        rbPlayer.velocity = transform.forward * forwardSpeed * Time.fixedDeltaTime;

    } // HandleMovementStarter()

    private void HandleHorizontalMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (currTouchPosition - firstTouchPosition);

            finalTouchX = (rbPlayer.position.x + (touchDelta.x * (sensitivityMultiplier)));

            rbPlayer.position = new Vector3(Mathf.Clamp(finalTouchX, -horMovementMinMaxValue, horMovementMinMaxValue), rbPlayer.position.y, rbPlayer.position.z);

            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetInputValues();
        }

    } // HandleHorizontalMovement()

    void ResetInputValues()
    {
        firstTouchPosition = Vector2.zero;
        finalTouchX = 0f;
        currTouchPosition = Vector2.zero;

    } // ResetInputValues()

} // class
