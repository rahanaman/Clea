using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _cardIcon; // �ȹٲ�
    [SerializeField] private TextMeshProUGUI _cardCost; // �ٲ�
    [SerializeField] private TextMeshProUGUI _cardName; // �� �ٲ�
    [SerializeField] private TextMeshProUGUI _cardDesc; // �ٲ�
    
    public void SetCardUI(int cost)
    {
        _cardCost.text = cost.ToString();
    }

    public void SetCardUI(string desc)
    {
        _cardDesc.text = desc;
    }

    public void SetCardUI(string cost = null, string desc = null, string name = null, Sprite sprite=null)
    {
        _cardCost.text = cost;
        _cardDesc.text = desc;
        _cardName.text = name;
        _cardIcon.sprite = sprite;
    }

}
