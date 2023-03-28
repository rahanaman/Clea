using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event.����;
using Data;

public class CreatureController : MonoBehaviour
{

    protected List<EffectBase> _effectList;

    public List<DataInt> �޴�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �޴� ������int
    public List<DataInt> �ִ�Data = new List<DataInt>(Enum.GetValues(typeof(DataID)).Length); // �ִ� ������int

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

    private int CheckEffectList(EffectID id)
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

    //������ ��� ���� : �ִ� DataInt ���� ���� -> �޴� Dataint ���� ���
    public int Calc�޴�Data(DataID id, int damage)
    {
        �޴�Data[(int)id].��ġ�ʱ�ȭ(damage);
        return �޴�Data[(int)DataID.����].������;
    }

    public int Calc�ִ�Data(DataID id, int damage)
    {
        int dataInt;
        �ִ�Data[(int)DataID.����].��ġ�ʱ�ȭ(damage);
        dataInt = �ִ�Data[(int)DataID.����].������;
        return dataInt;
    }

    public void Get����(int damage)//Get����(Calc�ִµ�����) ������ ���� ������
    {
        int calcDamage = Calc�޴�Data(DataID.����,damage);
    }

}


public class PlayerController : CreatureController
{
    
}

public class EnemyController : CreatureController
{
    private void Awake()
    {
        Index = AddEvent();
    }
    public int Index { get; private set;}

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
