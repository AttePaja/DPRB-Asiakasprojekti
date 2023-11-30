using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenuSystem : MonoBehaviour
    {

        public GameObject pauseMenu;
        public GameObject HTPMenu;

        public void PauseTheGame()
        {
            pauseMenu.SetActive(true);
        }


        public void UnPauseGame()
        {
            pauseMenu.SetActive(false);
        }

        public void ShowHowToPlay()
        {
            HTPMenu.SetActive(true);
        }

        public void CloseHowToPlay()
        {
            HTPMenu.SetActive(false);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}