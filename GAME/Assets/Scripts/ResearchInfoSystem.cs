using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class ResearchInfoSystem : MonoBehaviour
    {
        public GameObject infoPanel;
        public TextMeshProUGUI infoTitle;
        public TextMeshProUGUI infoStat;
        public GameObject[] infoButtons = new GameObject[9];
        public bool[] isUnlocked = { true, false, false, false, false, false, false, false, false };
        private int lastIndex = 99;

        public string[] infoTitles =
        {
            "Big Box",
            "Autopresser upgrade",
            "Big Box upgrade",
            "RPT decrease",
            "RPT decrease++",
            "Crit Chance",
            "Increase Crit Chance",
            "Timeline shifter",
            "The Next Step"
        };

        public string[] infoStats =
        {
            "Factory: Enable the production of -Big Box-",
            "Autopressers are now twice as effective.",
            "Big Box is now twice as effective.",
            "Factory: Enable the production of -Research effiency upgrade-.",
            "Factory: Increase research effiency upgrade limit by 5.",
            "Pressing the button now has a 5% critical press chance. Critical press immediately earns 100 clicks. Factory: Enable to production of -Crit presser upgrade-.",
            "Increase Crit Chance by 5%.",
            "Factory: Enables the production of -Timeline shifter-",
            "Factory: Enables the production of -The Next Step-"
        };

        public void ShowRinfoPanel(int _buyIndex)
        {
            if (isUnlocked[_buyIndex] == true)
            {
                if (lastIndex == 99)
                {
                    lastIndex = _buyIndex;
                } else infoButtons[lastIndex].SetActive(false);
                
                infoPanel.SetActive(true);
                infoTitle.text = infoTitles[_buyIndex];
                infoStat.text = infoStats[_buyIndex];
                infoButtons[_buyIndex].SetActive(true);
                lastIndex = _buyIndex;
            }
        }

        public void CloseInfoPanel()
        {
            infoPanel.SetActive(false);
        }
    }
}