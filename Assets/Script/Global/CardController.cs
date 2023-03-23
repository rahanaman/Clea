using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject _efx;
    private CardID _id;
    private Vector3 _pos;
    private Quaternion _rot;
    private int _index;
    [SerializeField] private CardView _view;
    public CardBase Card; // ���⿡�� ���� ���� ������ �̷������ �ٽ� ������ ����

    public void InitCard(CardID id)
    {
        _id = id;
        Card = Database.CardDataDict[id].Copy();
    }
    public void SetPos(Vector3 pos, Quaternion rot, int index)
    {
        _pos = pos;
        _rot = rot;
        _index = index;
    }

    

}


public class BattleCardController: CardController
{
    private void OnMouseEnter()
    {
        
    }
    private void OnMouseDown()
    {
        
    }
    private void OnMouseExit()
    {
        
    }

}

public class PanelCardController : CardController
{

}

public class StoreCardController : CardController
{

}

public class PrizeCardController : CardController
{

}