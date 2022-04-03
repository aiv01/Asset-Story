using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class SfxManager : MonoBehaviour {
    #region Private enum
    private enum SfxType : byte {
        TakeTheKey,
        NpcInteract,
        TurnOffVignette,
        TouchedCheckPoint,
        OpenTheDoor,
        TakeTheHealth,
        TouchedTheSpikes,
        PlatformMovement,
        Last
    }
    #endregion
    #region Private attributes
    [SerializeField]
    [Tooltip("Sources that will each play a specific clip")]
    private AudioSource[] audioSources = new AudioSource[(int)SfxType.Last];

    [SerializeField]
    [Tooltip("All sfx audioclips")]
    private AudioClip[] audioClips = new AudioClip[(int)SfxType.Last];
    #endregion



    void Start() {
        AddListeners();
    }
    #region Start methods
    private void AddListeners() {
        MessageManager.OnTakeTheKey += PlayTakeTheKey;
        MessageManager.OnNpcInteraction += PlayNpcInteract;
        MessageManager.OnTurnOffVignette += PlayTurnOffVignette;
        MessageManager.OnTouchedTheCheckPoint += PlayTouchedCheckPoint;
        MessageManager.OnOpenTheDoor += PlayOpenTheDoor;
        MessageManager.OnTakeTheHealth += PlayTakeTheHealth;
        MessageManager.OnTouchedTheTrap += PlayTouchedTheSpikes;
    }
    #endregion



    #region Event methods
    private void PlayTakeTheKey() {
        audioSources[(int)SfxType.TakeTheKey].PlayOneShot(audioClips[(int)SfxType.TakeTheKey]);
    }
    private void PlayNpcInteract() {
        audioSources[(int)SfxType.NpcInteract].PlayOneShot(audioClips[(int)SfxType.NpcInteract]);
    }
    private void PlayTurnOffVignette() {
        audioSources[(int)SfxType.TurnOffVignette].PlayOneShot(audioClips[(int)SfxType.TurnOffVignette]);
    }
    private void PlayTouchedCheckPoint() {
        audioSources[(int)SfxType.TouchedCheckPoint].PlayOneShot(audioClips[(int)SfxType.TouchedCheckPoint]);
    }
    private void PlayOpenTheDoor() {
        audioSources[(int)SfxType.OpenTheDoor].PlayOneShot(audioClips[(int)SfxType.OpenTheDoor]);
    }
    private void PlayTakeTheHealth() {
        audioSources[(int)SfxType.TakeTheHealth].PlayOneShot(audioClips[(int)SfxType.TakeTheHealth]);
    }
    private void PlayTouchedTheSpikes() {
        audioSources[(int)SfxType.TouchedTheSpikes].PlayOneShot(audioClips[(int)SfxType.TouchedTheSpikes]);
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestoy methods
    private void RemoveListeners() {
        MessageManager.OnTakeTheKey -= PlayTakeTheKey;
        MessageManager.OnNpcInteraction -= PlayNpcInteract;
        MessageManager.OnTurnOffVignette -= PlayTurnOffVignette;
        MessageManager.OnTouchedTheCheckPoint -= PlayTouchedCheckPoint;
        MessageManager.OnOpenTheDoor -= PlayOpenTheDoor;
        MessageManager.OnTakeTheHealth -= PlayTakeTheHealth;
        MessageManager.OnTouchedTheTrap -= PlayTouchedTheSpikes;
    } 
    #endregion
}