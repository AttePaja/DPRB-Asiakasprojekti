using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{

    public class ClickSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI displayText;
        [SerializeField] private TextMeshProUGUI smallMultiplierText;
        [SerializeField] private TextMeshProUGUI multiclickText;
        [SerializeField] private TextMeshProUGUI largeIncreaseText;
        [SerializeField] private Canvas MainCanvas;
        [SerializeField] private Canvas BuildCanvas;
        [SerializeField] private Canvas ResearchCanvas;

        public int playerMoney = 0; // Money the player has
        private int activeCanvas = 1;

        [SerializeField] public BuildSystem _buildSystem;
        [SerializeField] public ResearchSystem _researchSystem;

        private void Awake()
        {
            UpdateDisplay();
        }
    
        /// <summary>
        /// Increases the player's money by a set amount.
        /// </summary>
        public void IncreaseMoney()
        {
            playerMoney += 1 * _researchSystem.multiclickEffect;
            UpdateDisplay();
        }


        public void AddFactoryMoney()
        {
            if (_buildSystem.hasSmallFactory)
            {
                playerMoney += _buildSystem.factorySmallCount * _buildSystem.factorySmallRate;
                Debug.Log("Small factories make stuff, the player has: " + _buildSystem.factorySmallCount + " factories!");
            }
            
            if (_buildSystem.hasMediumFactory)
            {
                playerMoney += _buildSystem.factoryMediumCount * _buildSystem.factoryMediumRate;
                Debug.Log("Medium factories make stuff, the player has: " + _buildSystem.factoryMediumCount + " factories!");
            }
            
            if (_buildSystem.hasLargeFactory)
            {
                playerMoney += _buildSystem.factoryLargeCount * _buildSystem.factoryLargeRate;
                Debug.Log("Large factories make stuff, the player has: " + _buildSystem.factoryLargeCount + " factories!");
            }
            
            UpdateDisplay();
        }
    
        /// <summary>
        /// Updates the displayText component with the player's current money.
        /// </summary>
        private void UpdateDisplay()
        {
            displayText.text = "Money: " + playerMoney.ToString();

        }

        public void UpdateEffectDisplay()
        {
            if (_researchSystem.hasSmallMultiplier == true)
            {
                smallMultiplierText.text = "Small Factories 2X!";
            }

            if (_researchSystem.hasMulticlickEffect == true)
            {
                multiclickText.text = "2X Pets!";
            }

            if (_researchSystem.hasLargeIncreaseEffect == true)
            {
                largeIncreaseText.text = "Large Factories more Effective!";
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(AddFactoryMoney), 10f, 10f);
        }
    
        private void OnDisable()
        {
            CancelInvoke(nameof(AddFactoryMoney));
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

    }

}
