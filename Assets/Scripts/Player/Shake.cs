using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Single _shakeDuration;
    private Single _shakeAmound;
    private Single _decreaseFactor;
    private Single _shakeFrequency;
    private Single _shakeDecreaseRate;

    private Vector3 _originalPosition;

    private void Start()
    {
        _shakeDuration = 0.15f;
        _shakeAmound = 0.07f;
        _decreaseFactor = 1.0f;
        _shakeFrequency = 10.0f;
        _shakeDecreaseRate = 0.8f;

        if(transform.localPosition != Vector3.zero)
        {
            _originalPosition = transform.localPosition;
        }
    }

    public void JumpShake()
    {
        if (_shakeDuration > 0)
        {
            transform.localPosition = _originalPosition + MyRandom.GetRandomUnitSphere() * _shakeAmound;
            _shakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            _shakeDuration = 0f;
            transform.localPosition = _originalPosition;
        }
    }

    public void TriggerWalkShake(Single itensity, Single duration)
    {
        _originalPosition = transform.localPosition;

        _shakeDuration = duration;
        _shakeAmound = itensity;

        _decreaseFactor = 1.0f;

        if(_shakeDuration > 0)
        {
            Single offset = Mathf.Sin(Time.time * _shakeFrequency) * _shakeAmound;
            transform.localPosition = _originalPosition + new Vector3(0, offset, 0);
            _shakeDuration -= Time.deltaTime * _decreaseFactor;
            _decreaseFactor *= _shakeDecreaseRate;
        }
    }

}
