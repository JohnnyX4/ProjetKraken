using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private Controls controls;
    private Vector2 inputDirection;
    private Rigidbody2D myRB;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += OnMovePerformed;
        controls.Main.Jump.performed += OnJumpPerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        inputDirection = obj.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        inputDirection = Vector2.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {

    }

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var direction = Vector2.right * (inputDirection.x * speed);
        if (myRB.velocity.sqrMagnitude <= maxSpeed)
        {
            myRB.AddForce(direction);
        }
        
        if (inputDirection.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (inputDirection.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
