using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class PauseScript : MonoBehaviour
    {
        private bool _isPause;
        private GameObject _pauseMenu;


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
    }
}
