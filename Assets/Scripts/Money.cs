using System;
using UnityEngine;

public sealed class Money : MonoBehaviour
{
    private static Single _moneyCount;
    private Single _rotateSpeed;

    private void Start()
    {
        _moneyCount = 0;
        _rotateSpeed = 150;
    }

    private void Update()
    {
        MoneyRotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Money");
        _moneyCount++;
        Destroy(gameObject);
    }

    private void MoneyRotate()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y += _rotateSpeed * Time.deltaTime;
        transform.eulerAngles = eulerAngles;
    }

    public Single MoneyCount {
        get { return _moneyCount; } 
    }

}
