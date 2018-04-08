using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineUI : MonoBehaviour {
    public TimeLine line;
    GameObject[] list = new GameObject[100];
    public RectTransform cursor;
    public RectTransform frame;
    public GameObject eventObject;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 100; i++) { 
            GameObject clone = Instantiate(eventObject, frame);
            clone.SetActive(false);
            list[i] = (clone);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float w = 10f;
        for (int i = 0; i < 100; i++) {

            if (line.events.Count > i) {
                list[i].SetActive(true);
                RectTransform rect = list[i].GetComponent<RectTransform>();
                rect.position = new Vector2((line.events[i].time* frame.rect.width) / w, 0);
            }
            else list[i].SetActive(false);

        }
        cursor.position = new Vector2((line.currentTime* frame.rect.width)/w,0);
    }
}
