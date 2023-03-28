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
    //public CardBase Card; // 여기에서 전투 단위 수정이 이루어지고 다시 삭제될 예정

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


public class 전투CardController: CardController
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

public class 패널CardController : CardController
{

}

public class 상점CardController : CardController
{

}

public class 보상CardController : CardController
{

}