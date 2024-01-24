using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private Money _money;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Start()
    {
        _money = new();
    }

    void Update()
    {
        _moneyText.text = _money.MoneyCount.ToString();
    }
}
