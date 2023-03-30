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

    public EffectBase(EffectID id) : this(id, 1) // 비스택형 효과
    {
        _isStack = false;
    }

    public EffectBase(EffectID id, int stack) //스택형 효과
    {
        Id = id;
        PlusStack(stack);
        _isStack = true;
        
    }

    private void AddEvent(int index)
    {
        if(index == -1)
        {

        }
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





public class 약화 : EffectBase
{
    
    public 약화(EffectID id) : base(id)
    {
        _isStack = true;
    }
    


}

public class 독 : EffectBase
{
    public 독(EffectID id) : base(id)
    {

    }
}

