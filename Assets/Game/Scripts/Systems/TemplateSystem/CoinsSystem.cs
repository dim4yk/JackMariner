using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CoinsSystem))]
public sealed class CoinsSystem : UpdateSystem 
{
    private Filter _coinsFilter;

    private СoinsComponent[] _coinsComponents;

    public override void OnAwake()
    {
        _coinsFilter = World.Filter.With<СoinsComponent>();

        _coinsComponents = GetCoinsTexts();

        SetText();
    }

    public override void OnUpdate(float deltaTime)
    {
        for (int i = 0; i < _coinsComponents.Length; i++)
            if (_coinsComponents[i].coins)
                SetText();
    }

    private void SetText()
    {
        for (int i = 0; i < _coinsComponents.Length; i++)
            _coinsComponents[i].coinText.text = "Coins: " + _coinsComponents[i].coins.Value;
    }

    private СoinsComponent[] GetCoinsTexts()
    {
        СoinsComponent[] coinsComponents = new СoinsComponent[_coinsFilter.Length];

        for (int i = 0; i < coinsComponents.Length; i++)
        {
            ref var coins = ref _coinsFilter.GetEntity(i).GetComponent<СoinsComponent>();

            coinsComponents[i] = coins;
        }

        return coinsComponents;
    }
}