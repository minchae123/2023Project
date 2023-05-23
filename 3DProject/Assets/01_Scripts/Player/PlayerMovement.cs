using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity = 9.8f;

    [SerializeField] private CharacterController controller;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move()
    {
        
    }
}
