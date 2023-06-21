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
    public class BuildMenu : MonoBehaviour
    {
        public GridLayoutGroup buildAreaGrid;
        public int GetBuildAreaGridIndex(Button _button)
        {
            // Get the index of the button in the grid layout
            int buttonIndex = -1;
        
            for (int i = 0; i < buildAreaGrid.transform.childCount; i++)
            {
                if (_button.transform == buildAreaGrid.transform.GetChild(i))
                {
                    buttonIndex = i;
                    break;
                }
            }

            return buttonIndex;
        }
        
    }
}
