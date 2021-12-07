using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition : Structure
{
    [SerializeField] ExpeditionDetail detail;
    CanvasExpeditionUI canvas;
    public override void Deploy()
    {
        base.Deploy();
        if(canvas != null){
            Destroy(canvas.gameObject);
            canvas = null;
        }
        var c = Resources.Load<CanvasExpeditionUI>("Prefabs/UI/CanvasExpeditionUI");
        canvas = Instantiate(c);
        canvas.Initialize(structureData.structureDescription, detail);
    }
}
