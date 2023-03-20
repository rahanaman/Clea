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
    public CardBase _card; // 여기에서 전투 단위 수정이 이루어지고 다시 삭제될 예정

    public void InitCard(CardID id)
    {
        _id = id;
        _card = Database.CardDataDict[id].Copy();
    }
    public void SetPos(Vector3 pos, Quaternion rot, int index)
    {
        _pos = pos;
        _rot = rot;
        _index = index;
    }

    private void OnMouseEnter()
    {
        //MouseOverCard();
    }

    private void OnMouseDown()
    {
        //ClickObj(_card);
    }

}
