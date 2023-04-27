using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _moveHorizontal;
    private float _moveVertical;

    private float _movementSpeed;

    Vector3 forward;
    Vector3 right;
    Vector3 forwardRelativeVertical;
    Vector3 rightRelativeHorizontal;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movementSpeed = 2f;
    }


    private void FixedUpdate()
    {
        //MoveRelativeToCamera();
    }

    private void MoveRelativeToCamera()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        forward = Camera.main.transform.forward;
        right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        forwardRelativeVertical = _moveVertical * forward;
        rightRelativeHorizontal = _moveHorizontal * right;

        Vector3 cameraRelativeMovement = forwardRelativeVertical + rightRelativeHorizontal;

        if (_moveHorizontal != 0f || _moveVertical != 0f)
        {
            _rb.AddForce(cameraRelativeMovement * _movementSpeed);
        }
    }
}
