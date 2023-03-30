using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event.전투;
using Data;

public class CreatureController : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected List<DataCon<EffectID>> _effectList;

    public int Index { get; protected set; }

    protected int _방어도;

    public List<DataInt> 받는Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // 받는 데이터int
    public List<DataInt> 주는Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // 주는 데이터int

    protected virtual void Init()
    {
       _방어도 = 0;
        _effectList = new List<DataCon<EffectID>>();
        받는Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // 받는 데이터int
        주는Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // 주는 데이터int
    }

     
    /*
    public void AddEffect(EffectID id, int stack = 1)
    {
        int index = CheckEffectList(id);
        if(index == -1)
        {
            _effectList.Add(new EffectBase(id));

        }
        else
        {
            _effectList[index].PlusStack(stack);
        }
    }

    protected int CheckEffectList(EffectID id)
    {
        int n = _effectList.Count;
        for (int i = 0; i < n; i++)
        {
            if(_effectList[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }
    */

    //데이터 계산 순서 : 주는 DataInt 먼저 적용 -> 받는 Dataint 최종 계산
    public int Calc받는Data(DataID id, int damage)
    {
        받는Data[(int)id].수치초기화(damage);
        return 받는Data[(int)id].데이터;
    }

    public int Calc주는Data(DataID id, int damage)
    {
        int dataInt;
        주는Data[(int)id].수치초기화(damage);
        dataInt = 주는Data[(int)id].데이터;
        return dataInt;
    }
    
    public void Get공격(int damage)//Get공격(Calc주는데이터) 까지만 계산된 데미지
    {
        int calcDamage = Calc받는Data(DataID.공격,damage);
        //Check방어도()
    }

    

}


public class PlayerController : CreatureController
{
    

    protected override void Init()
    {
        Index = -1;
    }
}

public class EnemyController : CreatureController
{

    protected override void Init()
    {
        Index = AddEvent();
    }


    private int AddEvent()
    {
        int index;
        index = 전투EventManager.AddEnemyTrigger();
        return index;
    }

    private void OnDestroy()
    {
        RemoveEvent();
    }
    private void RemoveEvent()
    {
        전투EventManager.RemoveEnemyTrigger(Index);
    }
    
}
