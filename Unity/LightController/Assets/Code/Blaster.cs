using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {
    [SerializeField] BlasterObject preset;
    [System.NonSerialized] public BlasterObject local;

    public Transform repr;
    public new Light light;
    public new Light lightbulb;
    [Range(0, 16)]
    public int colorWheelPosition = 0;
    [Range(0, 16)]
    public int goboWheelPosition = 0;
    public bool rotation = true;
    public bool shutter = false;
    [Range(0, 5)]
    public float rotationSpeed = 0f;

    public virtual void Start () {
        setLocal(preset);//kopiere das Prefap auf die localen Variabeln
    }

    



    void setLocal(BlasterObject obj) {
        local = preset;

        if (local.gobos.Length != 0 && local.gobos[goboWheelPosition] != null)
                light.cookie = local.gobos[goboWheelPosition].texture;     //set Shape(Gobo)
            else
                light.cookie = null;
        if (shutter == false) {
            if (local.colors.Length != 0 && local.colors[colorWheelPosition] != null) {
                light.color = local.colors[colorWheelPosition];        //set Color(Beam)
                lightbulb.color = local.colors[colorWheelPosition];    //set Colror(Lightbulb)
            }else {
                light.color = Color.white;
                lightbulb.color = Color.white;
            }
        }
        else {
            light.color = Color.black;
            lightbulb.color = Color.black;
        }
    }


    public virtual void Update () {
        if (goboWheelPosition > local.gobos.Length-1)
            goboWheelPosition = local.gobos.Length-1;

        if (colorWheelPosition > local.colors.Length - 1)
            colorWheelPosition = local.colors.Length - 1;

        if (local.gobos.Length != 0 && local.gobos[goboWheelPosition] != null)
                light.cookie = local.gobos[goboWheelPosition].texture;     //set Shape(Gobo)
            else
                light.cookie = null;

        if (shutter == false)
        {
            if (local.colors.Length != 0 && local.colors[colorWheelPosition] != null)
            {
                light.color = local.colors[colorWheelPosition];        //set Color(Beam)
                lightbulb.color = local.colors[colorWheelPosition];    //set Colror(Lightbulb)
            }
            else
            {
                light.color = Color.white;
                lightbulb.color = Color.white;
            }
        }
        else
        {
            light.color = Color.black;
            lightbulb.color = Color.black;
        }
    }
}
