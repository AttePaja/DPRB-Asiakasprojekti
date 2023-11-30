using System.Collections;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class FactoryInfoSystem : MonoBehaviour
    {

        // public Image smallIMAGE;
        // public Image researchIMAGE;
        // public Image largeIMAGE;
        // public Image critIMAGE;
        // public Image doubleIMAGE;
        // public Image rptIMAGE;
        // public Image nextStepIMAGE;
        // 
        // public TextMeshProUGUI smallTITLE;
        // public TextMeshProUGUI researchTITLE;
        // public TextMeshProUGUI largeTITLE;
        // public TextMeshProUGUI critTITLE;
        // public TextMeshProUGUI rptTITLE;
        // public TextMeshProUGUI nextStepTITLE;
        // 
        // public TextMeshProUGUI smallINFO;
        // public TextMeshProUGUI researchINFO;
        // public TextMeshProUGUI largeINFO;
        // public TextMeshProUGUI critINFO;
        // public TextMeshProUGUI rptINFO;
        // public TextMeshProUGUI nextStepINFO;
        // 

        // 
        // public Button buySmallButton;
        // public Button buyResearchButton;
        // public Button buyLargeButton;
        // public Button buyCritButton;
        // public Button buyRptButton;
        // public Button buyNextButton;

        public GameObject infoImage;
        public TextMeshProUGUI infoTitle;
        public TextMeshProUGUI infoStat;
        public TextMeshProUGUI infoFluff;

        private int lastIndex = 99;

        public GameObject[] infoImages = new GameObject[7];

        public GameObject[] infoButtons = new GameObject[7];

        public bool[] isUnlocked = { true, true, false, false, false, false, false};

        public string[] infoTitles =
        {
            "Autopresser Mk.1",
            "ResearchCube Mk.1",
            "BigBox",
            "Crit presser Upgrade",
            "Research effiency Upgrade",
            "Timeline shifter",
            "The Next Step"
        };

        public string[] infoStats =
        {
            "Automatically presses the BUTTON once per second.",
            "Automatically produces one research point every five seconds.",
            "Automatically presses the BUTTON 10 times, and produces 10 research points, every ten seconds.",
            "Increases the payout of a critical press by 100. Stacks.",
            "Reduces the BUTTON presses required to produce a research point by 1.",
            "Doubles the amount of clicks gained from pressing the BUTTON",
            "Ascend further. WIN THE GAME."
        };

        public string[] infoFluffs =
        {
            "A simple machine featuring a hinge, string, and a stick. The back and forth motion effectively creates a automatic BUTTON pressing machine.",
            "ResearchCube. A cube, that does research? You don't really know what it is, but it keeps spewing out mathematical calculations at a steady rate. Seems usefull.",
            "A big box with undisclosed amounts of researchcubes and autopressers inside of it. Does just sticking things inside a big box work? Apparently so.",
            "An enhanced, more unstable spring for the crit presser, allowing it to move back and forth at ridiculous rates.",
            "They say you are what you eat, so eating some of the research papers spewn out by the ResearchCubes should thus make you smarter, right?",
            "A mysterious machine that allows you to press the button across multiple timelines, literally multiplying your button pressing ambitions.",
            "A small box, not unlike the ResearchCubes, that hums with unknown power. You dont know what it is, but the BUTTON told you to make it. One word echoes in your head: ASCEND."
        };

        public void ShowBuyInfoPanel(int _buyindex)
        {
            if (isUnlocked[_buyindex] == true)
            {
                if (lastIndex == 99) 
                { 
                    lastIndex = _buyindex; 
                }
                else infoButtons[lastIndex].SetActive(false);

                infoImage = infoImages[_buyindex];
                infoTitle.text = infoTitles[_buyindex];
                infoStat.text = infoStats[_buyindex];
                infoFluff.text = infoFluffs[_buyindex];
                infoButtons[_buyindex].SetActive(true);
                lastIndex = _buyindex;
            }
        }
    }
}