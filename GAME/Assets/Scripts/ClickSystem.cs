using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{

    public class ClickSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI displayText; // Text component to display playerMoney
        [SerializeField] private Canvas MainCanvas;
        [SerializeField] private Canvas BuildCanvas;
    
        public int playerMoney = 0; // Money the player has
        private int activeCanvas = 1;

        [SerializeField] public BuildSystem _buildSystem;
    
        private void Awake()
        {
            UpdateDisplay();
        }
    
        /// <summary>
        /// Increases the player's money by a set amount.
        /// </summary>
        public void IncreaseMoney()
        {
            playerMoney++;
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
    
        private void OnEnable()
        {
            InvokeRepeating(nameof(AddFactoryMoney), 10f, 10f);
        }
    
        private void OnDisable()
        {
            CancelInvoke(nameof(AddFactoryMoney));
        }
    
    
        public void ChangeCanvas()
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
    
    }

}
