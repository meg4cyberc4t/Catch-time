using UnityEngine;

namespace Assets.Scripts
{
    public class Pause : MonoBehaviour
    {
        private bool _isPause;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            Time.timeScale = _isPause ? 1 : 0f;
            Cursor.visible = _isPause;
            AudioListener.pause = _isPause;
            _isPause = !_isPause;
        }
    }
}
