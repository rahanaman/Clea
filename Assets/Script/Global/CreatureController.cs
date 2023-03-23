using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public List<EffectID> Effects = new List<EffectID>();
    public void GetDamage(int dam)
    {

    }
    public virtual void AddEffect(EffectID id)
    {

    }
}


public class PlayerController : CreatureController
{
    public override void AddEffect(EffectID id) // 플레이어에 대한 효과 등록
    {
        Effects.Add(id);
        Database.EffectDataDict[id].AddEvent(EventManager.PlayerTrigger);
    }
}


public class EnemyController : CreatureController
{
    public override void AddEffect(EffectID id) // 각 개체에 대한 효과 등록
    {
        Effects.Add(id);
        Database.EffectDataDict[id].AddEvent(EventManager.EnemyTrigger[this]);
    }
}