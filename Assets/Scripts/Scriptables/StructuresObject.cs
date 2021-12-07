using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure", menuName = "Data/Structure", order = 1)]
public class StructuresObject : ScriptableObject
{
    public string structureCallback;
    [TextArea] public string structureDescription;
    public Sprite image;
}
