using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private Money _money;

    private void Start()
    {
        _money = new();
    }

    void Update()
    {
        Debug.Log("Money: " + _money.MoneyCount);
    }
}
