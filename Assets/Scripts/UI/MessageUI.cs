using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class MessageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text, button;
    public Action onEnd = delegate {};

    public void Initialize(MessageContent messageContent){
        text.text = messageContent.message;
        button.text = messageContent.button;
    }
    public void ButtonClick(){
        onEnd();
        Destroy(this.gameObject);
    }
}
[System.Serializable]
public class MessageContent{
    [TextArea]public string message;
    public string button;

    public MessageContent(string message, string button)
    {
        this.message = message;
        this.button = button;
    }
}