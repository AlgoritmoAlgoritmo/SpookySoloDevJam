/*
* Author: irisGameDev
* GitHub: https://github.com/irisGameDev
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
        #endregion

        #region MonoBehaviour methods
        private void Awake() {
            lightController.TurnLight( lightController.HasToStartOn );
        }

        private void Start() {
            batteryTimer.StartTimer();
            batteryTimer.SetPause( !lightController.HasToStartOn );
            batteryTimer.OnRemaningTimeUpdated.AddListener( UpdateView );
        }
        #endregion

        #region Public methods
        public void ToggleLight() {
            lightController.SwitchLightOnOff();
            batteryTimer.TogglePause();
        }
        #endregion

        #region Private methods
        private void UpdateView() {
            batteryBar.fillAmount = batteryTimer.RemainingTime / batteryTimer.TimeLimit;
        }
        #endregion
    }
}