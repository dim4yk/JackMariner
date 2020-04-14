using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[CreateAssetMenu ( menuName = "ECS/Systems/" + nameof ( CubeMoveSystem ) )]
public sealed class CubeMoveSystem : UpdateSystem
{
	private enum Directions
	{
		Left,
		Right,
	}

	private Filter _cubeFilter;

	public override void OnAwake ( )
	{
		_cubeFilter = World.Filter.With<Cube> ( );

		Subscribe ( );
	}

	public override void Dispose ( )
	{
		Unsubscribe ( );
	}

	private void Subscribe ( )
	{
		for ( int i = 0, length = _cubeFilter.Length; i < length; i++ )
		{
			ref var cube = ref _cubeFilter.GetEntity ( i ).GetComponent<Cube> ( );

			cube.OnUpdateTarget += MoveToPosition;
		}
	}

	private void Unsubscribe ( )
	{
		for ( int i = 0, length = _cubeFilter.Length; i < length; i++ )
		{
			ref var cube = ref _cubeFilter.GetEntity ( i ).GetComponent<Cube> ( );

			cube.OnUpdateTarget -= MoveToPosition;
		}
	}


	public override void OnUpdate ( float deltaTime )
	{

	}

	private void MoveToPosition ( Vector3 targetPosition )
	{
		for ( int i = 0, length = _cubeFilter.Length; i < length; i++ )
		{
			ref var cube = ref _cubeFilter.GetEntity ( i ).GetComponent<Cube> ( );

			cube.transform.position = Vector3.Lerp ( cube.transform.position, targetPosition, cube.moveSpeed * Time.deltaTime );
		}
	}



}