using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardView : MonoBehaviour
{
    [SerializeField] private Image _cardIcon; // ¾È¹Ù²ñ
    [SerializeField] private Text _cardCost; // ¹Ù²ñ
    [SerializeField] private Text _cardName; // ¾È ¹Ù²ñ
    [SerializeField] private Text _cardDesc; // ¹Ù²ñ
    
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
