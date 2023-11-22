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
        public int factoryMediumCost = 20;
        public int factoryLargeCost = 200;
        public int factoryDoubleUpCost = 1000;
        public int factoryCritPayoutCost = 750;
        public int factoryNextStepCost = 1000000;
        public int factoryResearchStationCost = 100;
        public int factoryRPTdecreaseCost = 1000;

        public int factorySmallRate = 1;
        public int factoryMediumRate = 2;
        public int factoryLargeRate = 10;
        public int critPayout = 0;

        public int factorySmallCount = 0;
        public int factoryMediumCount = 0;
        public int factoryLargeCount = 0;
        public int researchStationCount = 0;
        public int critUpCount = 0;
        public int doubleUpCount = 0;
        public int RPTdecreaseCount = 0;
        public int nextStepCount = 0;

        public bool hasSmallFactory = false;
        public bool hasMediumFactory = false;
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

        

        public ClickSystem _clickSystem;
        public ResearchSystem _researchSystem;
        // public BuildMenu buildMenu;
        // public GameObject buildUI;
        

        public void BuyFactorySmall()
        {
            if (_clickSystem.playerMoney >= factorySmallCost)
            {
                _clickSystem.playerMoney -= factorySmallCost;
                factorySmallCount++;
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
                UpdateFactoryDisplays();
            }
        }

        public void BuyCritPayout()
        {
            if (_clickSystem.playerMoney >= factoryCritPayoutCost && _researchSystem.researchedCritIncrease == true)
            {
                _clickSystem.playerMoney -= factoryCritPayoutCost;
                critPayout += 100;
                UpdateFactoryDisplays();
            }
        }

        public void BuyNextStep()
        {
            if (_clickSystem.playerMoney >= factoryNextStepCost && _researchSystem.researchedNextStep == true)
            {
                _clickSystem.playerMoney -= factoryNextStepCost;
                hasNextStep = true;
                UpdateFactoryDisplays();
            }
        }


        public void BuyRPTdecrease()
        {
            if (_clickSystem.playerMoney >= factoryRPTdecreaseCost && _clickSystem.researchPointTarget > 0 && _researchSystem.researchedRPpoint && maxRPTownedAmount <= ownedRPT)
            {
                _clickSystem.playerMoney -= factoryRPTdecreaseCost;
                _clickSystem.researchPointTarget--;
                ownedRPT++;
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
            doubleUpText.text = "Owned: " + doubleUpCount;
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
