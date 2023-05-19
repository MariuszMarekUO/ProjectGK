using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cannonCam;
    [SerializeField] private CinemachineVirtualCamera _playerCam;
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private CannonController _cannonController;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerStamina _playerStamina;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private ParticleSystem _smokeParticle;
    [SerializeField] private Slider _powerSlider;
    [SerializeField] private TextMeshProUGUI _helperText;

    private int _spaceBarCount = 0;
    private bool _animationRunning = false;

    private void Awake()
    {
        ChangeCameraPriority(100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_animationRunning)
        {
            switch (_spaceBarCount)
            {
                case 0:
                    StartGame();
                    _helperText.text = "";
                    _animationRunning = true;
                    break;
                case 1:
                    StartCoroutine(_cannonController.RotateCannon());
                    _helperText.text = "PRESS 'SPACE' TO CHOOSE ANGLE";
                    break;
                case 2:
                    _cannonController._playerInCannon = false;
                    _powerSlider.gameObject.SetActive(true);
                    _helperText.text = "PRESS 'SPACE' TO CHOOSE POWER";
                    break;
                case 3:
                    _cannonController._playerInCannon = false;
                    _fireParticle.Play();
                    _smokeParticle.Play();
                    _playerController.enabled = true;
                    _playerStamina.enabled = true;
                    _helperText.gameObject.SetActive(false);
                    _powerSlider.gameObject.SetActive(false);
                    break;
            }
            _spaceBarCount++;
        }
    }

    private void StartGame()
    {
        _director.Play();
        ChangeCameraPriority(10);
        _cannonController.enabled = true;
    }

    public void ChangeCameraPriority(int value)
    {
        _cannonCam.m_Priority = value;
    }

    public void ChangeAnimationRunning()
    {
        _helperText.text = "PRESS 'SPACE' TO RUN CANNON";
        _animationRunning = !_animationRunning;
    }
}
