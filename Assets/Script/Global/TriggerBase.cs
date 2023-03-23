using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : ITrigger, ITriggerEventEditor
{
    public TriggerID InTrigger; // �ش� Ʈ���Ű� �ߵ��Ǹ� Execute ����
    public TriggerID OutTrigger; // Execute�Ŀ� �ߵ��� Ʈ����
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

//���� : (inƮ����)Trigger(outƮ����)


