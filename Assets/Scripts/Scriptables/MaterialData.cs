using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "Data/Material", order = 1)]
public class MaterialData : ScriptableObject
{
    public string materialName;
    [TextArea] public string description;
    public Sprite materialSprite;
}
