/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 27/10/2024 (DD/MM/YY)
*/


using SDJam.Utils;
using UnityEngine;


namespace SDJam.Game {
    public class GameController : MonoBehaviour {
        #region Variables
        [SerializeField]
        private Timer gameTimer;
        #endregion


        #region MonoBehaviour methods
        private void Start() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion


        #region Public methods
        public void GameOver() {
            Debug.Log( "Game Over :c" );
        }

        public void GameCleared() {
            Debug.Log( "Game cleared!" );
        }
        #endregion
    }
}