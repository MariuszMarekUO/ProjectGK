using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerStamina playerStamina;
    [SerializeField] BoxCollider cannonCollider;

    public void Freeze()
    {
        playerController.enabled = false;
        playerStamina.enabled = false;
        cannonCollider.enabled = false;
    }

    public void Release()
    {
        playerController.enabled = true;
        playerStamina.enabled = true;
        cannonCollider.enabled = true;
    }
}
