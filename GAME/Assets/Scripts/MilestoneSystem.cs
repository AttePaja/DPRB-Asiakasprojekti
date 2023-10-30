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

        // private int milestone1 = 100;
        // private int milestone2 = 300;
        // private int milestone3 = 600;
        // private int milestone4 = 1000;
        // private int milestone5 = 1500;
        // private int milestone6 = 2000;
        // private int milestone7 = 3000;
        // private int milestone8 = 5000;
        // private int milestone9 = 8000;
        // private int milestone10 = 10000;
        public int[] milestones = { 100, 300, 600, 1000, 1500, 2000, 3000, 5000, 8000, 10000 };
        // public bool milestone1Reached = false;
        // public bool milestone2Reached = false;
        // public bool milestone3Reached = false;
        // public bool milestone4Reached = false;
        // public bool milestone5Reached = false;
        // public bool milestone6Reached = false;
        // public bool milestone7Reached = false;
        // public bool milestone8Reached = false;
        // public bool milestone9Reached = false;
        // public bool milestone10Reached = false;
        private bool[] milestonesReached = { false, false, false, false, false, false, false, false, false, false};

        // public Image milestone1Image;
        // public Image milestone2Image;
        // public Image milestone3Image;
        // public Image milestone4Image;
        // public Image milestone5Image;
        // public Image milestone6Image;
        // public Image milestone7Image;
        // public Image milestone8Image;
        // public Image milestone9Image;
        // public Image milestone10Image;

        [SerializeField] public Image[] milestoneImages = new Image[10];
        // [SerializeField] public Image currentMilestoneImage;
        [SerializeField] public TextMeshProUGUI milestoneText;

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
                currentMilestone++;
            }
        }


        // UPDATE TO A BETTER SOLUTION AAAAAAAAAAAAAAAAAAAAA
        // public void CheckMilestones()
        // {
        //     if(milestone1Reached == false && clickAmount >= milestone1)
        //     {
        //         milestone1Reached = true;
        //         milestone1Image.enabled = false;
        //         Debug.Log("Milestone 1 reached!");
        //     }
        // 
        //     if (milestone2Reached == false && clickAmount >= milestone2)
        //     {
        //         milestone2Reached = true;
        //         milestone2Image.enabled = false;
        //         Debug.Log("Milestone 2 reached!");
        //     }
        // 
        //     if (milestone3Reached == false && clickAmount >= milestone3)
        //     {
        //         milestone3Reached = true;
        //         milestone3Image.enabled = false;
        //         Debug.Log("Milestone 3 reached!");
        //     }
        // 
        //     if (milestone4Reached == false && clickAmount >= milestone4)
        //     {
        //         milestone4Reached = true;
        //         milestone4Image.enabled = false;
        //         Debug.Log("Milestone 4 reached!");
        //     }
        // 
        //     if (milestone5Reached == false && clickAmount >= milestone5)
        //     {
        //         milestone5Reached = true;
        //         milestone5Image.enabled = false;
        //         Debug.Log("Milestone 5 reached!");
        //     }
        // 
        //     if (milestone6Reached == false && clickAmount >= milestone6)
        //     {
        //         milestone6Reached = true;
        //         milestone6Image.enabled = false;
        //         Debug.Log("Milestone 6 reached!");
        //     }
        // 
        //     if (milestone7Reached == false && clickAmount >= milestone7)
        //     {
        //         milestone7Reached = true;
        //         milestone7Image.enabled = false;
        //         Debug.Log("Milestone 3 reached!");
        //     }
        // 
        //     if (milestone8Reached == false && clickAmount >= milestone8)
        //     {
        //         milestone8Reached = true;
        //         milestone8Image.enabled = false;
        //         Debug.Log("Milestone 8 reached!");
        //     }
        // 
        //     if (milestone9Reached == false && clickAmount >= milestone9)
        //     {
        //         milestone9Reached = true;
        //         milestone9Image.enabled = false;
        //         Debug.Log("Milestone 9 reached!");
        //     }
        // 
        //     if (milestone10Reached == false && clickAmount >= milestone10)
        //     {
        //         milestone10Reached = true;
        //         milestone10Image.enabled = false;
        //         Debug.Log("Milestone 10 reached!");
        //     }
        // }
    }
}
