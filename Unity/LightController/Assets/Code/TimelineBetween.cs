using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineBetween : MonoBehaviour {

    public List<EventUpdate> events;
    public float currentTime;
    public bool playing = false;

	// Use this for initialization
	void Start () {
        events = new List<EventUpdate>();
    }
	
	// Update is called once per frame
	void Update () {
        if(playing)
            currentTime += Time.deltaTime;

        List<Blaster> changed = new List<Blaster>();
        for (int i = 0; i < events.Count; i++) {

        }
    }

    public void addEventUpdate(Blaster[]  targets) {
        var e = new EventUpdate(EventUpdate.eventChanges.color);
        e.newColor = 1;
        e.time = currentTime;
        events.Add(e);
        updateEventUpdates();
    }
    public void removeEventUpdate(EventUpdate ev) {
        if (events.Contains(ev))
            events.Remove(ev);
        else
            Debug.LogWarning("Some Thing went Wrong");
        
    }

    public void swapEventUpdates(int indexA,int indexB) {
        try {
            EventUpdate tmp = events[indexA];
            events[indexA] = events[indexB];
            events[indexB] = tmp;
        }
        catch {
            Debug.Log("no naibor");
        }
    }

    public void Play() {
        playing = true;
    }
    public void Pause() {
        playing = false;
    }

    public void changeColor(int index,int newColor) {
        var i = events[index];
        i.newColor = newColor;
        events[index] = i;
    }

    public void updateEventUpdates() {
        events.Sort(delegate (EventUpdate a, EventUpdate b) {
            return a.time.CompareTo(b.time);
        });
    }
}
