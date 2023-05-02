using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _exitWindow;

        public void Exit() =>
            Application.Quit();

        public void ShowWindow() =>
            _exitWindow.SetActive(true);
    }
}
