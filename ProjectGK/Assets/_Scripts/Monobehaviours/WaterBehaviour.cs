using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z);
    }
}
