using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterlineHandler : MonoBehaviour
{
    private GameObject _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _gameManager.GetComponent<TerrainGenerator>().PlayerHitTrigger();
        }
    }
}
