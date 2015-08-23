using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextController : MonoBehaviour {
    private ScoreController scoreController;
    private Text text;

    public void Start() {
        scoreController = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreController>();
        text = GetComponent<Text>();
    }

    public void Update() {
        text.text = "Score: " + scoreController.GetScore();

    }
}
