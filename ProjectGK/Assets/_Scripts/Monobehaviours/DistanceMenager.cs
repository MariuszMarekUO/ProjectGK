using System;
using TMPro;
using UnityEngine;

public class DistanceMenager : MonoBehaviour
{
    private bool notYet = true;
    private float distance;
    public float Distance
    {
        get { return distance; }
    }
    private decimal _d;
    public decimal D
    {
        get { return _d; }
    }

    private Rigidbody _rb;
    [SerializeField] TextMeshProUGUI distanceText;

    void Update()
    {
        if (notYet) { return; }
        distance = transform.position.z;
        _d = Decimal.Round(((decimal)(distance)), 2);
        distanceText.text = "Distance: " + _d;
    }

    public void AllowDistance()
    {
        notYet = false;
    }
}
