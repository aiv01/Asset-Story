using UnityEngine;
using UnityEngine.EventSystems;

public class Ui_CustomButton : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        MessageManager.CallOnClickCustomButton();
    }
}
