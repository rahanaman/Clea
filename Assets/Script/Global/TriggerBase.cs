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

    public class Ÿ��_����Trigger : TriggerBase
    {
        public Ÿ��_����Trigger(TriggerID inID, TriggerID outID) : base(inID, outID)
        {

        }

        public override void Execute(EnemyController target, params int[] data)
        {
            //target.GetDamage(data[0]); // �ϴ� ����
        }
    }


    //���� : (ȿ��/ī��/����)(Ʈ���� ����)Trigger
}



