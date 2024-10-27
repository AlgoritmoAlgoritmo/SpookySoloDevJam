/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 27/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using SDJam.Interactions.Interfaces;


namespace SDJam.Lights {
    public class LightSwitch : MonoBehaviour, IInteractableObject {
        #region Variables
        [SerializeField]
        private string interactionText = "Turn On/Off";
        [SerializeField]
        private AutomaticLightSwitch automaticLightSwitch;
        #endregion


        #region IInteractableObject methods
        public string GetInteractionText() {
            return interactionText;
        }

        public void Interact() {
            automaticLightSwitch.ToggleOnOff();
        }
        #endregion

    }
}