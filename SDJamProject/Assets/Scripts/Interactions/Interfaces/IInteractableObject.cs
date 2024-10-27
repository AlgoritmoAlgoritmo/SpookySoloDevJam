/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 27/10/2024 (DD/MM/YY)
*/


namespace SDJam.Interactions.Interfaces {
    public interface IInteractableObject {
        #region Abstract methods
        string GetInteractionText();

        void Interact();
        #endregion
    }
}