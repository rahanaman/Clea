using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event.����;
using System;
using Data;

public class BattlePanelManager : MonoBehaviour
{
    private List<CardController> _cards = new List<CardController>();
    private List<EnemyController> _enemy = new List<EnemyController>();
    private int _turnNum;
    [SerializeField] CardController _card;

    

    private CardController CreateCard(CardID id)
    {
        CardController card = Instantiate(_card);
        card.InitCard(id, CardStateID.����);
        return card;
    }




}
