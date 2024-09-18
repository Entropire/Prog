using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TMP_Text textField;
    private int score;
    
    void Start()
    {
        textField = GetComponent<TMP_Text>();
        
        PickUp.OnPickUp += (points) =>
        {
            score += points;
        };
    }

    void Update()
    {
        textField.text = $"Score: {score}";
    }
}
