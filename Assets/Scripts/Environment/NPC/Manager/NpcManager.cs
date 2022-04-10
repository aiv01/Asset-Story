using UnityEngine;

[DisallowMultipleComponent]
public class NpcManager : MonoBehaviour {
    #region Serialized attributes
    [SerializeField]
    [Tooltip("All the npcs present in the level")]
    private Npc[] Npcs = null;

    [HideInInspector]
    [Tooltip("Transform of the player")]
    public Transform playerTransform = null;

    [SerializeField]
    [Tooltip("Minimum distance for the interaction between the player and the NPC")]
    private float minDist = 0f;

    [SerializeField]
    [Tooltip("Panel that will be activated during the dialogue")]
    private GameObject panel = null;
    #endregion
    #region Private attributes
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
        NpcsInteraction();
    }
    #region Update methods
    private void NpcsInteraction() {
        for (int i = 0; i < Npcs.Length; i++) {
            if ((Npcs[i].transform.position - playerTransform.position).magnitude <= minDist) {
                Npcs[i].dialogueSign.SetActive(true);
                if (ActivationCondition()) {
                    isActive = !isActive;
                }

                if (isActive) {
                    ActiveState(i);
                }
                else {
                    DisabledState(i);
                }
            }
            else {
                Npcs[i].dialogueSign.SetActive(false);
            }
        }
    }
    private bool ActivationCondition() {
        return Npcs[0].databaseInput.Player.GetButtonDown
               (Npcs[0].databaseInput.InteractButton);
    }
    private void ActiveState(int _npcNumber) {
        if (Npcs[_npcNumber] is NpcZombie) {
            Npcs[_npcNumber].mySpriteRenderer.sprite = Npcs[_npcNumber].databaseNPC.GetSprite((int)NpcSpritesType.OnDialogue);
        }

        Ui_Vignette.Instance.SetText(Npcs[_npcNumber].phrase);
        MessageManager.CallOnNpcInteraction();
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    private void DisabledState(int _npcNumber) {
        MessageManager.CallOnEscDialogue();
        if (Npcs[_npcNumber] is NpcZombie) {
            Npcs[_npcNumber].mySpriteRenderer.sprite = Npcs[_npcNumber].databaseNPC.GetSprite((int)NpcSpritesType.OffDialogue);
        }

        Time.timeScale = 1;
        panel.SetActive(false);
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