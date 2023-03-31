using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event.����;
using Data;

public abstract class CreatureController : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected List<DataCon<EffectID>> _effectList;

    
    protected int _��;

    public List<DataInt> �޴�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �޴� ������int
    public List<DataInt> �ִ�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �ִ� ������int

    protected virtual void Init()
    {
       _�� = 0;
        _effectList = new List<DataCon<EffectID>>();
        �޴�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �޴� ������int
        �ִ�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �ִ� ������int
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

    public int GetStack(EffectID id) // stack ��ġ�� ���� ȿ���� ���ϴ� ��� EFfectBase���� ȣ����.
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

    //������ ��� ���� : �ִ� DataInt ���� ���� -> �޴� Dataint ���� ���
    public int Calc�޴�Data(DataID id, int damage)
    {
        �޴�Data[(int)id].��ġ�ʱ�ȭ(damage);
        return �޴�Data[(int)id].������;
    }

    public int Calc�ִ�Data(DataID id, int damage)
    {
        int dataInt;
        �ִ�Data[(int)id].��ġ�ʱ�ȭ(damage);
        dataInt = �ִ�Data[(int)id].������;
        return dataInt;
    }
    
    public void Get����(int damage)//Get����(Calc�ִµ�����) ������ ���� ������
    {
        int calcDamage = Calc�޴�Data(DataID.����,damage);
        //Check��()
    }

    public abstract void AddEvent(TriggerID id, TriggerEvent action);
    public abstract void RemoveEvent(TriggerID id, TriggerEvent action);

    

}



