using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    public class ResearchSystem : MonoBehaviour
    {
        [SerializeField] public int smallMultiplierEffect = 2;
        [SerializeField] public int mediumSaleEffect = 5;
        [SerializeField] public int largeIncreaseEffect = 10;
        [SerializeField] public int multiclickEffect = 1;

        [SerializeField] private int smallMultiplierEffectCOST = 5;
        [SerializeField] private int mediumSaleEffectCOST = 10;
        [SerializeField] private int largeIncreaseEffectCOST = 20;
        [SerializeField] private int multiclickEffectCOST = 20;

        public bool hasSmallMultiplier = false;
        public bool hasMediumSaleEffect = false;
        public bool hasLargeIncreaseEffect = false;
        public bool hasMulticlickEffect = false;

        [SerializeField] public ClickSystem _clickSystem;
        [SerializeField] public BuildSystem _buildSystem;

        public void ResearchSmallMultiplierEffect()
        {
            if (_clickSystem.playerMoney >= smallMultiplierEffectCOST && hasSmallMultiplier == false)
            {
                _clickSystem.playerMoney -= smallMultiplierEffectCOST;
                hasSmallMultiplier = true;
                _buildSystem.factorySmallRate = _buildSystem.factorySmallRate * smallMultiplierEffect;
                _clickSystem.UpdateEffectDisplay();
                /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
            }
        }

        public void ResearchMediumSaleEffect()
        {
            if (_clickSystem.playerMoney >= mediumSaleEffectCOST && hasMediumSaleEffect == false)
            {
                _clickSystem.playerMoney -= mediumSaleEffectCOST;
                hasSmallMultiplier = true;
                _buildSystem.factoryMediumCost -= mediumSaleEffect;
                /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
            }
        }

        public void ResearchLargeIncreaseEffect()
        {
            if (_clickSystem.playerMoney >= largeIncreaseEffectCOST && hasLargeIncreaseEffect == false)
            {
                _clickSystem.playerMoney -= largeIncreaseEffectCOST;
                hasLargeIncreaseEffect = true;
                _buildSystem.factoryLargeRate += largeIncreaseEffect;
                _clickSystem.UpdateEffectDisplay();
                /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
            }
        }

        public void ResearchMulticlickEffect()
        {
            if (_clickSystem.playerMoney >= multiclickEffectCOST && hasMulticlickEffect == false)
            {
                _clickSystem.playerMoney -= multiclickEffectCOST;
                hasMulticlickEffect = true;
                multiclickEffect = 2;
                _clickSystem.UpdateEffectDisplay();
                /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
            }
        }
    }
}
