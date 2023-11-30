using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {

        public Canvas mainMenuCanvas;
        public Canvas settingsCanvas;
        private int activeCanvas = 1;
        public AudioMixer audioMixer;
        public Dropdown resolutionDropDown;
        Resolution[] resolutions;
        
        void Start ()
        {
            resolutions = Screen.resolutions;
            resolutionDropDown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropDown.AddOptions(options);
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

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


        public void AdjustVolume(float _volume)
        {
            audioMixer.SetFloat("volume", _volume);
        }

        public void SetFullscreen(bool _isFullscreen)
        {
            Screen.fullScreen = _isFullscreen;
        }


        public void CloseGame()
        {
            Application.Quit();
        }
    }
}