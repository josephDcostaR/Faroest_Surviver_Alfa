using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_controller : MonoBehaviour
{
    private static sound_controller instance;
    public bool somStatus = true;

    [SerializeField] private GameObject sound;
    [SerializeField] private AudioSource fundoMusical;

    [SerializeField] private AudioClip musicaMenu;
    [SerializeField] private AudioClip musicaGame;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    ////

    

     void Awake()
    {
        

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        fundoMusical = sound.GetComponent<AudioSource>();
    }

    public void ligarDesligarSom()
    {
        somStatus = !somStatus;
        fundoMusical.enabled = somStatus;

        if (somStatus)
        {
            muteImage.sprite = somLigadoSprite;
        }
        else
        {
            muteImage.sprite = somDesligadoSprite;
        }
    }

    public void PlayMenuMusic()
    {
        fundoMusical.clip = musicaMenu;
        fundoMusical.Play();
    }

    public void PlayGameMusic()
    {
        fundoMusical.clip = musicaGame;
        fundoMusical.Play();
    }

    public void volumeMusical(float value)
    {
        fundoMusical.volume = value;
    }
}
