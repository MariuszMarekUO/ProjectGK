using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    void Update()
    {
        transform.position = _playerTransform.position;
    }
}
