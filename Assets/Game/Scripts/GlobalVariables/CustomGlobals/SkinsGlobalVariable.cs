using UnityEngine;
using Morpeh.Globals;
using Unity.IL2CPP.CompilerServices;
using System;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Globals/Custom/" + nameof(SkinsGlobalVariable))]
public sealed class SkinsGlobalVariable : BaseGlobalVariable<SkinsEnum> 
{
    public override IDataWrapper Wrapper
    {
        get => new SkinsWrapper { value = this.value };
        set => this.Value = ((SkinsWrapper)value).value;
    }

    protected override SkinsEnum Load(string serializedData) => (SkinsEnum)Enum.Parse(typeof(SkinsEnum), serializedData);

    protected override string Save() => this.value.ToString();

    [System.Serializable]
    private class SkinsWrapper : IDataWrapper
    {
        public SkinsEnum value;
    }
}