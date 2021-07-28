using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject CameraHolder;
    [SerializeField] float HorizontalSensitivity, VerticalSensitivity, SprintSpeed, WalkSpeed, JumpSpeed, SmoothTime;
    float VerticalLookRotation;
    bool Grounded;
    Vector3 SmoothMoveVelocity, MoveAmount;
    Rigidbody RB;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * HorizontalSensitivity);
    }

}