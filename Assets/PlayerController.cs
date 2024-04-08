using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick movementJoystick;

    [SerializeField] private float speed;

    private Rigidbody rb;

    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        // Utilise la position du movementJoystick pour définir la direction du mouvement
        float moveX = movementJoystick.Horizontal;
        float moveZ = movementJoystick.Vertical;
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }
}