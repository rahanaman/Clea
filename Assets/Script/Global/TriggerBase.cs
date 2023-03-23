using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : ITrigger, ITriggerEventEditor
{
    public TriggerID InTrigger; // 해당 트리거가 발동되면 Execute 실행
    public TriggerID OutTrigger; // Execute후에 발동할 트리거
    public TriggerBase(TriggerID inID, TriggerID outID)
    {
        this.InTrigger = inID;
        this.OutTrigger = outID;
    }
    
    public virtual int Execute(int data)
    {
        return data;
    }

    public void AddTriggerEvent(VoidEvent trigger)
    {
        trigger += Execute;
    }

    public void RemoveTriggerEvent(VoidEvent trigger)
    {
        trigger -= Execute;
    }


}

//명명법 : (in트리거)Trigger(out트리거)


