using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Basic pool class. Contains pool settings and references to pooled objects.
/// </summary>
[Serializable]
public class Pool
{
	#region Variables

	/// <summary>
	/// Pool type, use it get reference to pool at Spawner
	/// </summary>
	public Spawner.SpawnObjectsType objectType;

	/// <summary>
	/// Reference to object which shood be pooled.
	/// </summary>
	[Space ( 5 )]
	public GameObject objectToPool;
	/// <summary>
	/// Number of objects which be created be deffault.
	/// </summary>
	[SerializeField] public int poolSize = 10;
	/// <summary>
	/// True means: if there is no available object, the new one will be added to a pool.
	/// Otherwise will be returned null.
	/// </summary>
	public bool willGrow = true;
	/// <summary>
	/// List of pooled objects.
	/// </summary>
	public List<GameObject> pooledObjects;


	#endregion

	#region Public methods

	public GameObject GetPooledObject ( )
	{
		for ( int i = 0; i < pooledObjects.Count; i++ )
		{
			if ( !pooledObjects [ i ].activeInHierarchy )
			{
				return pooledObjects [ i ];
			}
		}

		if ( willGrow )
		{
			return AddObjectToPool ( );
		}

		return null;
	}

	public void InitializePool ( )
	{
		pooledObjects = new List<GameObject> ( );

		if ( objectToPool != null )
		{
			for ( int i = 0; i < poolSize; i++ )
			{
				AddObjectToPool ( );
			}
		}
		else
		{
			Debug.LogError ( "There's no attached prefab at pool: \"" + objectType + "\"" );
		}
	}

	#endregion

	#region Main methods

	private GameObject AddObjectToPool ( )
	{
		GameObject inst = ( GameObject ) MonoBehaviour.Instantiate ( objectToPool );
		inst.SetActive ( false );
		pooledObjects.Add ( inst );

		return inst;
	}

	#endregion
}
