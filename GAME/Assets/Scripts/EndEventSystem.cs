using System.Collections;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class EndEventSystem : MonoBehaviour
    {

        public GameObject redCanvas;
        public GameObject susButton;
        public GameObject blackCanvas;
        public GameObject screenText;
        public GameObject screenText2;
        public GameObject factoryText;
        public GameObject factoryText2;
        public GameObject factoryText3;
        public GameObject reseText;
        public GameObject reseText2;
        public GameObject MileText;

        public GameObject rtext;
        public GameObject rtext1;
        public GameObject rtext2;
        public GameObject rtext3;

        public GameObject exitButton;

        public TextMeshProUGUI[] endTexts;
        public ClickSystem _clickSystem;

        public GameObject endButton;

        private int textNumber = 0;
        private bool readyForEndTexts = false;

        public void StartEvent()
        {
            redCanvas.SetActive(true);
            susButton.SetActive(true);
            screenText.SetActive(false);
            screenText2.SetActive(false);
            factoryText.SetActive(false);
            factoryText2.SetActive(false);
            factoryText3.SetActive(false);
            reseText.SetActive(false);
            reseText2.SetActive(false);
            MileText.SetActive(false);
            exitButton.SetActive(false);

            rtext.SetActive(true);
            rtext1.SetActive(true);
            rtext2.SetActive(true);
            rtext3.SetActive(true);
        }

        public void Boom()
        {
            blackCanvas.SetActive(true);
            readyForEndTexts = true;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && readyForEndTexts == true) { EndTextShow(); textNumber++; };
        }

        public void EndTextShow()
        {
            switch (textNumber)
            {
                case 0:
                    endTexts[0].text = "Congratulations, you've won.";
                    break;
                case 1:
                    endTexts[1].text = "You have pressed a red button many, many times.";
                    break;
                case 2:
                    endTexts[2].text = _clickSystem.clickCounter + " times, to be exact.";
                    break;
                case 3:
                    endTexts[3].text = "That's roughly " + _clickSystem.clickCounter * 1.4 + " calories burned! Good Job!";
                    break;
                case 4:
                    endTexts[4].text = "...";
                    break;
                case 5:
                    endTexts[5].text = "What?";
                    break;
                case 6:
                    endTexts[6].text = "That's all. Go home.";
                    break;
                case 7:
                    endTexts[7].text = "What was the point of all this?";
                    break;
                case 8:
                    endTexts[8].text = "dunno.";
                    break;
                case 9:
                    endTexts[9].text = "Now...";
                    break;
                case 10:
                    endButton.SetActive(true);
                    break;
                case 11:
                    textNumber = 0;
                    break;
            }
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}