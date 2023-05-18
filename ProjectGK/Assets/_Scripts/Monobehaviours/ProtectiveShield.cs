using UnityEngine;

public class ProtectiveShield : MonoBehaviour
{
    [SerializeField] PlayerHealth player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.HasProtectiveShield = true;
        }
    }
}
