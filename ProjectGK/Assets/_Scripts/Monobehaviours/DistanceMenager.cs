using System;
using TMPro;
using UnityEngine;

public class DistanceMenager : MonoBehaviour
{
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
        distance = transform.position.z;
        _d = Decimal.Round(((decimal)(distance)), 2);
        distanceText.text = "Distance: " + _d;
    }
}
