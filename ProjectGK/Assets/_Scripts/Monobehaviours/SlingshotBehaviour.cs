using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlingshotBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] private Slider _powerBar;

    private float _maxPower = 100f;
    private float _powerValue;
    private float _value = 1f;

    private float _maxRotation = -50;
    private float _minRotation = -15;
    private float _rotationSpeed = 1;

    private bool _playerOnSling = false;

    private Vector3 _fireDirection;

    private Rigidbody _rb;
    private void Start()
    {
        _powerValue = 0;
        _powerBar.maxValue = _maxPower;
        _powerBar.value = _powerValue;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && _playerOnSling)
        {
            //_rb.AddForce(new Vector3(0, _powerValue, _powerValue), ForceMode.Impulse);
            StartCoroutine(RotateSlingshot());
            //_rb.velocity = new Vector3(0, _powerValue, _powerValue);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerOnSling = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _rb = other.GetComponent<Rigidbody>();
            _playerOnSling = true;
            //StartCoroutine(ActivatePowerBar());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _playerOnSling = false;
        }
    }

    private IEnumerator ActivatePowerBar()
    {
        while (_playerOnSling)
        {
            _powerValue += _value;
            if (_powerValue > _maxPower || _powerValue < 0)
            {
                _value *= -1;
            }
            powerText.text = "Power: " + _powerValue.ToString();
            _powerBar.value = _powerValue;
            yield return new WaitForSeconds(0.01f);
        }
        _fireDirection *= _powerValue;
        //_rb.AddForce(new Vector3(0, _powerValue, _powerValue), ForceMode.Impulse);
        _rb.velocity = _fireDirection;
        Debug.DrawRay(_rb.position, _fireDirection, Color.red, 30);
        Debug.Log(_fireDirection);
    }

    private IEnumerator RotateSlingshot()
    {
        while (_playerOnSling)
        {
            float rX = Mathf.SmoothStep(_maxRotation, _minRotation, Mathf.PingPong(Time.time * _rotationSpeed, 1));
            transform.parent.rotation = Quaternion.Euler(rX, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        _fireDirection = transform.parent.forward;
        _playerOnSling = true;
        StartCoroutine(ActivatePowerBar());
        
    }
}
