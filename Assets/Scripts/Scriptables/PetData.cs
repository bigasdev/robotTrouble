using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Data/Pet", order = 1)]
public class PetData : ScriptableObject
{
    public string petName;
    [TextArea] public string petDescription;
    public Sprite petSprite;
    public PetRewards petRewards;
}
[System.Serializable] 
public class PetRewards{
    public int maxGold;
    public MaterialData[] possibleRewards;

    public PetRewards(int maxGold, MaterialData[] possibleRewards)
    {
        this.maxGold = maxGold;
        this.possibleRewards = possibleRewards;
    }
}