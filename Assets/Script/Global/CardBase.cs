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
    const string KEY_등급 = "등급";
    const string KEY_분류 = "분류";
    const string KEY_대상 = "대상";
    const string KEY_DESCRIPTION = "Description";
    const string KEY_DATA = "Data";



    public CardID Id;
    public string Name;
    public int Cost;
    public Card등급ID 등급ID;
    public Card종류ID 종류ID;
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
        등급ID = (Card등급ID)Enum.Parse(typeof(Card등급ID),data[KEY_등급].ToString());
        종류ID = (Card종류ID)Enum.Parse(typeof(Card종류ID),data[KEY_분류].ToString());
        TargetID = (TargetID)Enum.Parse(typeof(TargetID),data[KEY_대상].ToString());
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

    public virtual string GetCardDesc() // parse하라 - 네.
    {
        string desc = Desc;
        return desc;
    }

    public abstract void Use(CreatureController c);
    public abstract void Calc(EnemyController c); // 적관련 계산?

    public abstract void CalcPlayer(PlayerController c);

    

    

}

public class 검무 : CardBase
{
    public 검무(CardID id) : base(id)
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
        // Cal(); 한 데이터를 먼저 전달받음
        //Regex.replace로 파싱
        return desc;
    }

    public override void Use(CreatureController c)
    {
        throw new NotImplementedException();
    }
}
