using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControllerTPPCharacter : MonoBehaviour
{
    //public GameObject CameraAndLogic;
    [SerializeField] public CharacterController controller;
    [SerializeField] public Transform mainCam;
    [SerializeField] PhotonView playerView;
    
    float speed = 0.0f;
    [SerializeField] public float playerSpeed = 10f;

    [HideInInspector] public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void FixedUpdate()
    {
        if (playerView.IsMine)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(moveDir * smoothSpeed() * Time.deltaTime);
            }
        }
    }

    public float smoothSpeed()
    {
        float delta = playerSpeed - speed;
        delta *= Time.deltaTime;
        speed += delta;
        return speed;
    }
}
