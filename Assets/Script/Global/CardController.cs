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
    public int Cost { get { return _cost.������; } private set { _cost.��ġ�ʱ�ȭ(value); } }
    private DataInt _cost = new DataInt();
    //public CardBase Card; // ���⿡�� ���� ���� ������ �̷������ �ٽ� ������ ����

    public void InitCard(CardID id, CardStateID state)
    {
        Id = id;
        switch (state)
        {
            case CardStateID.����:
                _handler = new ����CardHandler(); //�ص���?
                break;
            case CardStateID.����:
                _handler = new ����CardHandler();
                break;
            case CardStateID.����:
                _handler = new ����CardHandler();
                break;
            case CardStateID.�г�:
                _handler = new �г�CardHandler();
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

public class ����CardHandler : ICardHandler
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

public class ����CardHandler : ICardHandler
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
public class �г�CardHandler : ICardHandler
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
public class ����CardHandler : ICardHandler
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
