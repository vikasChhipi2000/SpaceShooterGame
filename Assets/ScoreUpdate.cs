using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    TMP_Text score;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = gameSession.getScore().ToString();
    }
}
