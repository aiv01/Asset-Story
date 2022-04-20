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
        //audioSources[(int)SfxType.TakeTheKey].PlayOneShot(audioClips[(int)SfxType.TakeTheKey]);
        Play(SfxType.TakeTheKey);
    }
    private void PlayNpcInteract() {
        //audioSources[(int)SfxType.NpcInteract].PlayOneShot(audioClips[(int)SfxType.NpcInteract]);
        //audioSources[(int)SfxType.NpcInteract].Play();
        Play(SfxType.NpcInteract);

    }
    private void PlayTurnOffVignette() {
        //audioSources[(int)SfxType.TurnOffVignette].PlayOneShot(audioClips[(int)SfxType.TurnOffVignette]);
        Play(SfxType.TurnOffVignette);

    }
    private void PlayTouchedCheckPoint() {
        //audioSources[(int)SfxType.TouchedCheckPoint].PlayOneShot(audioClips[(int)SfxType.TouchedCheckPoint]);

        Play(SfxType.TouchedCheckPoint);

    }
    private void PlayOpenTheDoor() {
        //audioSources[(int)SfxType.OpenTheDoor].PlayOneShot(audioClips[(int)SfxType.OpenTheDoor]);

        Play(SfxType.OpenTheDoor);

    }
    private void PlayTakeTheHealth() {
        //audioSources[(int)SfxType.TakeTheHealth].PlayOneShot(audioClips[(int)SfxType.TakeTheHealth]);

        Play(SfxType.TakeTheHealth);

    }
    private void PlayTouchedTheSpikes() {
        //audioSources[(int)SfxType.TouchedTheSpikes].PlayOneShot(audioClips[(int)SfxType.TouchedTheSpikes]);

        Play(SfxType.TouchedTheSpikes);

    }
    private void PlayChomperHitted() {
        audioSources[(int)SfxType.ChomperHitted].PlayOneShot(audioClips[(int)SfxType.ChomperHitted]);

        //Play(SfxType.ChomperHitted);

    }
    private void PlaySpitterHitted() {
        audioSources[(int)SfxType.SpitterHitted].PlayOneShot(audioClips[(int)SfxType.SpitterHitted]);

        //Play(SfxType.ChomperDead);

    }
    private void PlayGunnerHitted() {
        audioSources[(int)SfxType.GunnerHitted].volume = 0.3f;
        audioSources[(int)SfxType.GunnerHitted].PlayOneShot(audioClips[(int)SfxType.GunnerHitted]);

        //Play(SfxType.GunnerHitted);

    }
    private void PlayGunnerShoot() {
        //audioSources[(int)SfxType.GunnerShoot].volume = 0.3f;
        audioSources[(int)SfxType.GunnerShoot].PlayOneShot(audioClips[(int)SfxType.GunnerShoot]);

        //Play(SfxType.GunnerShoot);

    }
    private void PlayGunnerWalk() {
        //audioSources[(int)SfxType.GunnerShoot].volume = 0.3f;
        //audioSources[(int)SfxType.GunnerShoot].PlayOneShot(audioClips[(int)SfxType.GunnerShoot]);

        Play(SfxType.GunnerWalk);

    }
    private void PlayGunnerDash() {
        //audioSources[(int)SfxType.GunnerShoot].volume = 0.3f;
        //audioSources[(int)SfxType.GunnerShoot].PlayOneShot(audioClips[(int)SfxType.GunnerShoot]);

        Play(SfxType.GunnerDash);

    }
    private void PlayChomperDead() {
        //audioSources[(int)SfxType.ChomperDead].PlayOneShot(audioClips[(int)SfxType.ChomperDead]);

        Play(SfxType.ChomperDead);

    }
    private void PlaySpitterDead() {
        //audioSources[(int)SfxType.SpitterDead].PlayOneShot(audioClips[(int)SfxType.SpitterDead]);

        Play(SfxType.SpitterDead);

    }
    private void PlayGunnerDead() { 
        Play(SfxType.GunnerDead);

    }
    private void PlayPlayerShoot() {
        audioSources[(int)SfxType.PlayerShoot].PlayOneShot(audioClips[(int)SfxType.PlayerShoot]);

        //Play(SfxType.PlayerShoot);

    }
    private void PlayPlayerHit() {
        //audioSources[(int)SfxType.PlayerHit].PlayOneShot(audioClips[(int)SfxType.PlayerHit]);

        Play(SfxType.PlayerHit);

    }
    private void PlayPlayerWalk() {
        //audioSources[(int)SfxType.PlayerWalk].velocityUpdateMode = AudioVelocityUpdateMode.Fixed;
        //audioSources[(int)SfxType.PlayerWalk].PlayOneShot(audioClips[(int)SfxType.PlayerWalk]);

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