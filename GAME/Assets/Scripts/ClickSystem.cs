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

        [SerializeField] public BuildSystem _buildSystem;
        [SerializeField] public ResearchSystem _researchSystem;
        [SerializeField] public MilestoneSystem _milestoneSystem;

        private void Awake()
        {
            UpdateDisplay();
        }
    
        /// <summary>
        /// Increases the player's money by a set amount.
        /// </summary>
        public void IncreaseMoney()
        {
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

            
            
            // if (_buildSystem.hasMediumFactory)
            // {
            //     playerMoney += _buildSystem.factoryMediumCount * _buildSystem.factoryMediumRate;
            //     Debug.Log("Medium factories make stuff, the player has: " + _buildSystem.factoryMediumCount + " factories!");
            // }
            
            if (_buildSystem.hasLargeFactory)
            {
                playerMoney += _buildSystem.factoryLargeCount * _buildSystem.factoryLargeRate;
                researchPoints += _buildSystem.factoryLargeCount * _buildSystem.factoryLargeRate;
                Debug.Log("Large factories make stuff, the player has: " + _buildSystem.factoryLargeCount + " factories!");
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
                Debug.Log("Small factories make stuff, the player has: " + _buildSystem.factorySmallCount + " factories!");
            }

            if (_buildSystem.hasResearchStation)
            {
                researchPoints += _buildSystem.researchStationCount;
                Debug.Log("Research stations make stuff, the player has: " + _buildSystem.factorySmallCount + " stations!");
            }

            _milestoneSystem.AddClick(playerMoney - _pmoney);
            UpdateDisplay();
        }

    
        /// <summary>
        /// Updates the displayText component with the player's current money.
        /// </summary>
        private void UpdateDisplay()
        {
            displayText.text = "Money: " + playerMoney.ToString();
            researchPointText.text = "Research points: " + researchPoints.ToString();
            milestoneText.text = "Amount: " + _milestoneSystem.clickAmount;
            smallFactoryAmountText.text = "Small: " + _buildSystem.factorySmallCount;
            // mediumFactoryAmountText.text = "Medium: " + _buildSystem.factoryMediumCount;
            largeFactoryAmountText.text = "Large: " + _buildSystem.factoryLargeCount;
            _milestoneSystem.milestoneText.text = "Current Objective:" + Environment.NewLine + _milestoneSystem.clickAmount + "/" + _milestoneSystem.milestones[_milestoneSystem.currentMilestone];
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
                largeIncreaseText.text = "+";
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(AddFactoryMoney), 10f, 10f);
            InvokeRepeating(nameof(AddSmallFactoryPoints), 1f, 1f);
        }
    
        private void OnDisable()
        {
            CancelInvoke(nameof(AddFactoryMoney));
            CancelInvoke(nameof(AddSmallFactoryPoints));
        }
    
    
        // UPDATE TO A BETTER SOLUTION
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

        // UPDATE TO A BETTER SOLUTION
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
