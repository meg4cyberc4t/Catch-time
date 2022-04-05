using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts;


public class UITimer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private TextMeshProUGUI _timerText;


    public float TimeLeft = 120f;
    private bool _timerOn = false;
    
    public Transform camera;

    private bool _finalStart = false;

    


    //GameObject.Find("InGameUI/counter/fd").GetComponent<TextMeshProUGUI>();

    WashingMachineController controller; 
 
    private void Start()
    {
        controller = GameObject.Find("WashingMachine").gameObject.GetComponent<WashingMachineController>();
        _timerText = gameObject.GetComponent<TextMeshProUGUI>();
        TimeLeft = _time;
        _timerOn = true;
    }
 
    private void Update()
    {


        if (_timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimeText();
            } 
            else
            {
                TimeLeft = _time;
                _timerOn = false;
            }
        }
        else
        {
            if (_finalStart) return;
            _finalStart = true;
            camera.position = new Vector3(-77, -13, -20);
            Time.timeScale = 0;
            Ending.GetEnding(controller.AllClothCounter, StartCoroutine);
        }
        
    }

    private void UpdateTimeText()
    {
        if (TimeLeft < 0)
            TimeLeft = 0;
 
        float minutes = Mathf.FloorToInt(TimeLeft / 60);
        float seconds = Mathf.FloorToInt(TimeLeft % 60);
        _timerText.SetText($"{minutes:00} : {seconds:00}");
    }
}
