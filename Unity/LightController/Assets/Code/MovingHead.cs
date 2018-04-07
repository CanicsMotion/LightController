﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHead : Blaster {

    [System.Serializable]
    public struct RotLink {
        public enum axle {
            X, Y, Z
        }
        public Transform transform;
        public float rotation;
        public float begin;
        public float target;
        public float lastBegin;
        public axle ax;
        public bool wrap;
    }
    public RotLink[] links;
    public AnimationCurve curve;

    // Use this for initialization
    public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();

        for (int i = 0; i < links.Length; i++) {

            links[i].lastBegin = Mathf.MoveTowards(links[i].lastBegin, 1f, Time.deltaTime);
            if (links[i].wrap)
                links[i].rotation = Mathf.LerpAngle(links[i].begin, links[i].target, curve.Evaluate(links[i].lastBegin));
            else
                links[i].rotation = Mathf.Lerp(links[i].begin, links[i].target, curve.Evaluate(links[i].lastBegin));

            Quaternion q = Quaternion.identity;
            if (links.Length >= i) {
                switch (links[i].ax) {
                    case RotLink.axle.X: q = Quaternion.Euler(links[i].rotation, 0, 0); break;
                    case RotLink.axle.Y: q = Quaternion.Euler(0, links[i].rotation, 0); break;
                    case RotLink.axle.Z: q = Quaternion.Euler(0, 0, links[i].rotation); break;
                }
                links[i].transform.localRotation = q;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (links.Length > 0) {
                float[] f = { links[0].rotation + 90 + Random.Range(-20, 20), 45 - links[1].rotation + Random.Range(-20, 20) + 20 };

                Rotate(f);
            }
        }
        if (TargetPlacer.instance && (Input.GetMouseButtonDown(0))) {
            Look(TargetPlacer.instance.transform.position);
        }

    }

    public void Rotate(float[] angles) {
        
        for (int i = 0; i < links.Length; i++) {
            links[i].begin = links[i].rotation;

            if (links[i].wrap)
                links[i].target = Mathf.Repeat(angles[i], 360);
            else
                links[i].target = Mathf.Clamp(angles[i], -180, 180);


            links[i].lastBegin = 0f;
        }
    }

    public void Look(Vector3 pos) {
        Vector3 off = pos - transform.position;
        float x = Vector2.SignedAngle(Vector2.up, new Vector2(off.x, off.z));
        float y = Vector2.SignedAngle(Vector2.up, new Vector2(new Vector2(off.x, off.z).magnitude, off.y));
        float[] f = { x, y, 0 };
        Rotate(f);
    }
}