using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
    private BearController bearController;

    public float speed;
    public float jumpSpeed;
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

        Rotate(new Vector3(0, h, 0));

        Move(v);
    }

    public void Rotate(Vector3 dir)
    {
        transform.Rotate(dir.normalized * rotateSpeed);
    }

    public void Move(float dir)
    {
        bearController.Animator.Walk(true);
        controller.Move(dir * transform.forward * speed);
    }
}
