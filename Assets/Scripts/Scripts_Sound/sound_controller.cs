using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_controller : MonoBehaviour
{
    public bool somStatus = true;

    [SerializeField] private GameObject sound;
    [SerializeField] private AudioSource fundoMusical;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    void Start()
    {
        DontDestroyOnLoad(sound);
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

    public void volumeMusical(float value)
    {
        fundoMusical.volume = value;
    }
}
