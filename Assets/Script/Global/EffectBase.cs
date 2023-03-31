using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Event;
using System;
using Trigger;

public abstract class EffectBase
{
    public EffectID Id;
    protected bool _isStack;
    //public List<TriggerBase> TriggerList = new List<TriggerBase>();

    
    public EffectBase(EffectID id)
    {
        Id = id;
    }




    public abstract void AddEvent(CreatureController creature);
    public abstract void RemoveEvent(CreatureController creature);

    

}





public class 약화 : EffectBase
{
    
    public 약화(EffectID id) : base(id)
    {
        _isStack = true;
    }
    public override void AddEvent(CreatureController creature)
    {
        creature.받는Data[(int)DataID.공격].Add배수(0.5f);
    }

    public override void RemoveEvent(CreatureController creature)
    {
        throw new NotImplementedException();
    }




}

public class 독 : EffectBase
{
    int _독데미지 = 1;
    public 독(EffectID id) : base(id)
    {

    }

    public override void AddEvent(CreatureController creature)
    {
        creature.AddEvent(TriggerID.턴종료, 독Execute);
    }

    public override void RemoveEvent(CreatureController creature)
    {
        throw new NotImplementedException();
    }

    private void 독Execute(CreatureController creature)
    {
        creature.Get공격(_독데미지);
    }
}

