using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    

    public AudioClip[] BackgroundMusic;
    public AudioClip CoinEffect;
    public AudioClip ObstacleEffect;
    public AudioClip FinishEffect;

    public AudioSource BackGroundSource;
    public AudioSource EffectSource;

    //Singleton
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }

    private void OnEnable()
    {
        EventManager.CoinCollided += PlayCoinEffect;
        EventManager.ObstacleCollided += PlayObstacleEffect;
        EventManager.GameFinished += PlayFinishEffect;
    }

    private void Start()
    {       
        StartCoroutine(PlayBackgrounds());     
    }

    //Effect Methodlarý
    void PlayCoinEffect()
    {
        EffectSource.PlayOneShot(CoinEffect);
    }
    void PlayObstacleEffect()
    {
        EffectSource.PlayOneShot(ObstacleEffect);
    }
    void PlayFinishEffect()
    {
        EffectSource.PlayOneShot(FinishEffect);
    }

    // Müziklerin bulunduðu array bittikçe dönecek
    IEnumerator PlayBackgrounds()
    {
        while (true)
        {
            BackGroundSource.clip = BackgroundMusic[0];
            BackGroundSource.Play();
            yield return new WaitForSeconds(BackgroundMusic[0].length);

            BackGroundSource.clip = BackgroundMusic[1];
            BackGroundSource.Play();
            yield return new WaitForSeconds(BackgroundMusic[1].length);

            BackGroundSource.clip = BackgroundMusic[2];
            BackGroundSource.Play();
            yield return new WaitForSeconds(BackgroundMusic[2].length);

        }

    }

    private void OnDisable()
    {
        EventManager.CoinCollided -= PlayCoinEffect;
        EventManager.ObstacleCollided -= PlayObstacleEffect;
        EventManager.GameFinished -= PlayFinishEffect;
    }

}
