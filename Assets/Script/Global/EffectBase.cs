using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase
{
    public EffectID Id;
    public EffectBase(EffectID id)
    {
        Id = id;
    }
    protected List<TriggerBase> _trigger;

    public void AddEvent(List<VoidEvent> trigger)
    {
        for (int i = 0; i < _trigger.Count; i++)
        {
            _trigger[i].AddTriggerEvent(trigger[(int)_trigger[i].InTrigger]);
        }
    }

    public void RemoveEvent(List<VoidEvent> trigger)
    {
        for (int i = 0; i < _trigger.Count; i++)
        {
            _trigger[i].RemoveTriggerEvent(trigger[(int)_trigger[i].InTrigger]);
        }
    }


}

public class 연소 : EffectBase
{

    public 연소(EffectID id) : base(id)
    {
        Init();
    }

    public void Init()
    {
        _trigger = new List<TriggerBase>();
        //_trigger.Add();
    }
}

