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
    public int newColor;
    public int newGobo;
    public void Execute() {
        switch (type) {
            case eventType.print: Debug.Log(string.Format("<Event at {0} -{1}->", time, printMsg));break;
            case eventType.lookTowarts:
            foreach (var item in targets) {
                ((MovingHead)item).Look(lookDir);
            }
            break;
            case eventType.colorChange:
                foreach (var item in targets) {
                    item.colorWheelPosition = newColor;
                }
            break;
            case eventType.gobo:
            foreach (var item in targets) {
                item.goboWheelPosition = newGobo;
            }
            break;
            case eventType.reset:
                foreach (var item in targets) {
                    item.Reset();
                }
            break;
            default:break;
        }
        
    }


    public Event(Blaster[] targets, float time, eventType type) {
        this.targets = targets;
        this.time = time;
        this.type = type;
        lookDir = Vector3.zero;
        printMsg = "";
        newColor = 0;
        newGobo = 0;
    }
}

public enum eventType {
    print,
    lookTowarts,
    colorChange,
    reset,
    gobo,

}