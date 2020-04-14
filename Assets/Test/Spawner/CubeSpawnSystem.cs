using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using DG.Tweening;

[Il2CppSetOption ( Option.NullChecks, false )]
[Il2CppSetOption ( Option.ArrayBoundsChecks, false )]
[Il2CppSetOption ( Option.DivideByZeroChecks, false )]
[CreateAssetMenu ( menuName = "ECS/Systems/" + nameof ( CubeSpawnSystem ) )]
public sealed class CubeSpawnSystem : UpdateSystem
{
	private Tween waitTween;

	public override void OnAwake ( )
	{

	}

	private void StartSpawn ( )
	{

	}

	private void Spawn ( )
	{
		//GameObject obj = Instantiate()
	}

	public override void OnUpdate ( float deltaTime )
	{
	}
}