using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct EventUpdate {

    public enum eventChanges{
        pan = 1, //seiten bewegung links/rechts
        color = 2, //neue farbe
        reset = 4, //ein reset befehl
        roll = 8, //dreh den gobo
        tilt = 16, //neigung nach oben/unten
        gogo = 32, //mask change
        dimm = 64, //licht intensität
    }

    public int whatToChange;
    public float pan;
    public float tilt;
    public float rollSpeed;
    public int newColor;
    public int newGogo;
    public float dimm; //1 full bright, 0 dark

    public float time;


    public EventUpdate(params eventChanges[] ch) {

        pan = 0;
        tilt = 0;
        rollSpeed = 0;
        newColor = 0;
        newGogo = 0;
        dimm = 0;

        time = 0;

        whatToChange = 0x00;
        foreach (var item in ch) {
            whatToChange |= (int)item;
        }
    }
}
