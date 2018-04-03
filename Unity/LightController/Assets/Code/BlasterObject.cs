using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum blasterMode{
    Spoter,

}

[CreateAssetMenu(fileName ="new Blaster",menuName ="Blaster",order =50)]
public class BlasterObject : ScriptableObject {
    public string Name = "Blaster Name";
    public string ModelCode = "M0D3L";
    public Mesh mesh = null;
    public blasterMode mode = blasterMode.Spoter;
    public Gradient colors = new Gradient();
    public Sprite shape = null;
}
