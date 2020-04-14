using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[CreateAssetMenu ( menuName = "ECS/Systems/" + nameof ( CubeInputSystem ) )]
public sealed class CubeInputSystem : UpdateSystem
{
	private Filter _cubeFilter;

	public override void OnAwake ( )
	{
		_cubeFilter = World.Filter.With<Cube> ( );

	}

	public override void OnUpdate ( float deltaTime )
	{
		if ( Input.GetMouseButton ( 0 ) ) TapUpdate ( );
	}

	private void TapUpdate ( )
	{
		Vector3 targetPosition = GetTargetPosition ( );

		for ( int i = 0, length = _cubeFilter.Length; i < length; i++ )
		{
			ref var cube = ref _cubeFilter.GetEntity ( i ).GetComponent<Cube> ( );

			cube.UpdateTarget ( targetPosition );
		}
	}

	private Vector3 GetTargetPosition ( )
	{
		Vector3 result = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		result.z = 0;
		return result;
	}

}