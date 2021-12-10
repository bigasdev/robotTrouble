using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilWrapper
{
    public static MessageUI SpawnMessage(MessageContent messageContent){
        var m = Resources.Load<MessageUI>("Prefabs/UI/MessageUI");
        var me = Object.Instantiate(m);
        me.Initialize(messageContent);
        return me;
    }
}
