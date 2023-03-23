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
        //��ȣ�� ������ ī���� ������ �߿� �����Ǿ�� �ϴ� ���̵� Ž��, �����ؼ� ����
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

public class �˹� : CardBase
{
    public �˹�(CardID id) : base(id)
    {

    }  

    public override string GetCardDesc()
    {
        string desc = base.GetCardDesc();
        // Cal(); �� �����͸� ���� ���޹���
        //Regex.replace�� �Ľ�
        return desc;
    }
    public override void Use(params CreatureController[] target)
    {
        
    }

    public override void Cal()
    {
        
    }


}


public class ���� : CardBase
{
    public ����(CardID id) : base(id)
    {

    }

    public override string GetCardDesc()
    {
        string desc = base.GetCardDesc();
        // Cal(); �� �����͸� ���� ���޹���
        //Regex.replace�� �Ľ�
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