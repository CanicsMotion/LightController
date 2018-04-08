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
    [Range(5, 30)]
    public int zoom = 15;
    public bool rotation = false;
    public bool shutter = false;
    public bool strobe = false;
    [Range(-20, 20)]
    public float rotationSpeed = 5;
    [Range(0, 25)]
    public float strobeSpeed = 5;

    public virtual void Start () {
        setLocal(preset);//kopiere das Prefap auf die localen Variabeln
        Reset();
    }

    



    void setLocal(BlasterObject obj) {
        local = preset;
    }

    public void Reset() {
        colorWheelPosition = 0;
        goboWheelPosition = 0;
        zoom = 15;
        rotation = false;
        shutter = false;
        strobe = false;
        rotationSpeed = 5;
        strobeSpeed = 5;

    }


    public virtual void Update () {

        if (Input.GetKeyDown(KeyCode.R))
            Reset();

        if (rotation)
        {
            light.transform.Rotate(new Vector3(0, 0, rotationSpeed * -20 * Time.deltaTime));
        }

        light.spotAngle = zoom;

        if(strobe == true){
            light.enabled = lightbulb.enabled = Random.Range(0, 100) < strobeSpeed * 2;
        }
        else {
            light.enabled = lightbulb.enabled = true;
        }


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
        else{
            light.color = lightbulb.color = Color.black;
        }
    }
}
