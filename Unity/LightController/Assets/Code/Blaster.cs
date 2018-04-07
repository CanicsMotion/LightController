using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {
    [SerializeField] BlasterObject preset;
    [System.NonSerialized] public BlasterObject local;

    public Transform repr;
    public new Light light;
    

    public virtual void Start () {
        setLocal(preset);//copiere das Prefap auf die localen Variabeln
    }

    



    void setLocal(BlasterObject obj) {
        local = preset;
        if (local.shape != null)
            light.cookie = local.shape.texture;
        light.color = local.colors.Evaluate(0f);
    }


    public virtual void Update () {
        
    }
}
