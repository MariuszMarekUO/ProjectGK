using UnityEngine;

public class ExtraHeart : MonoBehaviour
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
            player.AddHeart();
        }
    }
}
