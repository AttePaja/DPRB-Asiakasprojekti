using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MilestoneSystem : MonoBehaviour
    {
        public int clickAmount = 0;
        private int milestone1 = 100;
        private int milestone2 = 200;
        private int milestone3 = 300;
        public bool milestone1Reached = false;
        public bool milestone2Reached = false;
        public bool milestone3Reached = false;

        public Image milestone1Image;
        public Image milestone2Image;
        public Image milestone3Image;

        public void AddClick(int _amount)
        {
            clickAmount += _amount;
        }

        private void Update()
        {
            CheckMilestones();
        }

        private void CheckMilestones()
        {
            if(milestone1Reached == false && clickAmount >= milestone1)
            {
                milestone1Reached = true;
                milestone1Image.enabled = false;
                Debug.Log("Milestone 1 reached!");
            }

            if (milestone2Reached == false && clickAmount >= milestone2)
            {
                milestone2Reached = true;
                milestone2Image.enabled = false;
                Debug.Log("Milestone 2 reached!");
            }

            if (milestone3Reached == false && clickAmount >= milestone3)
            {
                milestone3Reached = true;
                milestone3Image.enabled = false;
                Debug.Log("Milestone 3 reached!");
            }
        }
    }
}
