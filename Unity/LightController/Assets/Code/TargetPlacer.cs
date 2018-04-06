using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlacer : MonoBehaviour {

    public static TargetPlacer instance;

    // Use this for initialization
    void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            transform.position = hit.point;
	}
}
