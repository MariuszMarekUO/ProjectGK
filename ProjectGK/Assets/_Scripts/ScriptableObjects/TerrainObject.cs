using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TerrainObject")]
public class TerrainObject : ScriptableObject
{
    public enum ObjectType
    {
        Ground,
        MidAir,
        HighAir
    }

    [SerializeField] public GameObject[] prefabVariants;
    [SerializeField] public ObjectType _type;
}
