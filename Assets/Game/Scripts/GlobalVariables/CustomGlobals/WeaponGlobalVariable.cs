using UnityEngine;
using Morpeh.Globals;
using Unity.IL2CPP.CompilerServices;
using JetBrains.Annotations;
using System.Globalization;
using System;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Globals/Custom/" + nameof(WeaponGlobalVariable))]
public sealed class WeaponGlobalVariable : BaseGlobalVariable<WeaponEnum>
{
    public override IDataWrapper Wrapper 
    {
        get => new WeaponWrapper { value = this.value };
        set => this.Value = ((WeaponWrapper)value).value;
    }

    protected override WeaponEnum Load(string serializedData) => (WeaponEnum) Enum.Parse(typeof(WeaponEnum), serializedData);

    protected override string Save() => this.value.ToString();

    [System.Serializable]
    private class WeaponWrapper : IDataWrapper
    {
        public WeaponEnum value;
    }
}