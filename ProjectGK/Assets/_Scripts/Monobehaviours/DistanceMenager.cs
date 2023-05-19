using System;
using TMPro;
using UnityEngine;

public class DistanceMenager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceText;

    private float _startposition;

    private float _distance;

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
        _distance = _startposition - transform.position.z;
        _distanceDec = Decimal.Round(((decimal)(_distance)), 2);
        distanceText.text = "Distance: " + _distanceDec;
    }
}
