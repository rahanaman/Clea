using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event.����;
using Data;

public class CreatureController : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected List<DataCon<EffectID>> _effectList;

    public int Index { get; protected set; }

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
        index = ����EventManager.AddEnemyTrigger();
        return index;
    }

    private void OnDestroy()
    {
        RemoveEvent();
    }
    private void RemoveEvent()
    {
        ����EventManager.RemoveEnemyTrigger(Index);
    }
    
}
