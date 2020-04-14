using UnityEngine;

public class WeaponData : ScriptableObject
{
    [SerializeField]
    private WeaponEnum _weaponType;

    [SerializeField]
    private int _price;

    [SerializeField]
    private Sprite _sprite;

    public WeaponEnum weaponType => _weaponType;

    public int price => _price;

    public Sprite sprite => _sprite;

    // Will be all characteristics
}
