using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts;


public class UITimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;


    private float _timeLeft = 120f;
    private bool _timerOn = false;
    
    public Transform camera;

    private bool _finalStart = false;

    


    //GameObject.Find("InGameUI/counter/fd").GetComponent<TextMeshProUGUI>();

    WashingMachineController controller; 
 
    private void Start()
    {
        controller = GameObject.Find("WashingMachine").gameObject.GetComponent<WashingMachineController>();
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
            } 
            else
            {
                _timeLeft = time;
                _timerOn = false;
            }
        }
        else
        {
            if (_finalStart) return;
            _finalStart = true;
            camera.position = new Vector3(-77, -13, -20);
            if(controller.AllClothCounter < 4)
            {
                StartCoroutine(BadEnding());
            } else if (controller.AllClothCounter < 8)
            {
                StartCoroutine(NeutralEnding());
            }
            else
            {
                StartCoroutine(GoodEnding());
            }
        }
        
    }
    
    IEnumerator BadEnding()
    {
        GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_bad/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
        GameObject.Find("cutscene_bad/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
    }
    
    IEnumerator NeutralEnding()
    {
        GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_neutral/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
        GameObject.Find("cutscene_neutral/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
    }
    
    IEnumerator GoodEnding()
    {
        GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(2);
        GameObject.Find("cutscene_good/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
        GameObject.Find("cutscene_good/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield return new WaitForSeconds(10);
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.SetText($"{minutes:00} : {seconds:00}");
    }



}
