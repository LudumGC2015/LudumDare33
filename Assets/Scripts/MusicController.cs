using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
    private AudioSource[] audios;
    private EuphoriaController euphoriaController;
    private const int NORMAL = 0;
    private const int EUPHORIA = 1; 

    public void Start() {
        audios = GetComponents<AudioSource>();
        euphoriaController = GameObject.FindGameObjectWithTag("Player").GetComponent<EuphoriaController>();
    }

    public void Update() {
        if (euphoriaController.IsEuphoric()) {
            if (audios[NORMAL].isPlaying) audios[NORMAL].Stop();
            if (!audios[EUPHORIA].isPlaying) audios[EUPHORIA].Play();
        } else {
            if (audios[EUPHORIA].isPlaying) audios[EUPHORIA].Stop();
            if (!audios[NORMAL].isPlaying) audios[NORMAL].Play();
        }
    }
}
