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


    [SerializeField] GameObject[] clouds;
    [SerializeField] GameObject[] airPickUps;
    [SerializeField] GameObject[] groundPickUps;
    [SerializeField] GameObject[] obstacle;
    [SerializeField] GameObject[] islands;

    // zmienne
    private static List<GameObject> _arrSpawnedObject = new List<GameObject>();
    private static int _id = 0;
    private int _size = 65,
                _currPos,
                _variant,
                _probabilityObstacle, 
                _probabilityIslands;

    private static bool _isDone = false;

    private float _rangeX = 5,
                _rangeY = 75,
                _rangeZ = 150,
                countPickUps = 3;
    private int _searchPref;

    private void Awake()
    {
        firstObject = transform.gameObject;
        // pocz�tkowe spawnienie element�w
        if ((firstObject != null) && !_isDone)
        {
            Debug.Log("WYKONA�O SIE");
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
        // tworzenie, dodawanie do listy nowych element�w mapy oraz nadawanie nazwy (podstawa czyli pod�o�e i triggerbox)
        int lastPlatform = _arrSpawnedObject.Count - 1;
        Vector3 nextPosition = new Vector3(_arrSpawnedObject[lastPlatform].transform.position.x, _arrSpawnedObject[lastPlatform].transform.position.y, (_arrSpawnedObject[lastPlatform].transform.position.z + 5));

        _arrSpawnedObject.Add(Instantiate(spawnToObject, nextPosition, Quaternion.identity));
        _arrSpawnedObject[lastPlatform].name = "Obiekt " + _id;

        // tworzenie, dodawanie do listy nowych element�w PickUp'�w oraz nadawanie nazwy
        for (int i = 0; i < countPickUps; i++)
        {
            _variant = Random.RandomRange(1, 4);

            switch (_variant)
            {
                case 1:
                    SpawnElements(clouds, lastPlatform, 100, 25, -90, 0);
                    break;
                case 2:
                    SpawnElements(airPickUps, lastPlatform, 75, 15, 0, 90);
                    break;
                case 3:
                    SpawnElements(groundPickUps, lastPlatform, 0.35f, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }

        // losowe generowanie przeszk�d
        _probabilityObstacle = Random.RandomRange(1, 11);
        if(_probabilityObstacle == 1)
        {
            SpawnElements(obstacle, lastPlatform, 100, 0.35f, 0, 0);
        }

        // losowe generowanie dodatkowych wysp
        _probabilityIslands = Random.RandomRange(1, 5);
        if(_probabilityIslands == 1)
        {
            SpawnElements(islands, lastPlatform, 0.35f, 0, 0, 0);
        }

        _id++;
    }
    void SpawnElements(GameObject[] arrObj, int lastPlatform, float maxH, float minH, float rotX, float rotY)
    {
        _searchPref = Random.Range(0, arrObj.Length - 1);

        Vector3 randomPosition = new Vector3(Random.Range(-(_rangeZ / 2), (_rangeZ / 2)),
                                             Random.Range(minH, maxH),
                                             Random.Range((_arrSpawnedObject[lastPlatform].transform.position.z - (_rangeX / 2)), (_arrSpawnedObject[lastPlatform].transform.position.z + (_rangeX / 2))));

        // Quaternion zmieni� p�niej tak �eby nie trzeba by�o tego w kodzie ustawia�
        var newPickUp = Instantiate(arrObj[_searchPref], randomPosition, Quaternion.Euler(new Vector3(rotX, rotY, 0)));
        newPickUp.transform.parent = _arrSpawnedObject[lastPlatform].transform;
    }

    private void DeleteObject(int _currPos)
    {
        // usuwanie zb�dnych element�w (w if jest ustawione �e usuwa 3 element ko�cowy tablicy)
        if (_currPos == 3)
        {
            if(_arrSpawnedObject[0].tag != "DONTDESTROY")
            {
                Destroy(_arrSpawnedObject[0]);
                _arrSpawnedObject.RemoveAt(0);

            }
        }
    }
}