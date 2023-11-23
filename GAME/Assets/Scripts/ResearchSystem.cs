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
        public int smallMultiplierEffect = 2;
        public int largeMultiplierEffect = 2;

        public int largeFactoryResearchCOST = 10;
        public int smallMultiplierEffectCOST = 20;
        public int largeFactoryBoostCOST = 40;
        public int RPpointCOST = 600;
        public int RPpointPlusCOST = 800;
        public int critChanceCOST = 100;
        public int critIncreaseCOST = 300;
        public int doubleUpCOST = 500;
        public int nextStepCOST = 1000;

        public bool researchedLargeFactory = false;
        public bool researchedSmallMultiplier = false;
        public bool researchedLargeFactoryBoost = false;
        public bool researchedRPpoint = false;
        public bool researchedRPpointPlus = false;
        public bool researchedCritChance = false;
        public bool researchedCritIncrease = false;
        public bool researchedDoubleUp = false;
        public bool researchedNextStep = false;

        public Image lockIMG_R_SM;
        public Image lockIMG_R_LFB;
        public Image lockIMG_R_RP;
        public Image lockIMG_R_RPP;
        public Image lockIMG_R_CC;
        public Image lockIMG_R_CI;
        public Image lockIMG_R_DU;
        public Image lockIMG_R_NS;

        public Image unlockIMG_R_LF;
        public Image unlockIMG_R_SM;
        public Image unlockIMG_R_LFB;
        public Image unlockIMG_R_RP;
        public Image unlockIMG_R_RPP;
        public Image unlockIMG_R_CC;
        public Image unlockIMG_R_CI;
        public Image unlockIMG_R_DU;
        public Image unlockIMG_R_NS;

        private bool nextStepImageReady = false;

        public ClickSystem _clickSystem;
        public BuildSystem _buildSystem;

        // public int mediumSaleEffect = 5;
        // public int largeIncreaseEffect = 10;
        // 
        // public int mediumSaleEffectCOST = 10;
        // public int largeIncreaseEffectCOST = 20;
        // 
        // 
        // public bool researchedMediumSale = false;
        // public bool researchedLargeIncrease = false;
        // 

        public void ResearchLargeFactory()
        {
            if (_clickSystem.researchPoints >= largeFactoryResearchCOST && researchedLargeFactory == false)
            {
                _clickSystem.researchPoints -= largeFactoryResearchCOST;
                researchedLargeFactory = true;
                lockIMG_R_SM.enabled = false;
                unlockIMG_R_LF.enabled = true;
                _buildSystem.largeLock.SetActive(false);
            }
        }

        public void ResearchSmallMultiplierEffect()
        {
            if (_clickSystem.researchPoints >= smallMultiplierEffectCOST && researchedSmallMultiplier == false && researchedLargeFactory == true)
            {
                _clickSystem.researchPoints -= smallMultiplierEffectCOST;
                researchedSmallMultiplier = true;
                _buildSystem.factorySmallRate = _buildSystem.factorySmallRate * smallMultiplierEffect;
                lockIMG_R_LFB.enabled = false;
                lockIMG_R_CC.enabled = false;
                unlockIMG_R_SM.enabled = true;
                _clickSystem.UpdateEffectDisplay();
            }
        }

        public void ResearchLargeFactoryBoost()
        {
            if (_clickSystem.researchPoints >= largeFactoryBoostCOST && researchedLargeFactoryBoost == false && researchedSmallMultiplier == true)
            {
                _clickSystem.researchPoints -= largeFactoryBoostCOST;
                researchedLargeFactoryBoost = true;
                _buildSystem.factoryLargeRate = _buildSystem.factoryLargeRate * largeMultiplierEffect;
                lockIMG_R_RP.enabled = false;
                unlockIMG_R_LFB.enabled = true;
                _clickSystem.UpdateEffectDisplay();
            }
        }

        public void ResearchRPpoint()
        {
            if (_clickSystem.researchPoints >= RPpointCOST && researchedRPpoint == false && researchedLargeFactoryBoost == true)
            {
                _clickSystem.researchPoints -= RPpointCOST;
                researchedRPpoint = true;
                lockIMG_R_RPP.enabled = false;
                unlockIMG_R_RP.enabled = true;
                _buildSystem.rptLock.SetActive(false);
                if (nextStepImageReady) { lockIMG_R_NS.enabled = false; } else nextStepImageReady = true;
            }
        }

        public void ResearchRPpointPlus()
        {
            if (_clickSystem.researchPoints >= RPpointPlusCOST && researchedRPpointPlus == false && researchedRPpoint == true)
            {
                _clickSystem.researchPoints -= RPpointPlusCOST;
                researchedRPpointPlus = true;
                unlockIMG_R_RPP.enabled = true;
                _buildSystem.maxRPTownedAmount = 10;
            }
        }

        public void ResearchCritChance()
        {
            if (_clickSystem.researchPoints >= critChanceCOST && researchedCritChance == false && researchedSmallMultiplier == true)
            {
                _clickSystem.researchPoints -= critChanceCOST;
                researchedCritChance = true;
                lockIMG_R_CI.enabled = false;
                lockIMG_R_DU.enabled = false;
                unlockIMG_R_CC.enabled = true; 
                _buildSystem.critLock.SetActive(false);
                _clickSystem.UpdateEffectDisplay();
            }
        }

        public void ResearchCritIncrease()
        {
            if (_clickSystem.researchPoints >= critIncreaseCOST && researchedCritIncrease == false && researchedCritChance == true)
            {
                _clickSystem.researchPoints -= critIncreaseCOST;
                researchedCritIncrease = true;
                _clickSystem.critChance = 10;
                unlockIMG_R_CI.enabled = true;
                _clickSystem.UpdateEffectDisplay();
            }
        }

        public void ResearchDoubleUp()
        {
            if (_clickSystem.researchPoints >= doubleUpCOST && researchedDoubleUp == false && researchedCritChance == true)
            {
                _clickSystem.researchPoints -= doubleUpCOST;
                researchedDoubleUp = true;
                unlockIMG_R_DU.enabled = true;
                _buildSystem.doubleLock.SetActive(false);
                if (nextStepImageReady) { lockIMG_R_NS.enabled = false; } else nextStepImageReady = true;
                _clickSystem.UpdateEffectDisplay();
                /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
            }
        }

        public void ResearchNextStep ()
        {
            if (_clickSystem.researchPoints >= nextStepCOST && researchedNextStep == false && researchedDoubleUp == true && researchedRPpoint == true)
            {
                _clickSystem.researchPoints -= nextStepCOST;
                researchedNextStep = true;
                unlockIMG_R_NS.enabled = true;
                _buildSystem.nextStepLock.SetActive(false);
                _clickSystem.UpdateEffectDisplay();
            }
        }




        // public void ResearchMediumSaleEffect()
        // {
        //     if (_clickSystem.researchPoints >= mediumSaleEffectCOST && researchedMediumSale == false)
        //     {
        //         _clickSystem.researchPoints -= mediumSaleEffectCOST;
        //         researchedMediumSale = true;
        //         _buildSystem.factoryMediumCost -= mediumSaleEffect;
        //         /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
        //     }
        // }
        // 
        // public void ResearchLargeIncreaseEffect()
        // {
        //     if (_clickSystem.researchPoints >= largeIncreaseEffectCOST && researchedLargeIncrease == false)
        //     {
        //         _clickSystem.researchPoints -= largeIncreaseEffectCOST;
        //         researchedLargeIncrease = true;
        //         _buildSystem.factoryLargeRate += largeIncreaseEffect;
        //         _clickSystem.UpdateEffectDisplay();
        //         /// ADD CODE TO CHANGE IMAGE WHEN BOUGHT
        //     }
        // }
    }
}
