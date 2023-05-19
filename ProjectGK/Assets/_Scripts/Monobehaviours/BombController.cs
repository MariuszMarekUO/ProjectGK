using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject trials;

    private void Awake()
    {
        smoke.SetActive(false);
        fire.SetActive(false);
        trials.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        smoke.SetActive(true);
        fire.SetActive(true);
        trials.SetActive(true);
    }
}
