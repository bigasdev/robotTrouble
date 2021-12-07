using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public StructuresObject structureData;
    public virtual void Deploy(){
        StateController.Instance.currentState = States.UI;
    }
}
