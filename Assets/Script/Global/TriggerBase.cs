using System;

namespace Trigger
{
    public class TriggerBase
    {
        public int Index;
        public TriggerID InTrigger; // 해당 트리거가 발동되면 Execute 실행
        public TriggerID OutTrigger; // Execute후에 발동할 트리거
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


    //명명법 : (효과/카드/유물)_(DataID)Trigger
}



