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
        #endregion


        #region MonoBehaviour methods
        private void Start() {
            TurnOff();
            TurnOn();
        }
        #endregion


        #region Public methods
        public void TurnOn() {
            if( !lightController.IsOn() ) {
                lightController.TurnLight( true );
                Invoke( "TurnOff", Random.Range(lightOnTimeRange.x, lightOnTimeRange.y) );
                OnTurnOn.Invoke();
            }
        }

        public void TurnOff() {
            if( lightController.IsOn() ) {
                lightController.TurnLight( false );
                OnTurnOff.Invoke();
            }
        }
        #endregion
    }
}