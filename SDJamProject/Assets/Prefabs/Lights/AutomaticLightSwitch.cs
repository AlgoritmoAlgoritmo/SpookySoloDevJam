/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 26/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using UnityEngine.Events;


namespace SDJam.Lights {
    public class AutomaticLightSwitch : MonoBehaviour {
        #region Variables
        [SerializeField]
        private LightController lightController;
        [SerializeField]
        private Vector2 lightOnTimeRange = new Vector2( 1f, 12f );

        public UnityEvent OnTurnOn = new UnityEvent();
        public UnityEvent OnTurnOff = new UnityEvent();

        private bool isWaitingToAutomaticallyTurnOff;
        #endregion


        #region MonoBehaviour methods
        private void Start() {
            TurnOff();
            TurnOn();
        }
        #endregion


        #region Public methods
        public void ToggleOnOff() {
            Debug.Log( "ToggleOnOff" );

            if( lightController.IsOn() ) {
                Debug.Log( "IsOn" );
                TurnOff();

            } else {
                Debug.Log( "IsOff" );
                TurnOn();
            }
        }

        public void TurnOn() {
            lightController.TurnLight( true );
            OnTurnOn.Invoke();

            if( !isWaitingToAutomaticallyTurnOff ) {
                isWaitingToAutomaticallyTurnOff = true;
                Invoke( "AutomaticTurnOff", Random.Range(lightOnTimeRange.x, lightOnTimeRange.y) );
            }
        }

        public void TurnOff() {
            lightController.TurnLight( false );
            OnTurnOff.Invoke();
        }
        #endregion


        #region Private methods
        private void AutomaticTurnOff() {
            Debug.Log( "AutomaticTurnOff" );
            TurnOff();
            isWaitingToAutomaticallyTurnOff = false;
        }
        #endregion
    }
}