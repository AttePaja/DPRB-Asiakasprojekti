using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Assets.Scripts
{

    public class BuildSystem : MonoBehaviour
    {
        [SerializeField] public int factorySmallCost = 10;
        [SerializeField] public int factoryMediumCost = 20;
        [SerializeField] public int factoryLargeCost = 30;

        [SerializeField] public int factorySmallRate = 1;
        [SerializeField] public int factoryMediumRate = 2;
        [SerializeField] public int factoryLargeRate = 3;

        public int factorySmallCount = 0;
        public int factoryMediumCount = 0;
        public int factoryLargeCount = 0;

        public bool hasSmallFactory = false;
        public bool hasMediumFactory = false;
        public bool hasLargeFactory = false;

        [SerializeField] private TextMeshProUGUI smallText;
        [SerializeField] private TextMeshProUGUI mediumText;
        [SerializeField] private TextMeshProUGUI largeText;

        [SerializeField] public ClickSystem _clickSystem;
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

        public void BuyFactoryMedium()
        {
            if (_clickSystem.playerMoney >= factoryMediumCost)
            {
                _clickSystem.playerMoney -= factoryMediumCost;
                factoryMediumCount++;
                hasMediumFactory = true;
                UpdateFactoryDisplays();
            }
        }

        public void BuyFactoryLarge()
        {
            if (_clickSystem.playerMoney >= factoryLargeCost)
            {
                _clickSystem.playerMoney -= factoryLargeCost;
                factoryLargeCount++;
                hasLargeFactory = true;
                UpdateFactoryDisplays();
            }
        }

        private void UpdateFactoryDisplays()
        {
            smallText.text = "Owned: " + factorySmallCount;
            mediumText.text = "Owned: " + factoryMediumCount;
            largeText.text = "Owned: " + factoryLargeCount;
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
