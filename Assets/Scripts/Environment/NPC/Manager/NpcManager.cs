using UnityEngine;

[DisallowMultipleComponent]
public class NpcManager : MonoBehaviour {
    #region Private attributes
    [SerializeField]
    [Tooltip("All the npcs present in the level")]
    private Npc[] Npcs = null;

    [SerializeField]
    [Tooltip("Transform of the player")]
    private Transform playerTransform = null;

    [SerializeField]
    [Tooltip("Minimum distance for the interaction between the player and the NPC")]
    private float minDist = 0f;

    private bool isActive = false;
    #endregion



    private void Start() {
        AddListeners();
    }
    #region Start methods
    private void AddListeners() {
        MessageManager.OnTurnOffVignette += UnSetBool;
    } 
    #endregion



    #region Events methods
    private void UnSetBool() { 
        isActive = false;
    }
    #endregion



    void Update() {
        if (ActivationCondition()) {
            isActive = !isActive;
        }

        NpcsInteraction();
    }
    #region Update methods
    private bool ActivationCondition() {
        return Npcs[0].databaseInput.Player.GetButtonDown
               (Npcs[0].databaseInput.InteractButton);
    }


    private void NpcsInteraction() {
        for (int i = 0; i < Npcs.Length; i++) {
            if ((Npcs[i].transform.position - playerTransform.position).magnitude <= minDist) {
                Npcs[i].dialogueSign.SetActive(true);
                if (isActive) {
                    if (Npcs[i] is NpcZombie) {
                        Npcs[i].mySpriteRenderer.sprite = Npcs[i].databaseNPC.GetSprite((int)NpcSpritesType.OnDialogue);
                    }
                    Ui_Vignette.Instance.SetText(Npcs[i].phrase);
                    MessageManager.CallOnNpcInteraction();
                }
                else {
                    MessageManager.CallOnEscDialogue();
                    if (Npcs[i] is NpcZombie) {
                        Npcs[i].mySpriteRenderer.sprite = Npcs[i].databaseNPC.GetSprite((int)NpcSpritesType.OffDialogue);
                    }
                }
            }
            else {
                Npcs[i].dialogueSign.SetActive(false);
            }
        }
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTurnOffVignette -= UnSetBool;
    } 
    #endregion
}