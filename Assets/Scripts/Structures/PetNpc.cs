using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetNpc : Structure
{
    [SerializeField] PetData pet;
    [SerializeField] MessageContent noPetText, yesPetText;
    public bool isUnlocked = false;
    MessageUI messageUI;
    public override void Deploy()
    {
        base.Deploy();
        if(isUnlocked){
            messageUI = UtilWrapper.SpawnMessage(yesPetText);
            messageUI.onEnd += PetClick;
        }else{
            messageUI = UtilWrapper.SpawnMessage(noPetText);
            messageUI.onEnd += CloseClick;
        }
    }
    void ButtonClick(){
        if(isUnlocked){
            StateController.Instance.ReturnToInitialState();
            PlayerStats.Instance.pet = pet;
        }else{
            StateController.Instance.ReturnToInitialState();
        }
    }
    void CloseClick(){
        StateController.Instance.ReturnToInitialState();
    }
    void PetClick(){
        StateController.Instance.ReturnToInitialState();
        PlayerStats.Instance.pet = pet;
    }
}
