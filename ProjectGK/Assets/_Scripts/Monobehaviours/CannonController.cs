using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] private Slider _powerBar;
    [SerializeField] private GameObject _cannonTube;

    private float _maxPower = 100f;
    private float _powerValue;
    private float _value = 1f;

    [SerializeField] private float _maxRotation = -50;
    [SerializeField] private float _minRotation = -10;
    [SerializeField] private float _rotationSpeed = 1;

    [SerializeField] private Vector3 _xyz;

    public bool _playerInCannon = true;

    private Vector3 _fireDirection;


    private Transform _defaultPlayerParent;
    private Rigidbody _rb;
    private void Start()
    {
        _powerValue = 0;
        _powerBar.maxValue = _maxPower;
        _powerBar.value = _powerValue;
    }

    private IEnumerator ActivatePowerBar()
    {
        while (_playerInCannon)
        {
            _powerValue += _value;
            if (_powerValue > _maxPower || _powerValue < 0)
            {
                _value *= -1;
            }
            _powerBar.value = _powerValue;
            yield return new WaitForSeconds(0.01f);
        }
        _fireDirection *= _powerValue/2;
        Debug.Log(_rb.gameObject);
        _rb.gameObject.transform.parent = _defaultPlayerParent;
        //_rb.gameObject.transform.SetParent(null);
        _rb.isKinematic = false;
        _rb.velocity = _fireDirection;
    }

    private float timer = 0f;
    public IEnumerator RotateCannon()
    {
        while (_playerInCannon)
        {
            timer += Time.deltaTime * _rotationSpeed;
            float rotationValue = Mathf.PingPong(timer, 1f);
            float rX = Mathf.Lerp(_minRotation, _maxRotation, rotationValue);
            _cannonTube.transform.rotation = Quaternion.Euler(rX, 0f, 0f);
            yield return new WaitForEndOfFrame();
        }
        _fireDirection = _cannonTube.transform.forward + _xyz;
        _playerInCannon = true;
        StartCoroutine(ActivatePowerBar());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _defaultPlayerParent = other.transform.parent;
            other.transform.parent = _cannonTube.transform;
            _rb = other.GetComponent<Rigidbody>();
            _playerInCannon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerInCannon = false;
        }
    }
}
