using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[Serializable]
public struct Cube : IComponent
{
	public event Action<Vector3> OnUpdateTarget;

	public float moveSpeed;
	public Transform transform;

	public void UpdateTarget ( Vector3 targetPosition )
	{
		//MoveToPosition ( targetPosition );
		OnUpdateTarget.Invoke ( targetPosition );
	}

	private void MoveToPosition ( Vector3 targetPosition )
	{
		transform.position = Vector3.Lerp ( transform.position, targetPosition, moveSpeed * Time.deltaTime );
	}

}