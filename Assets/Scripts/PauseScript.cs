using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class PauseScript : MonoBehaviour
    {
        private bool _isPause;
        public GameObject PauseMenu;

        void Start()
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                PauseMenu.SetActive(false);
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
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPause = true;
        }

        public void Resume()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _isPause = false;

        }
    }
}
