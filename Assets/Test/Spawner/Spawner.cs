using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System.Collections.Generic;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[System.Serializable]
public struct Spawner : IComponent
{
	public enum SpawnObjectsType
	{
		Arrow,
		Birds,
	}

	public GameObject spawnPrefab;
	public float delayBetweenSpawn;

	public Pool [ ] _pools;

	//private Dictionary<SpawnObjectsType, Pool> _poolsByType = new Dictionary<SpawnObjectsType, Pool> ( );
}