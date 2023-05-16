using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMenager : MonoBehaviour
{
    public float distance;
    public float startPosition;
    public Text distanceText;

    private void Start()
    {
        startPosition = transform.position.x;
    }
    void Update()
    {
        distance = transform.position.x - startPosition;
        distanceText.text = "Distance: " + distance;
    }
}
