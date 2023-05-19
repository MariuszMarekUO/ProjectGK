using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Slider _staminaBar;

    private Rigidbody _rb;

    [SerializeField] private float _impulseForceValue;

    private float _maxStamina;
    private float _stamina;

    private bool _isRegenerating;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _maxStamina = 100;
        _stamina = 100;
        UpdateStaminaBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_stamina - 25 > 0)
            {
                ImpulsePlayer();
                _stamina -= 25;
                if (!_isRegenerating)
                {
                    _isRegenerating = true;
                    StartCoroutine(RegenerateStamina());
                }
                UpdateStaminaBar();
            }
        }
    }

    private void ImpulsePlayer()
    {
        //_rb.AddForce(new Vector3(0, _impulseForceValue, _impulseForceValue), ForceMode.Impulse);
        _rb.velocity = new Vector3(0, _impulseForceValue, _impulseForceValue);
    }

    private void UpdateStaminaBar()
    {
        _staminaBar.maxValue = _maxStamina;
        _staminaBar.value = _stamina;
    }

    private IEnumerator RegenerateStamina()
    {
        while (_isRegenerating)
        {
            if(_stamina < _maxStamina)
            {
                _stamina += 1;
                UpdateStaminaBar();
            }
            else
            {
                _isRegenerating = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
