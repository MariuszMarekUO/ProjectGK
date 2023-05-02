using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUp : MonoBehaviour
{
    [SerializeField] float speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }
}
