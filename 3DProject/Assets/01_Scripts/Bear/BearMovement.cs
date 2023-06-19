using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
    private BearController bearController;

    public float speed;
    private float realSpeed;
    public float rotateSpeed;
    public float gravity = 9.8f;
    public float jumpScale = 5;
    
    public CharacterController controller;
    [SerializeField] private Transform camTrm;

    private Vector3 dir;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        bearController = GetComponent<BearController>();

        realSpeed = speed;

        dir = new Vector3(0, 5, 0);
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0, v).normalized;

        Rotate(new Vector3(0, h, 0));
        Move(ApplyGravity(dir));

        if (dir.magnitude > 0)
            bearController.Animator.SetWalk();
        else
            bearController.Animator.SetIdle();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Rotate(Vector3 dir)
    {
        transform.Rotate(dir.normalized * rotateSpeed);
        camTrm.Rotate(dir.normalized * rotateSpeed);
    }

    public void Move(Vector3 v)
    {
        controller.Move(v.y * Vector3.up + (v.z * transform.forward * speed));
    }

    public Vector3 ApplyGravity(Vector3 v)
    {
        if (!controller.isGrounded)
        {
            v.y -= gravity * Time.deltaTime;
        }
        else
        {
            v.y = 0f;
        }
        return v;
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            controller.Move(new Vector3(0, jumpScale, 0));
        }
    }

    public void ResetPlayer()
    {
        gravity = 9.8f;
        speed = realSpeed;
        dir = new Vector3(0, 5, 0);
    }

    public void StopPlayer()
    {
        speed = 0;
        gravity = 0;
    }
}
