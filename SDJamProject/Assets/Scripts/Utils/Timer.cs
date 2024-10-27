/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 25/10/2024 (DD/MM/YY)
*/


using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SDJam.Utils;


namespace SDJam.Utils {
    [System.Serializable]
    public class Timer {
        #region Variables
        [SerializeField]
        private float timeLimit = 5f;
        public float TimeLimit {
            get {
                return timeLimit;
            }
        }
        [SerializeField]
        private float updateRateInSeconds = .1f;

        public UnityEvent OnTimeRanOut = new UnityEvent();
        public UnityEvent OnRemaningTimeUpdated = new UnityEvent();

        private float remainingTime;
        public float RemainingTime {
            get {
                return remainingTime;
            }
        }

        private bool isRunning;
        private bool isPaused;
        #endregion


        #region Public methods
        public void StartTimer() {
            if( !isRunning )
                CoroutineStarter.Instance.StartCoroutine( RunningTimer() );
        }

        public void Pause() {
            isPaused = true;
        }

        public void Resume() {
            isPaused = false;
        }

        public void SetPause( bool _pauseIt ) {
            isPaused = _pauseIt;
        }

        public void TogglePause() {
            isPaused = !isPaused;
        }
        #endregion


        #region Coroutines
        public IEnumerator RunningTimer() {
            if( !isRunning ) {
                isRunning = true;
                remainingTime = timeLimit;

                while( remainingTime > 0 && isRunning ) {
                    Debug.Log( remainingTime );
                    if( !isPaused ) {
                        remainingTime -= updateRateInSeconds;
                        OnRemaningTimeUpdated?.Invoke();
                    }

                    yield return new WaitForSecondsRealtime( updateRateInSeconds );
                }

                isRunning = false;
                OnTimeRanOut.Invoke();
            }
        }
        #endregion
    }
}