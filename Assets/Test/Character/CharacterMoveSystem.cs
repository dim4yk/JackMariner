using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[CreateAssetMenu ( menuName = "ECS/Systems/" + nameof ( CharacterMoveSystem ) )]
public sealed class CharacterMoveSystem : UpdateSystem
{
	private Filter _characterFilter;

	private float test;

	public override void OnAwake ( )
	{
		_characterFilter = World.Filter.With<CharacterComponent> ( );
	}

	public override void OnUpdate ( float deltaTime )
	{
		if ( Input.GetMouseButton ( 0 ) )
			MoveToTarget ( );
	}

	private void MoveToTarget ( )
	{
		CharacterComponent [ ] characters = GetCharacters ( );

		Vector3 targetPosition = GetTargetPosition ( );

		for ( int i = 0; i < characters.Length; i++ )
		{
			characters [ i ].selfTransform.position = Vector3.Lerp ( characters [ i ].selfTransform.position, targetPosition, characters [ i ].moveSpeed * Time.deltaTime );
		}
	}

	private Vector3 GetTargetPosition ( )
	{
		Vector3 result = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		result.z = 0;
		return result;
	}

	private CharacterComponent [ ] GetCharacters ( )
	{
		CharacterComponent [ ] characters = new CharacterComponent [ _characterFilter.Length ];

		for ( int i = 0, length = _characterFilter.Length; i < length; i++ )
		{
			ref var character = ref _characterFilter.GetEntity ( i ).GetComponent<CharacterComponent> ( );

			characters [ i ] = character;
		}

		return characters;
	}
}