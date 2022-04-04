using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;

    private float _timeLeft = 120f;
    private bool _timerOn = false;
 
    private void Start()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
        _timeLeft = time;
        _timerOn = true;
    }
 
    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } else
            {
                _timeLeft = time;
                _timerOn = false;
            }
        }
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.SetText(string.Format("{0:00} : {1:00}", minutes, seconds));
    }
}
