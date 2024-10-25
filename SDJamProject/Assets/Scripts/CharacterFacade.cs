/*
* Author: irisGameDev
* GitHub: https://github.com/irisGameDev
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace SDJam.Player {
    public class CharacterFacade : MonoBehaviour {
        #region Variables
        [SerializeField]
        private CharacterMovement characterMovement;
        
        #endregion

        #region MonoBehaviour methods
        private void FixedUpdate() {
            ManageInput();
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
        }
        #endregion
    }
}