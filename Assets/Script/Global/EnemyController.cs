using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event.전투;
using System;

public class EnemyController : CreatureController
{

    protected int _index;
    protected override void Init()
    {
        _index = AddEnemy();
    }
    private void OnDestroy()
    {
        RemoveEnemy();
    }
    private void RemoveEnemy()
    {
        전투EventManager.RemoveEnemy(_index);
    }
    private int AddEnemy()
    {
        int index;
        index = 전투EventManager.AddEnemy();
        return index;
    }

    public override void AddEvent(TriggerID id, TriggerEvent action)
    {
        전투EventManager.AddEnemyTrigger(_index, id, action);
    }

    public override void RemoveEvent(TriggerID id, TriggerEvent action)
    {
        전투EventManager.RemoveEnemyTrigger(_index, id, action);
    }

    

    

}


