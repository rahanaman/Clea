using System;

namespace Trigger
{
    public class TriggerBase
    {
        public int Index;
        public TriggerID InTrigger; // �ش� Ʈ���Ű� �ߵ��Ǹ� Execute ����
        public TriggerID OutTrigger; // Execute�Ŀ� �ߵ��� Ʈ����
        public TriggerBase(TriggerID inID, TriggerID outID)
        {
            this.InTrigger = inID;
            this.OutTrigger = outID;
        }

        public virtual void Execute(CreatureController[] target, int[]  data)
        {
            
        }


    }
    public interface ITriggerEventEditor
    {
        void AddTriggerEvent(Action trigger);
        void RemoveTriggerEvent(Action trigger);
    }


    //���� : (ȿ��/ī��/����)_(DataID)Trigger
}



