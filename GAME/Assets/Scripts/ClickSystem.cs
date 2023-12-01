using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Assets.Scripts
{

    public class ClickSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI displayText;
        [SerializeField] private TextMeshProUGUI researchPointText;
        [SerializeField] private TextMeshProUGUI smallMultiplierText;
        [SerializeField] private TextMeshProUGUI doubleUpText;
        [SerializeField] private TextMeshProUGUI largeIncreaseText;
        [SerializeField] private TextMeshProUGUI milestoneText;
        [SerializeField] private TextMeshProUGUI smallFactoryAmountText;
        [SerializeField] private TextMeshProUGUI mediumFactoryAmountText;
        [SerializeField] private TextMeshProUGUI largeFactoryAmountText;
        [SerializeField] private TextMeshProUGUI critChanceText;
        [SerializeField] private TextMeshProUGUI researchStationsText;
        [SerializeField] private TextMeshProUGUI researchPointTargetText;
        [SerializeField] private Canvas MainCanvas;
        [SerializeField] private Canvas BuildCanvas;
        [SerializeField] private Canvas ResearchCanvas;
        [SerializeField] private Canvas MilestoneCanvas;

        public int playerMoney = 0;
        public int researchPoints = 0;
        public int clickMultiplier = 1;
        public int critChance = 5;
        public int researchPointTarget = 10;
        public int currentRPT = 0;
        private int activeCanvas = 1;
        System.Random rand = new System.Random();

        public int clickCounter = 0;

        [SerializeField] public BuildSystem _buildSystem;
        [SerializeField] public ResearchSystem _researchSystem;
        [SerializeField] public MilestoneSystem _milestoneSystem;

        public GameObject theButton;

        private void Awake()
        {
            UpdateDisplay();
        }
    
        
        public void IncreaseMoney()
        {
            theButton.GetComponent<AudioSource>().Play();
            clickCounter++;
            playerMoney += 1 * clickMultiplier;
            int i = rand.Next(0, 100); 
            if (i <= critChance) { playerMoney += _buildSystem.critPayout; }
            currentRPT++;
            if (currentRPT >= researchPointTarget) { researchPoints++; currentRPT = 0; }
            _milestoneSystem.AddClick(1 * clickMultiplier);
            _milestoneSystem.CheckMilestones(_milestoneSystem.currentMilestone);
            UpdateDisplay();
        }

       

        public void AddFactoryMoney()
        {
            int _pmoney = playerMoney;

            
            
           
            
            if (_buildSystem.hasLargeFactory)
            {
                playerMoney += _buildSystem.factoryLargeCount * _buildSystem.factoryLargeRate;
                researchPoints += _buildSystem.factoryLargeCount * _buildSystem.factoryLargeRate;
                // Debug.Log("Large factories make stuff, the player has: " + _buildSystem.factoryLargeCount + " factories!");
            }

            _milestoneSystem.AddClick(playerMoney - _pmoney);
            UpdateDisplay();
        }

        public void AddSmallFactoryPoints() 
        {
            int _pmoney = playerMoney;

            if (_buildSystem.hasSmallFactory)
            {
                playerMoney += _buildSystem.factorySmallCount * _buildSystem.factorySmallRate;
                // Debug.Log("Small factories make stuff, the player has: " + _buildSystem.factorySmallCount + " factories!");
            }

            _milestoneSystem.AddClick(playerMoney - _pmoney);
            UpdateDisplay();
        }

        public void AddResearchStationPoints()
        {
            if (_buildSystem.hasResearchStation)
            {
                researchPoints += _buildSystem.researchStationCount;
                // Debug.Log("Research stations make stuff, the player has: " + _buildSystem.factorySmallCount + " stations!");
            }
        }
    
        
        private void UpdateDisplay()
        {
            displayText.text = "Clicks: " + playerMoney.ToString();
            researchPointText.text = "Research points: " + researchPoints.ToString();
            researchStationsText.text = "Research: " + _buildSystem.researchStationCount.ToString();
            researchPointTargetText.text = "RPT: " + researchPointTarget.ToString();
            milestoneText.text = "Total clicks: " + _milestoneSystem.clickAmount;
            smallFactoryAmountText.text = "AutoPress: " + _buildSystem.factorySmallCount;
            // mediumFactoryAmountText.text = "Medium: " + _buildSystem.factoryMediumCount;
            largeFactoryAmountText.text = "BigBox: " + _buildSystem.factoryLargeCount;
            _milestoneSystem.milestoneText.text = "Current Objective:" + Environment.NewLine + _milestoneSystem.clickAmount + "/" + _milestoneSystem.milestones[_milestoneSystem.currentMilestone];
            _milestoneSystem.milestoneCounterText.text = _milestoneSystem.currentMilestone + "/10";
        }

        public void UpdateEffectDisplay()
        {
            if (_researchSystem.researchedSmallMultiplier == true)
            {
                smallMultiplierText.text = "2X";
            }

            if (_buildSystem.hasDoubleUp == true)
            {
                doubleUpText.text = clickMultiplier + "X";
            }

            if (_researchSystem.researchedLargeFactoryBoost == true)
            {
                largeIncreaseText.text = "2X";
            }

            if (_researchSystem.researchedCritChance == true && _researchSystem.researchedCritIncrease == false)
            {
                critChanceText.text = "Crit Chance: 5%";
            }

            if (_researchSystem.researchedCritIncrease == true)
            {
                critChanceText.text = "Crit Chance: 10%";
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(AddFactoryMoney), 10f, 10f);
            InvokeRepeating(nameof(AddSmallFactoryPoints), 1f, 1f);
            InvokeRepeating(nameof(AddResearchStationPoints), 5f, 5f);
        }
    
        private void OnDisable()
        {
            CancelInvoke(nameof(AddFactoryMoney));
            CancelInvoke(nameof(AddSmallFactoryPoints));
            CancelInvoke(nameof(AddResearchStationPoints));
        }
    
    
        
        public void ChangeCanvasFactory()
        {
            switch (activeCanvas)
            {
                case 1:
                    MainCanvas.gameObject.SetActive(false);
                    BuildCanvas.gameObject.SetActive(true);
                    activeCanvas = 2;
                    UpdateDisplay();
                    break;
                case 2:
                    MainCanvas.gameObject.SetActive(true);
                    BuildCanvas.gameObject.SetActive(false);
                    activeCanvas = 1;
                    UpdateDisplay();
                    break;
            }
        }

        
        public void ChangeCanvasResearch()
        {
            switch (activeCanvas)
            {
                case 1:
                    MainCanvas.gameObject.SetActive(false);
                    ResearchCanvas.gameObject.SetActive(true);
                    activeCanvas = 2;
                    UpdateDisplay();
                    break;
                case 2:
                    MainCanvas.gameObject.SetActive(true);
                    ResearchCanvas.gameObject.SetActive(false);
                    activeCanvas = 1;
                    UpdateDisplay();
                    break;
            }
        }


        public void ChangeCanvasMilestone()
        {
            switch (activeCanvas)
            {
                case 1:
                    MainCanvas.gameObject.SetActive(false);
                    MilestoneCanvas.gameObject.SetActive(true);
                    activeCanvas = 2;
                    UpdateDisplay();
                    break;
                case 2:
                    MainCanvas.gameObject.SetActive(true);
                    MilestoneCanvas.gameObject.SetActive(false);
                    activeCanvas = 1;
                    UpdateDisplay();
                    break;
            }
        }

    }

}
