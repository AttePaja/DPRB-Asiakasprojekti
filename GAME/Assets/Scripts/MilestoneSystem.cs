using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class MilestoneSystem : MonoBehaviour
    {
        public int clickAmount = 0;
        public int currentMilestone = 0;

        
        public int[] milestones = { 100, 300, 600, 1000, 1500, 2000, 3000, 5000, 8000, 10000 };
        
        private bool[] milestonesReached = { false, false, false, false, false, false, false, false, false, false};

        

        [SerializeField] public Image[] milestoneImages = new Image[10];
        // [SerializeField] public Image currentMilestoneImage;
        [SerializeField] public TextMeshProUGUI milestoneText;
        public TextMeshProUGUI milestoneCounterText;

        public void AddClick(int _amount)
        {
            clickAmount += _amount;
        }


        public void CheckMilestones(int _milestone)
        {
            if (milestonesReached[_milestone] == false && clickAmount >= milestones[_milestone])
            {
                milestonesReached[_milestone] = true;
                milestoneImages[_milestone].color = Color.green;
                // currentMilestoneImage = milestoneImages[_milestone];
                Debug.Log("Milestone " + _milestone + " reached!");
                if (milestonesReached[9] == false) currentMilestone++;
            }
            
            if (milestonesReached[9] == true) { milestoneText.text = "Research and Build the Next Step"; };
        }


        
    }
}
