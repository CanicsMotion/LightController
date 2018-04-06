using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour {
    [SerializeField] BlasterObject preset;
    public BlasterObject local;

    public Transform repr;
    public new Light light;
    [System.Serializable]
    public struct RotLink {
        public enum axle {
            X,Y,Z
        }
        public Transform transform;
        public float rotation;
        public float begin;
        public float target;
        public float lastBegin;
        public axle ax;
    }
    public RotLink[] links;
    public AnimationCurve curve;

    void Start () {
        setLocal(preset);//copiere das Prefap auf die localen Variabeln
    }

    public void Rotate(float[] angles) {
        for (int i = 0; i < links.Length; i++) {
            try {
                links[i].target = angles[i];
            }
            catch { }

            links[i].begin = links[i].rotation;
            links[i].lastBegin = 0f;
        }
    }

    public void Look(Vector3 pos) {
        var q = Quaternion.LookRotation(pos-transform.position, Vector3.up);
        var a = q.eulerAngles;
        float[] f = {a.x,a.y,a.z };
        Rotate(f);
    }

    void setLocal(BlasterObject obj) {
        local = preset;
        if (local.shape != null)
            light.cookie = local.shape.texture;
        light.color = local.colors.Evaluate(0f);
    }
	

	void Update () {
        for (int i = 0; i < links.Length; i++) {

            links[i].lastBegin = Mathf.MoveTowards(links[i].lastBegin, 1f, Time.deltaTime);

            links[i].rotation = Mathf.Lerp(links[i].begin, links[i].target, curve.Evaluate(links[i].lastBegin));

            Quaternion q = Quaternion.identity;
            if (links.Length>=i) {
                switch (links[i].ax) {
                    case RotLink.axle.X: q= Quaternion.Euler(links[i].rotation,0 , 0);break;
                    case RotLink.axle.Y: q = Quaternion.Euler(0, links[i].rotation, 0); break;
                    case RotLink.axle.Z: q = Quaternion.Euler(0, 0,links[i].rotation); break;
                }
                links[i].transform.localRotation = q;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (links.Length > 0) {
                float[] f = { links[0].rotation + 45, 45 - links[1].rotation };

                Rotate(f);
            }
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            Look(GameObject.Find("Target").transform.position);
        }
    }
}
