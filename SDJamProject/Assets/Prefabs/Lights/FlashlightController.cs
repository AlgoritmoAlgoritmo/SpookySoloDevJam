/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using SDJam.Utils;


namespace SDJam.Lights {
    public class FlashlightController : MonoBehaviour {
        #region Variables
        [Header("View variables")]
        [SerializeField]
        private UnityEngine.UI.Image batteryBar;

        [Header("Battery variables")]
        [SerializeField]
        private Timer batteryTimer;

        [Header( "Other variables" )]
        [SerializeField]
        private LightController lightController;

        [SerializeField]
        private bool isUsable = true;
        public bool IsUsable {
            get { return isUsable; }
            set { isUsable = value; }
        }
        #endregion

        #region MonoBehaviour methods
        private void Awake() {
            lightController.TurnLight( lightController.HasToStartOn );
        }

        private void Start() {
            batteryTimer.StartTimer();
            batteryTimer.SetPause( !lightController.HasToStartOn );
            batteryTimer.OnRemaningTimeUpdated.AddListener( UpdateView );
            batteryTimer.OnTimeRanOut.AddListener( SetFlashlightUnusable );
        }
        #endregion

        #region Public methods
        public void ToggleLight() {
            if( IsUsable ) {
                lightController.SwitchLightOnOff();
                batteryTimer.TogglePause();
            }
        }
        #endregion

        #region Private methods
        private void UpdateView() {
            batteryBar.fillAmount = batteryTimer.RemainingTime / batteryTimer.TimeLimit;
        }

        private void SetFlashlightUnusable() {
            IsUsable = false;
            lightController.TurnLight( IsUsable );
        }
        #endregion
    }
}