using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class PauseScript : MonoBehaviour
    {
        private bool _isPause;
        private GameObject _pauseMenu;
        public GameObject close_button;
        public GameObject tutorialImage;

        public GameObject playb;
        public GameObject tutorb;


        void Start()
        {


            _pauseMenu = GameObject.Find("Canvas");
            if(SceneManager.GetActiveScene().name != "Menu")
            {
                try
                {
                    _pauseMenu.SetActive(false);
                }
                catch (NullReferenceException _)
                { }
            }
            else
            {

            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(_isPause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Replay()
        {
            GameObject.Find("InGameUI/timer1").GetComponent<UITimer>().TimeLeft = 120;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Kitchen");
        }

        public void Pause()
        {
            try
            {
                _pauseMenu.SetActive(true);
            }
            catch (NullReferenceException _)
            { }
            Time.timeScale = 0f;
            _isPause = true;
        }

        public void Resume()
        {
            try
            {
                _pauseMenu.SetActive(false);
            }
            catch (NullReferenceException _)
            { }
            Time.timeScale = 1f;
            _isPause = false;
        }

        public void Tutorial()
        {
            close_button.GetComponent<Image>().color = new Color(255,255,255,1);
            tutorialImage.GetComponent<Image>().color = new Color(255,255,255,1);

            playb.GetComponent<Image>().color = new Color(255,255,255,0);
            tutorb.GetComponent<Image>().color = new Color(255,255,255,0);
        }

        public void closeTutorial()
        {
            close_button.GetComponent<Image>().color = new Color(255,255,255,0);
            tutorialImage.GetComponent<Image>().color = new Color(255,255,255,0);

            playb.GetComponent<Image>().color = new Color(255,255,255,1);
            tutorb.GetComponent<Image>().color = new Color(255,255,255,1);

        }

    }
}
