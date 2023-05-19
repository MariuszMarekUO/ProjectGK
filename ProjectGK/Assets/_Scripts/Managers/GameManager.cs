using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

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

    private int _spaceBarCount = 0;

    private void Awake()
    {
        ChangeCameraPriority(100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_spaceBarCount)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    StartCoroutine(_cannonController.RotateCannon());
                    break;
                case 2:
                    _cannonController._playerInCannon = false;
                    break;
                case 3:
                    _cannonController._playerInCannon = false;
                    _fireParticle.Play();
                    _smokeParticle.Play();
                    _playerController.enabled = true;
                    _playerStamina.enabled = true;
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
}
