using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
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
        public FactoryInfoSystem _factoryInfoSystem;
        public ResearchInfoSystem _researchInfoSystem;

        public TextMeshProUGUI[] researchPriceTexts = new TextMeshProUGUI[9];
        public TextMeshProUGUI resText;

        

        private void Awake()
        {
            researchPriceTexts[0].text = largeFactoryResearchCOST.ToString();
            researchPriceTexts[1].text = smallMultiplierEffectCOST.ToString();
            researchPriceTexts[2].text = largeFactoryBoostCOST.ToString();
            researchPriceTexts[3].text = RPpointCOST.ToString();
            researchPriceTexts[4].text = RPpointPlusCOST.ToString();
            researchPriceTexts[5].text = critChanceCOST.ToString();
            researchPriceTexts[6].text = critIncreaseCOST.ToString();
            researchPriceTexts[7].text = doubleUpCOST.ToString();
            researchPriceTexts[8].text = nextStepCOST.ToString();
        }

        private void Update()
        {
            resText.text = "RP: " + _clickSystem.researchPoints;
        }

        public void ResearchLargeFactory()
        {
            if (_clickSystem.researchPoints >= largeFactoryResearchCOST && researchedLargeFactory == false)
            {
                _clickSystem.researchPoints -= largeFactoryResearchCOST;
                researchedLargeFactory = true;
                lockIMG_R_SM.enabled = false;
                unlockIMG_R_LF.enabled = true;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _buildSystem.largeLock.SetActive(false);
                _factoryInfoSystem.isUnlocked[2] = true;
                _researchInfoSystem.isUnlocked[1] = true;
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _clickSystem.UpdateEffectDisplay();
                _researchInfoSystem.isUnlocked[2] = true;
                _researchInfoSystem.isUnlocked[5] = true;
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _clickSystem.UpdateEffectDisplay();
                _researchInfoSystem.isUnlocked[3] = true;
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _buildSystem.rptLock.SetActive(false);
                _factoryInfoSystem.isUnlocked[4] = true;
                _researchInfoSystem.isUnlocked[4] = true;
                if (nextStepImageReady) { lockIMG_R_NS.enabled = false; _researchInfoSystem.isUnlocked[8] = true; } else nextStepImageReady = true;
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
            }
        }

        public void ResearchCritChance()
        {
            if (_clickSystem.researchPoints >= critChanceCOST && researchedCritChance == false && researchedSmallMultiplier == true)
            {
                _clickSystem.researchPoints -= critChanceCOST;
                _buildSystem.critPayout = 100;
                researchedCritChance = true;
                lockIMG_R_CI.enabled = false;
                lockIMG_R_DU.enabled = false;
                unlockIMG_R_CC.enabled = true;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _buildSystem.critLock.SetActive(false);
                _clickSystem.UpdateEffectDisplay();
                _factoryInfoSystem.isUnlocked[3] = true;
                _researchInfoSystem.isUnlocked[6] = true;
                _researchInfoSystem.isUnlocked[7] = true;
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
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
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _buildSystem.doubleLock.SetActive(false);
                _factoryInfoSystem.isUnlocked[5] = true;
                if (nextStepImageReady) { lockIMG_R_NS.enabled = false; _researchInfoSystem.isUnlocked[8] = true; } else nextStepImageReady = true;
                _clickSystem.UpdateEffectDisplay();
                
            }
        }

        public void ResearchNextStep ()
        {
            if (_clickSystem.researchPoints >= nextStepCOST && researchedNextStep == false && researchedDoubleUp == true && researchedRPpoint == true)
            {
                _clickSystem.researchPoints -= nextStepCOST;
                researchedNextStep = true;
                unlockIMG_R_NS.enabled = true;
                GameObject.FindGameObjectWithTag("SoundBoard").GetComponent<SoundBoard>().PlayAudioClip(2);
                _buildSystem.nextStepLock.SetActive(false);
                _factoryInfoSystem.isUnlocked[6] = true;
                _clickSystem.UpdateEffectDisplay();
            }
        }




        
    }
}
