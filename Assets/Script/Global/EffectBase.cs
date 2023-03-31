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





public class ��ȭ : EffectBase
{
    
    public ��ȭ(EffectID id) : base(id)
    {
        _isStack = true;
    }
    public override void AddEvent(CreatureController creature)
    {
        creature.�޴�Data[(int)DataID.����].Add���(0.5f);
    }

    public override void RemoveEvent(CreatureController creature)
    {
        throw new NotImplementedException();
    }




}

public class �� : EffectBase
{
    int _�������� = 1;
    public ��(EffectID id) : base(id)
    {

    }

    public override void AddEvent(CreatureController creature)
    {
        creature.AddEvent(TriggerID.������, ��Execute);
    }

    public override void RemoveEvent(CreatureController creature)
    {
        throw new NotImplementedException();
    }

    private void ��Execute(CreatureController creature)
    {
        creature.Get����(_��������);
    }
}

