using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [Header("General Variables")]
    [SerializeField] float followSpeed;
    private Vector3 offsetToPlayer;

    [Header("References")]
    [SerializeField] Transform playerTransform;

    private void Start()
    {
        offsetToPlayer = transform.position - playerTransform.position;

    } // Start()

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z + offsetToPlayer.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }

    } // LateUpdate()

} // class
