using System;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private float FPS;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        FPS = 1 / Time.unscaledDeltaTime;
        _text.text = $"FPS : {FPS}";
    }
}
