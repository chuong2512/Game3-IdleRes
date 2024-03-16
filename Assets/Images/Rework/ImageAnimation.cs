using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private int _animIndex = 0;
    [SerializeField] private ImageAnim[] anims;


    [SerializeField] private float _frameRate = 0.1f;

    private float _counter = 0;
    private int _index = 0;

    private void OnValidate()
    {
        _image = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        _counter += Time.fixedDeltaTime;

        if (_counter < _frameRate)
            return;

        ChangeImage();
        _counter = 0;
    }

    public void ChangeAnim(int index)
    {
        _animIndex = index;
        _index = 0;
        ChangeImage();
    }

    private void ChangeImage()
    {
        _index++;
        if (_index >= anims[_animIndex].sprites.Length)
        {
            _index = 0;
        }

        _image.sprite = anims[_animIndex].sprites[_index];
    }
}

[Serializable]
public class ImageAnim
{
    [SerializeField] public Sprite[] sprites;
}