using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineBetweenUI : MonoBehaviour {
    public TimelineBetween timeline;
    public List<Blaster> selected;
	// Use this for initialization
	void Start () {
        selected = new List<Blaster>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(timeline.playing) timeline.Pause();
            else
            if(!timeline.playing) timeline.Play();
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            timeline.currentTime -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            timeline.currentTime += Time.deltaTime;
        }
    }

    private void OnGUI() {
        if(GUILayout.Button("Neues Event")) {
            timeline.addEventUpdate(selected.ToArray());
        }
        GUILayout.BeginHorizontal();
        for (int i = 0; i < timeline.events.Count; i++) {
            var item = timeline.events[i];
            GUILayout.BeginVertical();
            GUILayout.Label(System.Convert.ToString(item.whatToChange, 2));
            GUILayout.Label(item.time.ToString());
            if (GUILayout.Button(item.newColor.ToString())) {
                timeline.changeColor(i, item.newColor + 1);
            }
            if (GUILayout.Button("Remove")) {
                timeline.removeEventUpdate(item);
                continue;
            }

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("<1s")) {
                var e = item;
                e.time -= 1f;
                timeline.events[i] = e;
                timeline.updateEventUpdates();
                continue;
            }
            if (GUILayout.Button("1s>")) {
                var e = item;
                e.time += 1f;
                timeline.events[i] = e;
                timeline.updateEventUpdates();
                continue;
            }
            GUILayout.EndHorizontal();


            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();
        GUILayout.Button("", GUILayout.Width(timeline.currentTime*100));
    }
}
