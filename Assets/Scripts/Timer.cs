using System;
using TMPro;
using UnityEngine;

public sealed class Timer : MonoBehaviour
{
    [SerializeField] private Single _timerCount;
    [SerializeField] private TextMeshProUGUI _timerText;

    void Start()
    {
        _timerText.text = _timerCount.ToString();
    }


    void Update()
    {
        _timerCount -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timerCount).ToString();
    }

    public Single TimerCount
    {
        get { return _timerCount; }
    }
}
