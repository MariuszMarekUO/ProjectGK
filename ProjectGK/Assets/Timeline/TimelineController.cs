using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [SerializeField] BoxCollider cannonCollider;

    public void Freeze()
    {
        cannonCollider.enabled = false;
    }

    public void Release()
    {
        cannonCollider.enabled = true;
    }
}
