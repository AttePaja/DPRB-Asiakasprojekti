using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using JetBrains.Annotations;

namespace Assets.Scripts
{

    public class BuildSystem : MonoBehaviour
    {
        public int factorySmallCost = 50;
        // public int factoryMediumCost = 20;
        public int factoryLargeCost = 200;
        public int factoryDoubleUpCost = 1000;
        public int factoryCritPayoutCost = 750;
        public int factoryNextStepCost = 1000000;
        public int factoryResearchStationCost = 100;
        public int factoryRPTdecreaseCost = 1000;

        public int factorySmallRate = 1;
        // public int factoryMediumRate = 2;
        public int factoryLargeRate = 10;
        public int critPayout = 0;

        public int factorySmallCount = 0;
        // public int factoryMediumCount = 0;
        public int factoryLargeCount = 0;
        public int researchStationCount = 0;
        public int critUpCount = 0;
        public int doubleUpCount = 0;
        public int RPTdecreaseCount = 0;
        public int nextStepCount = 0;

        public bool hasSmallFactory = false;
        // public bool hasMediumFactory = false;
        public bool hasLargeFactory = false;
        public bool hasResearchStation = false;
        public bool hasDoubleUp = false;
        public bool hasNextStep = false;

        public int ownedRPT = 0;
        public int maxRPTownedAmount = 5;

        public TextMeshProUGUI smallText;
        public TextMeshProUGUI researchStationText;
        public TextMeshProUGUI largeText;
        public TextMeshProUGUI critUpText;
        public TextMeshProUGUI doubleUpText;
        public TextMeshProUGUI RPTdecreaseText;
        public TextMeshProUGUI nextStepText;

        public TextMeshProUGUI smallCostText;
        public TextMeshProUGUI researchStationCostText;
        public TextMeshProUGUI largeCostText;
        public TextMeshProUGUI critUpCostText;
        public TextMeshProUGUI doubleUpCostText;
        public TextMeshProUGUI RPTdecreaseCostText;
        public TextMeshProUGUI NextStepCostText;

        public TextMeshProUGUI clickAmount;

        public GameObject largeLock;
        public GameObject critLock;
        public GameObject rptLock;
        public GameObject doubleLock;
        public GameObject nextStepLock;

        public ClickSystem _clickSystem;
        public ResearchSystem _researchSystem;
        public FactoryInfoSystem _factoryInfoSystem;
        public EndEventSystem _endEventSystem;
        // public BuildMenu buildMenu;
        // public GameObject buildUI;

        public void Awake()
        {
            smallCostText.text = "" + factorySmallCost;
            researchStationCostText.text = "" + factoryResearchStationCost;
            largeCostText.text = "" + factoryLargeCost;
            critUpCostText.text = "" + factoryCritPayoutCost;
            doubleUpCostText.text = "" + factoryDoubleUpCost;
            RPTdecreaseCostText.text = "" + factoryRPTdecreaseCost;
            NextStepCostText.text = "" + factoryNextStepCost;
        }

        public void Update()
        {
            CheckClicksBuild();
        }

        public void CheckClicksBuild()
        {
            clickAmount.text = "Clicks " + _clickSystem.playerMoney;
        }

        public void BuyFactorySmall()
        {
            if (_clickSystem.playerMoney >= factorySmallCost)
            {
                _clickSystem.playerMoney -= factorySmallCost;
                factorySmallCount++;
                
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                hasSmallFactory = true;
                UpdateFactoryDisplays();
            }
        }


        public void BuyResearchStation()
        {
            if (_clickSystem.playerMoney >= factoryResearchStationCost)
            {
                _clickSystem.playerMoney -= factoryResearchStationCost;
                researchStationCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                hasResearchStation = true;
                UpdateFactoryDisplays();
            }
        }

        // public void BuyFactoryMedium()
        // {
        //     if (_clickSystem.playerMoney >= factoryMediumCost)
        //     {
        //         _clickSystem.playerMoney -= factoryMediumCost;
        //         factoryMediumCount++;
        //         hasMediumFactory = true;
        //         UpdateFactoryDisplays();
        //     }
        // }

        public void BuyFactoryLarge()
        {
            if (_clickSystem.playerMoney >= factoryLargeCost && _researchSystem.researchedLargeFactory == true)
            {
                _clickSystem.playerMoney -= factoryLargeCost;
                factoryLargeCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                hasLargeFactory = true;
                UpdateFactoryDisplays();
            }
        }

        public void BuyDoubleUp()
        {
            if (_clickSystem.playerMoney >= factoryDoubleUpCost && _researchSystem.researchedDoubleUp == true)
            {
                _clickSystem.playerMoney -= factoryDoubleUpCost;
                _clickSystem.clickMultiplier = _clickSystem.clickMultiplier * 2;
                hasDoubleUp = true;
                doubleUpCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                UpdateFactoryDisplays();
            }
        }

        public void BuyCritPayout()
        {
            if (_clickSystem.playerMoney >= factoryCritPayoutCost && _researchSystem.researchedCritChance == true)
            {
                _clickSystem.playerMoney -= factoryCritPayoutCost;
                critPayout += 100;
                critUpCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                UpdateFactoryDisplays();
            }
        }

        public void BuyNextStep()
        {
            if (_clickSystem.playerMoney >= factoryNextStepCost && _researchSystem.researchedNextStep == true)
            {
                _clickSystem.playerMoney -= factoryNextStepCost;
                hasNextStep = true;
                nextStepCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                UpdateFactoryDisplays();
                _endEventSystem.StartEvent();
            }
        }


        public void BuyRPTdecrease()
        {
            if (_clickSystem.playerMoney >= factoryRPTdecreaseCost && _clickSystem.researchPointTarget > 0 && _researchSystem.researchedRPpoint == true && maxRPTownedAmount >= ownedRPT)
            {
                _clickSystem.playerMoney -= factoryRPTdecreaseCost;
                _clickSystem.researchPointTarget--;
                RPTdecreaseCount++;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(3);
                UpdateFactoryDisplays();
            }
        }

        private void UpdateFactoryDisplays()
        {
            smallText.text = "Owned: " + factorySmallCount;
            researchStationText.text = "Owned: " + researchStationCount;
            //mediumText.text = "Owned: " + factoryMediumCount;
            largeText.text = "Owned: " + factoryLargeCount;
            critUpText.text = "Owned: " + critUpCount;
            doubleUpText.text = "Owned: " + doubleUpCount + "/5";
            RPTdecreaseText.text = "Owned: " + RPTdecreaseCount + "/10";
            nextStepText.text = "Owned: " + nextStepCount + "/1";
        }

        // public void OpenBuildMenu()
        // {
        //     Button _pressedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //     int _pressedButtonInteger = buildMenu.GetBuildAreaGridIndex(_pressedButton);
        //     Debug.Log("Button index is: " + _pressedButtonInteger);
        //     buildUI.gameObject.SetActive(true);
        // }
    }

    
}
