/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 27/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using SDJam.Interactions.Interfaces;


namespace SDJam.Interactions {
    [System.Serializable]
    public class InteractionController {
        #region Variables
        [SerializeField]
        private KeyCode interactionKey = KeyCode.E;
        [SerializeField]
        private float MAX_DISTANCE = 2f;
        [SerializeField]
        private Camera fpsCamera;        
        [SerializeField]
        private TMPro.TMP_Text interactionText;
        

        private RaycastHit hit;
        private string actionText;

        private bool canInteract = true;
        private bool activeScaning = false;
        #endregion


        #region Public methods
        public void ManageInteractions() {
            if( canInteract 
                    && Physics.Raycast( fpsCamera.transform.position,
                                        fpsCamera.transform.forward,
                                        out hit, MAX_DISTANCE )
                    && hit.transform.gameObject.GetComponent<IInteractableObject>() != null ) {
                LookForPossibleInteractions();

            } else {
                ClearText();
            }
        }

        public void CanNotInteract( bool canInteract ) {
            this.canInteract = !canInteract;
        }
        #endregion

        #region Private methods
        private void LookForPossibleInteractions() {
            SetActionText();
            interactionText.text = actionText
                + hit.transform.gameObject.GetComponent<IInteractableObject>()?.GetInteractionText();

            if( Input.GetKeyUp( interactionKey ) ) {
                hit.transform.gameObject.GetComponent<IInteractableObject>()?.Interact();
            }
        }

        private void SetActionText() {
            actionText = "PRESS " + interactionKey + " TO\n";
        }

        private void ClearText() {
            interactionText.text = "";
        }
        #endregion

    }
}