using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(WeaponsSystem))]
public sealed class WeaponsSystem : UpdateSystem 
{
    private Filter _weaponsFilter;

    private WeaponsComponent[] _weaponsComponents;

    private int count = -1;

    public override void OnAwake()
    {
        _weaponsFilter = World.Filter.With<WeaponsComponent>();

        _weaponsComponents = GetWeapons();

        SetWeapons(true);
    }

    public override void OnUpdate(float deltaTime)
    {
        for (int i = 0; i < _weaponsComponents.Length; i++)
            if (_weaponsComponents[i].click.IsPublished)
                for (int j = 0; i < _weaponsComponents[i].click.BatchedChanges.Count; j++)
                    SetWeapons(_weaponsComponents[i].click.BatchedChanges.ToArray()[j]);
    }

    private void SetWeapons(bool side)
    {
        for (int i = 0; i < _weaponsComponents.Length; i++) 
        {
            WeaponsComponent weaponsComponent = _weaponsComponents[i];

            if (side)
            {
                if (count + 1 < weaponsComponent.weaponDataList.Count)
                    count++;
                else
                    count = 0;
            }
            else
            {
                if (count - 1 >= 0)
                    count--;
                else
                    count = weaponsComponent.weaponDataList.Count - 1;
            }

            weaponsComponent.weapon = weaponsComponent.weaponDataList[count].weaponType;
            weaponsComponent.imageSprite.sprite = weaponsComponent.weaponDataList[count].sprite;
            weaponsComponent.priceText.text = weaponsComponent.weaponDataList[count].price.ToString();
        }
    }

    private WeaponsComponent[] GetWeapons()
    {
        WeaponsComponent[] weaponsComponents = new WeaponsComponent[_weaponsFilter.Length];

        for (int i = 0; i < weaponsComponents.Length; i++)
        {
            ref var coins = ref _weaponsFilter.GetEntity(i).GetComponent<WeaponsComponent>();

            weaponsComponents[i] = coins;
        }

        return weaponsComponents;
    }
}