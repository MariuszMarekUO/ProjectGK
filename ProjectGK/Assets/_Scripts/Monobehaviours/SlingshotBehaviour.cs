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

    private bool _playerOnSling = false;

    private Rigidbody _rb;
    private void Start()
    {
        _powerValue = 0;
        _powerBar.maxValue = _maxPower;
        _powerBar.value = _powerValue;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            _rb.AddForce(new Vector3(0, _powerValue, _powerValue), ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _rb = other.GetComponent<Rigidbody>();
            _playerOnSling = true;
            StartCoroutine(ActivatePowerBar());
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
    }
}
