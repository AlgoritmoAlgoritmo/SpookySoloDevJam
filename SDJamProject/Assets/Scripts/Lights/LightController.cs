/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace SDJam.Lights {
    [System.Serializable]
    public class LightController {
        #region Variables
        [SerializeField]
        private GameObject lightGameObject;
        [SerializeField]
        private bool hasToStartOn;
        public bool HasToStartOn {
            get { return hasToStartOn; }
        }
        #endregion

        #region Public methods
        public void SwitchLightOnOff() {
            TurnLight( !lightGameObject.activeInHierarchy );
        }

        public void TurnLight( bool _turnOn ) {
            lightGameObject.SetActive( _turnOn );
        }

        public bool IsOn() {
            return lightGameObject.activeInHierarchy;
        }
        #endregion
    }
}