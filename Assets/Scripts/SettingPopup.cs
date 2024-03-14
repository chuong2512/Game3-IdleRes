using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;

    [SerializeField] private Image musicOn, mucsicOff;

    [SerializeField] private Image soundOn, soundOff;

    [SerializeField] private Sprite onImage;

    public void MusicChange(bool value)
    {
        this.musicOn.sprite = value ? onImage : null;
        this.mucsicOff.sprite = value ? null : onImage;
    }

    public void SoundChange(bool value)
    {
        this.soundOn.sprite = value ? onImage : null;
        this.soundOff.sprite = value ? null : onImage;
    }

    public void Show(bool value)
    {
        if (value)
        {
            Singleton<SoundManager>.Instance.Play("Popup");
        }

        this.popup.SetActive(value);
    }
}