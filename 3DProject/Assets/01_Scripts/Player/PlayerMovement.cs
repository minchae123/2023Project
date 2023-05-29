using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float rotateSpeed;
    public float gravity = 9.8f;

    [SerializeField] private CharacterController controller;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(v);
        Rotate(new Vector3(0, h, 0));
    }

    public void Rotate(Vector3 dir)
    {
        transform.Rotate(dir.normalized * rotateSpeed);
    }

    public void Move(float dir)
    {
        controller.Move(dir * transform.forward * speed);
    }
}
