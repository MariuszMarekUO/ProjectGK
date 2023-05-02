using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBounce : MonoBehaviour
{
    [SerializeField] float speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((Vector3.up * speed) + (Vector3.forward * speed), ForceMode.Impulse);
        }
    }
}
