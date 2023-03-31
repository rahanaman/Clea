using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event.전투;
using Data;

public abstract class CreatureController : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected List<DataCon<EffectID>> _effectList;

    
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

     public void AddEffect(EffectID id, int stack =1)
    {
        int index = CheckEffect(id);
        if(index == -1)
        {
            _effectList.Add(new DataCon<EffectID>(id, stack));
            Database.EffectDataDict[id].AddEvent(this as CreatureController);

        }
    }

    private int CheckEffect(EffectID id)
    {
        int num = _effectList.Count;
        for(int i = 0; i < num; i++)
        {
            if(_effectList[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetStack(EffectID id) // stack 수치에 따라 효과가 변하는 경우 EFfectBase에서 호출함.
    {
        int num = _effectList.Count;
        for(int i = 0; i < num; i++)
        {
            if (_effectList[i].Id == id)
            {
                return _effectList[i].Data;
            }
        }
        return -1;
    }

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

    public abstract void AddEvent(TriggerID id, TriggerEvent action);
    public abstract void RemoveEvent(TriggerID id, TriggerEvent action);

    

}



