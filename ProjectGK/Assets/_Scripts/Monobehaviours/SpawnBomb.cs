using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform player;
    public float minInterval = 1f;
    public float maxInterval = 3f;
    public float spawnDistance = 10f;

    private float timer = 0f;
    private float bombInterval = 0f;

    private void Start()
    {
        SetRandomInterval();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= bombInterval)
        {
            GenerateBomb();
            timer = 0f;
            SetRandomInterval();
        }
    }

    private void SetRandomInterval()
    {
        bombInterval = Random.Range(minInterval, maxInterval);
    }

    private void GenerateBomb()
    {
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
}
