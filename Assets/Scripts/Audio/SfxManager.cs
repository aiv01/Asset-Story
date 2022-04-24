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
        ChomperHitted,
        SpitterHitted,
        GunnerHitted,
        ChomperDead,
        SpitterDead,
        PlayerShoot,
        PlayerHit,
        PlayerWalk,
        GunnerDead,
        GunnerShoot,
        GunnerWalk,
        GunnerDash,
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
        SetVolume();
        AddListeners();
    }
    #region Start methods
    private void SetVolume() {
        for (int i = 0; i < audioSources.Length; i++) {
            audioSources[i].volume = 1f;
        }
    }
    private void AddListeners() {
        MessageManager.OnTakeTheKey += PlayTakeTheKey;
        MessageManager.OnNpcInteraction += PlayNpcInteract;
        MessageManager.OnTurnOffVignette += PlayTurnOffVignette;
        MessageManager.OnTouchedTheCheckPoint += PlayTouchedCheckPoint;
        MessageManager.OnOpenTheDoor += PlayOpenTheDoor;
        MessageManager.OnTakeTheHealth += PlayTakeTheHealth;
        MessageManager.OnTouchedTheTrap += PlayTouchedTheSpikes;
        MessageManager.OnChomperHitted += PlayChomperHitted;
        MessageManager.OnSpitterHitted += PlaySpitterHitted;
        MessageManager.OnChomperDead += PlayChomperDead;
        MessageManager.OnSpitterDead += PlaySpitterDead;
        MessageManager.OnGunnerHitted += PlayGunnerHitted;
        MessageManager.OnPlayerShoot += PlayPlayerShoot;
        MessageManager.OnPlayerHit += PlayPlayerHit;
        MessageManager.OnPlayerWalk += PlayPlayerWalk;
        MessageManager.OnGunnerDead += PlayGunnerDead;
        MessageManager.OnGunnerShoot += PlayGunnerShoot;
        MessageManager.OnGunnerWalk += PlayGunnerWalk;
        MessageManager.OnGunnerDash += PlayGunnerDash;
    }
    #endregion


    private void Play(SfxType _type) {
        var source = audioSources[(int)_type];

        if (!source.isPlaying) {
            source.clip = audioClips[(int)_type];
            source.Play();
        }
}


    #region Event methods
    private void PlayTakeTheKey() {
        Play(SfxType.TakeTheKey);
    }
    private void PlayNpcInteract() {
        Play(SfxType.NpcInteract);

    }
    private void PlayTurnOffVignette() {
        Play(SfxType.TurnOffVignette);

    }
    private void PlayTouchedCheckPoint() {

        Play(SfxType.TouchedCheckPoint);

    }
    private void PlayOpenTheDoor() {
        Play(SfxType.OpenTheDoor);

    }
    private void PlayTakeTheHealth() {
        Play(SfxType.TakeTheHealth);

    }
    private void PlayTouchedTheSpikes() {
        Play(SfxType.TouchedTheSpikes);

    }
    private void PlayChomperHitted() {
        audioSources[(int)SfxType.ChomperHitted].PlayOneShot(audioClips[(int)SfxType.ChomperHitted]);
    }
    private void PlaySpitterHitted() {
        audioSources[(int)SfxType.SpitterHitted].PlayOneShot(audioClips[(int)SfxType.SpitterHitted]);
    }
    private void PlayGunnerHitted() {
        audioSources[(int)SfxType.GunnerHitted].volume = 0.3f;
        audioSources[(int)SfxType.GunnerHitted].PlayOneShot(audioClips[(int)SfxType.GunnerHitted]);
    }
    private void PlayGunnerShoot() {
        audioSources[(int)SfxType.GunnerShoot].PlayOneShot(audioClips[(int)SfxType.GunnerShoot]);

        //Play(SfxType.GunnerShoot);

    }
    private void PlayGunnerWalk() {
        Play(SfxType.GunnerWalk);

    }
    private void PlayGunnerDash() {
        Play(SfxType.GunnerDash);

    }
    private void PlayChomperDead() {
        Play(SfxType.ChomperDead);

    }
    private void PlaySpitterDead() {
        Play(SfxType.SpitterDead);

    }
    private void PlayGunnerDead() { 
        Play(SfxType.GunnerDead);

    }
    private void PlayPlayerShoot() {
        audioSources[(int)SfxType.PlayerShoot].PlayOneShot(audioClips[(int)SfxType.PlayerShoot]);
    }
    private void PlayPlayerHit() {
        Play(SfxType.PlayerHit);

    }
    private void PlayPlayerWalk() {
        Play(SfxType.PlayerWalk);

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
        MessageManager.OnChomperHitted -= PlayChomperHitted;
        MessageManager.OnSpitterHitted -= PlaySpitterHitted;
        MessageManager.OnChomperDead -= PlayChomperDead;
        MessageManager.OnSpitterDead -= PlaySpitterDead;
        MessageManager.OnGunnerHitted -= PlayGunnerHitted;
        MessageManager.OnPlayerShoot -= PlayPlayerShoot;
        MessageManager.OnPlayerHit -= PlayPlayerHit;
        MessageManager.OnPlayerWalk -= PlayPlayerWalk;
        MessageManager.OnGunnerDead -= PlayGunnerDead;
        MessageManager.OnGunnerShoot -= PlayGunnerShoot;
        MessageManager.OnGunnerWalk -= PlayGunnerWalk;
        MessageManager.OnGunnerDash -= PlayGunnerDash;

    }
    #endregion
}