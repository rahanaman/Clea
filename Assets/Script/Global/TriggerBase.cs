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

        public virtual void Execute(params int[] data)
        {
            
        }

        public virtual void Execute(EnemyController singleTarget, params int[] data)
        {

        }

        public virtual void Execute(EnemyController[] multiTarget, params int[] data)
        {

        }
    }
    public interface ITriggerEventEditor
    {
        void AddTriggerEvent(Action trigger);
        void RemoveTriggerEvent(Action trigger);
    }

    public class 타격_공격Trigger : TriggerBase
    {
        public 타격_공격Trigger(TriggerID inID, TriggerID outID) : base(inID, outID)
        {

        }

        public override void Execute(EnemyController target, params int[] data)
        {
            //target.GetDamage(data[0]); // 일단 예시
        }
    }


    //명명법 : (효과/카드/유물)(트리거 설명)Trigger
}



