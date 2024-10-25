/*
* Author: irisGameDev
* GitHub: https://github.com/irisGameDev
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace SDJam.Common {
    public class LightSwitchController : MonoBehaviour {
        #region Variables
        [SerializeField]
        private GameObject lightGameObject;
        [SerializeField]
        private bool hasToStartOn;
        #endregion


        #region MonoBehaviour methods
        private void Awake() {
            TurnLight( hasToStartOn );
        }
        #endregion


        #region Public methods
        public void SwitchLightOnOff() {
            TurnLight( !lightGameObject.activeInHierarchy );
        }

        public void TurnLight( bool _turnOn ) {
            lightGameObject.SetActive( _turnOn );
        }
        #endregion
    }
}