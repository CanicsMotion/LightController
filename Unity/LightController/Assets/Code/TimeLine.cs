using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine :MonoBehaviour {

    public List<Event> events;
    public List<Coroutine> startedEvents;
    public float currentTime = 0;
    public enum playState {
        stop,play,pause,reverse
    }
    public playState currentState;

    private void Start() {
        startedEvents = new List<Coroutine>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentState == playState.pause || currentState == playState.stop) Play();
            else if (currentState == playState.play) Pause();
        }
        if(currentState == playState.play) {
            currentTime += Time.deltaTime;
        }
    }

    public void Play() {
        currentState = playState.play;
        foreach (var item in events) {
            if(item.time >= currentTime) {
                var c = StartCoroutine(playNoteAfter(item.time - currentTime,item));
                startedEvents.Add(c);
            }
        }
    }
    public void Pause() {
        currentState = playState.pause;
        foreach (var item in startedEvents) {
            StopCoroutine(item);
        }
        startedEvents.Clear();
    }

    IEnumerator playNoteAfter(float t,Event eve) {
        yield return new WaitForSeconds(t);
        eve.Execute();
    }
}
