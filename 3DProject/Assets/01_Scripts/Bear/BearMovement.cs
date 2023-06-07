using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
    private BearController bearController;

    public float speed;
    public float rotateSpeed;
    public float gravity = 9.8f;

    [SerializeField] private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        bearController = GetComponent<BearController>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        Rotate(new Vector3(0, h, 0));
        Move(ApplyGravity(dir));

        if (dir.magnitude > 0)
            bearController.Animator.SetWalk();
        else
            bearController.Animator.SetIdle();
    }

    public void Rotate(Vector3 dir)
    {
        transform.Rotate(dir.normalized * rotateSpeed);
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
}
