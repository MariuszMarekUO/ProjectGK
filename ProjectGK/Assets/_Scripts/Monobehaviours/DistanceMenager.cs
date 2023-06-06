using System;
using TMPro;
using UnityEngine;

public class DistanceMenager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceText;

    private float _startposition;

    private float _distance;

    private bool notYet = true;

    public float Distance
    {
        get { return _distance; }
    }

    private decimal _distanceDec;

    public decimal DistanceDec
    {
        get { return _distanceDec; }
    }

    private void Awake()
    {
        _startposition = transform.position.z;
    }

    void Update()
    {
        if (notYet) { return; }
        _distance = transform.position.z - _startposition;
        _distanceDec = Decimal.Round(((decimal)(_distance)), 2);
        distanceText.text = "Distance: " + _distanceDec;
    }

    public void AllowDistance()
    {
        notYet = false;
    }
}
