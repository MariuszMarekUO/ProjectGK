using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // do spawnu
    [SerializeField] GameObject spawnToObject;
    [SerializeField] GameObject firstObject;
    [SerializeField] GameObject[] pickUps;


    // zmienne
    private static List<GameObject> _arrSpawnedObject = new List<GameObject>();
    private static int _id = 0;
    private int _size = 65,
                _currPos;

    private static bool _isDone = false;

    private float _rangeX,
                _rangeY,
                _rangeZ,
                countPickUps = 3;
    private int _searchPref;

    private void Awake()
    {
        // pocz¹tkowe spawnienie elementów
        if ((firstObject != null) && !_isDone)
        {
            _arrSpawnedObject.Add(firstObject);
            _arrSpawnedObject[0].name = "Obiekt " + (-1);
            _isDone = true;

            for (int i = 0; i < _size; i++)
            {
                Spawn();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _currPos = _arrSpawnedObject.IndexOf(this.gameObject);
        Spawn();
        DeleteObject(_currPos);
    }

    private void Spawn()
    {
        // tworzenie, dodawanie do listy nowych elementów mapy oraz nadawanie nazwy (podstawa czyli pod³o¿e i triggerbox)
        int lastPlatform = _arrSpawnedObject.Count - 1;
        Vector3 nextPosition = new Vector3(_arrSpawnedObject[lastPlatform].transform.position.x, _arrSpawnedObject[lastPlatform].transform.position.y, (_arrSpawnedObject[lastPlatform].transform.position.z + 5));

        _arrSpawnedObject.Add(Instantiate(spawnToObject, nextPosition, Quaternion.identity));
        _arrSpawnedObject[lastPlatform].name = "Obiekt " + _id;

        // tworzenie, dodawanie do listy nowych elementów PickUp'ów oraz nadawanie nazwy
        // te zmienne s¹ do zmiany
        _rangeX = 5; // d³ugoœæ
        _rangeY = 75; // wysokoœæ
        _rangeZ = 150f; // szerokoœæ

        for (int i = 0; i < countPickUps; i++)
        {
            _searchPref = Random.Range(0, pickUps.Length - 1);

            Vector3 randomPosition = new Vector3(Random.Range(-(_rangeZ / 2), (_rangeZ / 2)),
                                                 Random.Range(0, _rangeY),
                                                 Random.Range((_arrSpawnedObject[lastPlatform].transform.position.z - (_rangeX / 2)), (_arrSpawnedObject[lastPlatform].transform.position.z + (_rangeX / 2))));

            var newPickUp = Instantiate(pickUps[_searchPref], randomPosition, Quaternion.identity);
            newPickUp.transform.parent = _arrSpawnedObject[lastPlatform].transform;
        }
        _id++;
    }

    private void DeleteObject(int _currPos)
    {
        // usuwanie zbêdnych elementów (w if jest ustawione ¿e usuwa 3 element koñcowy tablicy)
        if (_currPos == 3)
        {
            Destroy(_arrSpawnedObject[0]);
            _arrSpawnedObject.RemoveAt(0);
        }
    }
}