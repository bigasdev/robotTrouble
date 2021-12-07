using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasExpeditionUI : CanvasObject{
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] ExpeditionCanvas canvas;
    ExpeditionDetail detail;
    public void Initialize(string _description, ExpeditionDetail _detail){
        description.text = _description;
        detail = _detail;
    }
    public void OnClick(){
        var e = Instantiate(canvas);
        e.Initialize(detail);
        Destroy(this.gameObject);
    }
}
