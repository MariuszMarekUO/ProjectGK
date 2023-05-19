using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private float _moveHorizontal;

    [SerializeField] private float _movementSpeed;

    Vector3 right;
    Vector3 rightRelativeHorizontal;

    private Vector3 _currentVelocity;
    [SerializeField] private Vector3 _vectorRegulation;

    [SerializeField] GameMenager gameMenager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        MoveRelativeToCamera();
        //transform.rotation = Quaternion.LookRotation(_rb.velocity + _vectorRegulation);
    }

    private void MoveRelativeToCamera()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");

        right = Camera.main.transform.right;

        right.y = 0;

        right = right.normalized;

        rightRelativeHorizontal = _moveHorizontal * right;

        Vector3 cameraRelativeMovement = rightRelativeHorizontal * _movementSpeed;

        if (_moveHorizontal != 0f)
        {
            _currentVelocity = _rb.velocity;
            _currentVelocity.x = 0;
            _currentVelocity += cameraRelativeMovement;
            _rb.velocity = _currentVelocity;
        }
        else
        {
            _currentVelocity = _rb.velocity;
            _currentVelocity.x = 0;
            _rb.velocity = _currentVelocity;
        }
        //Debug.Log(_rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            _rb.isKinematic = true;

            gameMenager.EndGame();
        }
    }
}
