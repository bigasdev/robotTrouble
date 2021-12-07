using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Expedition", menuName = "Data/Expedition", order = 1)]
public class ExpeditionDetail : ScriptableObject
{
    public string expeditionName;
    public string expeditionDescription;
    public Sprite creatureImage;
    public UnitStats creatureStats;
}
[System.Serializable]
public class UnitStats{
    public int attack;
    public int health;

    public UnitStats(int attack, int health)
    {
        this.attack = attack;
        this.health = health;
    }
}
