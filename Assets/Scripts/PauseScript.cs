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
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                _pauseMenu.SetActive(false);
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
            SceneManager.LoadScene(1);
        }

        public void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPause = true;
        }

        public void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _isPause = false;
        }
    }
}
