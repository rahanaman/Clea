using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System;

public abstract class CardBase
{
    const string KEY_ID = "ID";
    const string KEY_NAME = "Name";
    const string KEY_COST = "Cost";
    const string KEY_��� = "���";
    const string KEY_�з� = "�з�";
    const string KEY_��� = "���";
    const string KEY_DESCRIPTION = "Description";
    const string KEY_DATA = "Data";



    public CardID Id;
    public string Name;
    public int Cost;
    public Card���ID ���ID;
    public Card����ID ����ID;
    public TargetID TargetID;
    public string Desc;

    private DataCon<DataID>[] _dataList;

    
    public CardBase(CardID id)
    {
        Id = id;
    }

    public void SetCard(Dictionary<string, object> data)
    {
        Id = (CardID)int.Parse(data[KEY_ID].ToString());
        Name = data[KEY_NAME].ToString();
        Cost = int.Parse(data[KEY_COST].ToString());
        ���ID = (Card���ID)Enum.Parse(typeof(Card���ID),data[KEY_���].ToString());
        ����ID = (Card����ID)Enum.Parse(typeof(Card����ID),data[KEY_�з�].ToString());
        TargetID = (TargetID)Enum.Parse(typeof(TargetID),data[KEY_���].ToString());
        Desc = data[KEY_DESCRIPTION].ToString();
        SetCardData(data[KEY_DATA].ToString());

    }

    private void SetCardData(string data)
    {
        string[] str = data.Split(',');
        _dataList = new DataCon<DataID>[(str.Length / 2)];
        int index = 0;
        for(int i = 0; i < str.Length; i+=2, index++)
        {
            str[i].Trim();
            str[i+1].Trim();
            _dataList[index] = new DataCon<DataID>((DataID)Enum.Parse(typeof(DataID),str[i + 1]), int.Parse(str[i]));
        }

        
    }

    public virtual string GetCardDesc() // parse�϶� - ��.
    {
        string desc = Desc;
        return desc;
    }

    public abstract void Use(CreatureController c);
    public abstract void Calc(EnemyController c); // ������ ���?

    public abstract void CalcPlayer(PlayerController c);

    

    

}

public class �˹� : CardBase
{
    public �˹�(CardID id) : base(id)
    {

    }

    public override void Calc(EnemyController c)
    {
        throw new NotImplementedException();
    }

    public override void CalcPlayer(PlayerController c)
    {
        throw new NotImplementedException();
    }

    public override string GetCardDesc()
    {
        string desc = base.GetCardDesc();
        // Cal(); �� �����͸� ���� ���޹���
        //Regex.replace�� �Ľ�
        return desc;
    }

    public override void Use(CreatureController c)
    {
        throw new NotImplementedException();
    }
}
