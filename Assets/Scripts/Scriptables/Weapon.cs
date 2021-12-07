using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;
    [TextArea] public string weaponDescription;
    public Sprite sprite;
    public int attack;
    public int defense;
}
