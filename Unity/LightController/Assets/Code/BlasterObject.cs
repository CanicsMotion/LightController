using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum blasterMode{
    Spot,
    Wash,
    Zoom,
    Beam,
    SpotBeam,
    WashZoom,

}

[CreateAssetMenu(fileName ="new Blaster",menuName ="Blaster",order =50)]
public class BlasterObject : ScriptableObject {
    public string Name = "Blaster Name";
    public string ModelCode = "M0D3L";
    public Mesh mesh = null;
    public blasterMode mode = blasterMode.Spot;
    public Gradient colors = new Gradient();
    public Sprite[] gobos = null;
}
