using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Event  {
    public Blaster[] targets;
    public float time;
    public eventType type;
    public Vector3 lookDir;
    public string printMsg;
    public void Execute() {
        switch (type) {
            case eventType.print: Debug.Log(string.Format("<Event at {0} -{1}->", time, printMsg));break;
            case eventType.lookTowarts:
            foreach (var item in targets) {
                ((MovingHead)item).Look(lookDir);
            }
            break;
            default:break;
        }
        
    }
}

public enum eventType {
    print,
    lookTowarts
}