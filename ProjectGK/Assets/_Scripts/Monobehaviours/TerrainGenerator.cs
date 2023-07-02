using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GameObject _linePrefab;
    [SerializeField] TerrainObject[] _terrainObjects;

    [SerializeField] Vector3 firstObjPosition;

    [SerializeField] private int _beginSize = 100;
    [SerializeField] private int _maxObjectOnLine = 5;

    [SerializeField] private float _rangeX, _minY, _maxY, _rangeZ;


    private static List<GameObject> _generatedLines;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _generatedLines = new List<GameObject>();
        for(int i = 0; i < _beginSize; i++)
        {
            GenerateLine();
        }
    }


    private void GenerateLine()
    {
        Vector3 position = _generatedLines.Count() > 0 ? _generatedLines.Last().transform.position + new Vector3(0, 0, 5) : firstObjPosition;
        _generatedLines.Add(Instantiate(_linePrefab, position, Quaternion.identity));
        GenerateTerrainObjects(_generatedLines.Last().transform);
    }

    private void GenerateTerrainObjects(Transform lastLine)
    {
        for(int i = 0; i < _maxObjectOnLine; i++)
        {
            TerrainObject randomTerrainObj = _terrainObjects[Random.Range(0, _terrainObjects.Length)];
            GameObject terrainObjVariant = randomTerrainObj.prefabVariants[Random.Range(0, randomTerrainObj.prefabVariants.Count())];

            switch (randomTerrainObj._type)
            {
                case TerrainObject.ObjectType.Ground:
                    _minY = 2;
                    _maxY = 2;
                    break;
                case TerrainObject.ObjectType.MidAir:
                    _minY = 10;
                    _maxY = 50;
                    break;
                case TerrainObject.ObjectType.HighAir:
                    _minY = 50;
                    _maxY = 150;
                    break;
            }
            
            Vector3 randomPosition = new Vector3(Random.Range(-_rangeX, _rangeX), Random.Range(_minY, _maxY), Random.Range(-_rangeZ, _rangeZ));
            Vector3 position = lastLine.position + randomPosition;

            GameObject generatedObject = Instantiate(terrainObjVariant, position, Quaternion.identity);
            generatedObject.transform.parent = lastLine.transform;
        }
    }

    private void RemoveLastLine()
    {
        Destroy(_generatedLines[0]);
        _generatedLines.RemoveAt(0);
    }

    public void PlayerHitTrigger()
    {
        RemoveLastLine();
        GenerateLine();
    }
}
