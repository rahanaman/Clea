using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
// Data ����

public class CreatureBase
{
    public int Maxü��;
    public int ü��;

}

public class PlayerBase : CreatureBase
{
    public CharID Id;
    public List<����ID> ����List { get; private set; }
    public List<CardID> CardList { get; private set; }
    public PlayerBase(CharID id)
    {
        Id = id;
    }
    public void Load(List<string> data)
    {
        // Maxü��, ü��, ����List, CardList �ε�
    }

    public List<string> Save()
    {
        List<string> save = new List<string>();
        // CharID, Maxü��, ü��, ����List, CardList ���̺�
        return save;
    }
    // �ʿ������ ���߿� ����.
}

public class EnemyBase : CreatureBase
{
    // �ʿ������ ���߿� ����.
}

public sealed class ������ : PlayerBase // ���� ĳ���͸��� Ư�� ����� �ִٸ� ���⿡ ���� �����ϰ� �ݹ� ���
{
    public ������(CharID id) : base(id)
    {

    }

}

public class ��ų�� : PlayerBase
{
    public ��ų��(CharID id) : base(id)
    {

    }

}

public class ��Ƴ� : PlayerBase
{
    public ��Ƴ�(CharID id) : base(id)
    {

    }

}
public class ������ : EnemyBase
{
    // �� ��ü�� ���� ���� 
}
