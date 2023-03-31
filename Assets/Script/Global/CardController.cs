using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject _efx;

    private ICardHandler _handler;
    public CardID Id { get; private set;}
    protected Vector3 _pos;
    protected Quaternion _rot;
    protected int _index;
    [SerializeField] private CardView _view;
    public int Cost { get { return _cost.데이터; } private set { _cost.수치초기화(value); } }
    private DataInt _cost = new DataInt();
    //public CardBase Card; // 여기에서 전투 단위 수정이 이루어지고 다시 삭제될 예정

    public void InitCard(CardID id, CardStateID state)
    {
        Id = id;
        switch (state)
        {
            case CardStateID.전투:
                _handler = new 전투CardHandler(); //해도됨?
                break;
            case CardStateID.보상:
                _handler = new 보상CardHandler();
                break;
            case CardStateID.상점:
                _handler = new 상점CardHandler();
                break;
            case CardStateID.패널:
                _handler = new 패널CardHandler();
                break;

        }
    }
    public void SetPos(Vector3 pos, Quaternion rot, int index)
    {
        _pos = pos;
        _rot = rot;
        _index = index;
    }
    private void OnMouseEnter()
    {
        _handler.MouseEnter();
    }
    private void OnMouseDown()
    {
        _handler.MouseDown();
    }
    private void OnMouseExit()
    {
        _handler.MouseExit();
    }
    

}


public interface ICardHandler
{
    void MouseEnter();
    void MouseDown();
    void MouseExit();
}

public class 전투CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}

public class 보상CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 패널CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 상점CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
