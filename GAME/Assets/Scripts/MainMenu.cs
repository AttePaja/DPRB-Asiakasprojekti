using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {

        public Canvas mainMenuCanvas;
        public Canvas settingsCanvas;
        private int activeCanvas = 1;

        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }


        public void OpenSettings()
        {
            switch (activeCanvas)
            {
                case 1:
                    mainMenuCanvas.gameObject.SetActive(false);
                    settingsCanvas.gameObject.SetActive(true);
                    activeCanvas = 2;
                    break;

                case 2:
                    mainMenuCanvas.gameObject.SetActive(true);
                    settingsCanvas.gameObject.SetActive(false);
                    activeCanvas = 1;
                    break;
            }
        }


        public void CloseGame()
        {
            Application.Quit();
        }
    }
}