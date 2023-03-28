using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject _efx;
    public CardID Id { get; private set;}
    protected Vector3 _pos;
    protected Quaternion _rot;
    protected int _index;
    [SerializeField] private CardView _view;
    //public CardBase Card; // ���⿡�� ���� ���� ������ �̷������ �ٽ� ������ ����

    public void InitCard(CardID id)
    {
        Id = id;
        //Card = Database.CardDataDict[id].Copy();
    }
    public void SetPos(Vector3 pos, Quaternion rot, int index)
    {
        _pos = pos;
        _rot = rot;
        _index = index;
    }

    

}


public class ����CardController: CardController
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

public class �г�CardController : CardController
{

}

public class ����CardController : CardController
{

}

public class ����CardController : CardController
{

}