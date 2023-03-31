using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event.����;
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
        ����EventManager.RemoveEnemy(_index);
    }
    private int AddEnemy()
    {
        int index;
        index = ����EventManager.AddEnemy();
        return index;
    }

    public override void AddEvent(TriggerID id, TriggerEvent action)
    {
        ����EventManager.AddEnemyTrigger(_index, id, action);
    }

    public override void RemoveEvent(TriggerID id, TriggerEvent action)
    {
        ����EventManager.RemoveEnemyTrigger(_index, id, action);
    }

    

    

}


