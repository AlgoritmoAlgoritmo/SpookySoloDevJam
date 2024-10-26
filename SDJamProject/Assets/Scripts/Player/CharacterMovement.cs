/*
* Author: irisGameDev
* GitHub: https://github.com/irisGameDev
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace SDJam.Player {
    [System.Serializable]
    public class CharacterMovement {
        #region Variables
        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private float speed = 1f;
        #endregion

        #region Public methods
        public void Move( Vector3 _direction ) {
            characterController.SimpleMove( _direction * speed );
        }


        public void MoveForward( ) {
            Move( characterController.transform.forward );
        }

        public void MoveBack() {
            Move( characterController.transform.forward * -1 );
        }

        public void MoveLeft() {
            Move( characterController.transform.right * -1 );
        }

        public void MoveRight() {
            Move( characterController.transform.right );
        }
        #endregion
    }
}