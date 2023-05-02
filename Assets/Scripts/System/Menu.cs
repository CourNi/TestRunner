using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _creditsWindow;

        public void ShowCredits() =>
            _creditsWindow.SetActive(true);

        public void StartGame() =>
            SceneManager.LoadScene(1);

        public void Exit() =>
            Application.Quit();
    }
}
