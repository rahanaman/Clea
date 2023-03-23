using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class CardBase : ICopy<CardBase>
{
    public CardID Id;
    public string Name;
    public int Cost;
    public CardeRarityID RarityID;
    public CardTypeID TypeID;
    public TargetID TargetID;
    public string Desc;
    public int[] Data;
    public TriggerID[] DataTrigger;
    
    
    
    public CardBase(CardID id)
    {
        Id = id;
    }

    public void SetCard(Dictionary<string, object> data)
    {
        
    }

    public virtual string GetCardDesc()
    {
        string desc = Desc;
        return desc;
    }

    public virtual void Use(params CreatureController[] target)
    {

    }
    public virtual void Cal()
    {
        //신호를 받으면 카드의 데이터 중에 수정되어야 하는 아이들 탐색, 수정해서 리턴
    }

    public CardBase Copy()
    {
        CardBase copy = new CardBase(Id);
        copy.Name = Name;
        copy.Cost = Cost;
        copy.Desc = Desc;
        copy.RarityID = RarityID;
        copy.TypeID = TypeID;
        copy.TargetID = TargetID;
        copy.Data = Data.ToArray();
        return copy;
    }

    

}

public class 검무 : CardBase
{
    public 검무(CardID id) : base(id)
    {

    }  

    public override string GetCardDesc()
    {
        string desc = base.GetCardDesc();
        // Cal(); 한 데이터를 먼저 전달받음
        //Regex.replace로 파싱
        return desc;
    }
    public override void Use(params CreatureController[] target)
    {
        
    }

    public override void Cal()
    {
        
    }


}


public class 공격 : CardBase
{
    public 공격(CardID id) : base(id)
    {

    }

    public override string GetCardDesc()
    {
        string desc = base.GetCardDesc();
        // Cal(); 한 데이터를 먼저 전달받음
        //Regex.replace로 파싱
        return desc;
    }
    public override void Use(params CreatureController[] target)
    {
        int data = EventManager.CallOnEnemyTrigger(target[0], TriggerID.Attack, Data[0]);
        target[0].GetDamage(data);
    }

    public override void Cal()
    {

    }


}
/*
    public void SetCard(object name, object cost, object rarity, object type, object target, object desc, object data)
    {
        string SPLIT_RE = ",";
        Name = Name.ToString();
        Cost = int.Parse(cost.ToString());
        RarityID = (CardeRarityID)int.Parse(rarity.ToString());
        TypeID = (CardTypeID)int.Parse(type.ToString());
        Desc = desc.ToString();
        Data = System.Array.ConvertAll((Regex.Split(data.ToString(), SPLIT_RE)), s => int.Parse(s.Trim()));
    }
        */