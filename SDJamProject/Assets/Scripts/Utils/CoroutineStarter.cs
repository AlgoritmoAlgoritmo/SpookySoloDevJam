/*
* Author: irisGameDev
* GitHub: https://github.com/irisGameDev
* Date: 25/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace SDJam.Utils {
    public class CoroutineStarter : MonoBehaviour {
        #region Variables
        private static CoroutineStarter instance;
        public static CoroutineStarter Instance {
            get {
                if( !instance ) {
                    instance = Instantiate( new GameObject () ).AddComponent<CoroutineStarter>();
                }

                return instance;
            }
        }
        #endregion
    }
}