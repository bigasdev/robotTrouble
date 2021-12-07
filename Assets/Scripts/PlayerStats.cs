using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;
    public static PlayerStats Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<PlayerStats>();
            }
            return instance;
        }
    }
    public UnitStats playerStats;
}
