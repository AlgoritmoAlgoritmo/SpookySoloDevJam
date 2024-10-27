/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using SDJam.Lights;
using SDJam.Interactions;


namespace SDJam.Player {
    public class CharacterFacade : MonoBehaviour {
        #region Variables
        [SerializeField]
        private CharacterMovement characterMovement;
        [SerializeField]
        private FlashlightController flashlightController;
        [SerializeField]
        private InteractionController interactionsController;
        #endregion

        #region MonoBehaviour methods
        private void FixedUpdate() {
            ManageInput();
            interactionsController.ManageInteractions();
        }
        #endregion

        #region Private methods
        private void ManageInput() {
            if( Input.GetKey( KeyCode.W ) ) {
                characterMovement.MoveForward();
            
            } else if( Input.GetKey( KeyCode.S ) ) {
                characterMovement.MoveBack();
            }

            if( Input.GetKey( KeyCode.A ) ) {
                characterMovement.MoveLeft();

            } else if( Input.GetKey( KeyCode.D ) ) {
                characterMovement.MoveRight();
            }

            if( Input.GetKeyUp( KeyCode.F ) ) {
                flashlightController.ToggleLight();
            }
        }
        #endregion
    }
}