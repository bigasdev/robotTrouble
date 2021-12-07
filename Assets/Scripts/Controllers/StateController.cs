using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private static StateController instance;
    public static StateController Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<StateController>();
            }
            return instance;
        }
    }
    public States currentState;
    public bool CanUpdate => currentState == States.GAME;
}
public enum States{
    GAME,
    UI,
    LOST,
    PAUSE
}