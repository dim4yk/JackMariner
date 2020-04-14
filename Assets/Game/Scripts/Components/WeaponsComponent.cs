using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.UI;
using System.Collections.Generic;
using Morpeh.Globals;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[System.Serializable]
public struct WeaponsComponent : IComponent 
{
    public WeaponEnum weapon;

    public Image imageSprite;

    public Text priceText;

    public List<WeaponData> weaponDataList;

    public GlobalEventBool click;
}