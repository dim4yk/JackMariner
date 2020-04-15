using UnityEngine;
using Morpeh.Globals;
using Unity.IL2CPP.CompilerServices;
using System;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Globals/Custom/" + nameof(LocationsGlobalVariable))]
public sealed class LocationsGlobalVariable : BaseGlobalVariable<LocationsEnum> 
{
    public override IDataWrapper Wrapper
    {
        get => new LocationsWrapper { value = this.value };
        set => this.Value = ((LocationsWrapper)value).value;
    }

    protected override LocationsEnum Load(string serializedData) => (LocationsEnum)Enum.Parse(typeof(LocationsEnum), serializedData);

    protected override string Save() => this.value.ToString();

    [System.Serializable]
    private class LocationsWrapper : IDataWrapper
    {
        public LocationsEnum value;
    }
}