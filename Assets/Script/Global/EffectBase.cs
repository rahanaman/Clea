using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Event;
using System;
using Trigger;

public class EffectBase
{
    public EffectID Id;
    //public int Index;
    public int Stack = 0;
    protected bool _isStack;
    public List<TriggerBase> TriggerList = new List<TriggerBase>();

    public EffectBase(EffectID id)
    {
        Id = id;
        PlusStack();
    }
     

    public void PlusStack(int num = 1)
    {
        Stack += num;
    }

    public void MinusStack(int num = 1)
    {
        Stack -= num;
    }

}





public class ��ȭ : EffectBase
{
    
    public ��ȭ(EffectID id) : base(id)
    {
        _isStack = true;
    }
    


}

public class �� : EffectBase
{
    public ��(EffectID id) : base(id)
    {

    }
}

