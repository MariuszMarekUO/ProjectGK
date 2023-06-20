using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] PlayerHealth player;
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject trials;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        smoke.SetActive(false);
        fire.SetActive(false);
        trials.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage();
        }

        this.transform.localScale = new Vector3(0, 0, 0);
        smoke.SetActive(true);
        fire.SetActive(true);
        trials.SetActive(true);
    }
}
