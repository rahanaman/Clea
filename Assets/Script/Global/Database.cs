using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum TriggerID //data, ȿ�� �������� ��ġ �˻縦 �� �� ����ϴ� ID
{
    None,
    MouseOver,
    MouseExit,
    ObjUse,
    TurnEnd,
    Attack, // ������ �Ͼ�� ��� (nȸ ���ݽ� nȸ �ҷ���)
    Defense,
    DirectAttack, // ���� ü�±��� �������� �������� ���
    ����,
    Heal
}
public enum CardeRarityID
{
    �߽�,
    ����,
    ����,
    ����
}

public enum CardTypeID
{
    ����,
    �Ŀ�
}
 

public enum CharID
{
    ������,
    ��ų��,
    ��Ƴ�
}
public enum CardID
{
    �˹�
}

public enum EffectID
{
    //�տ���
    //������
}
public enum SoundID
{
    MainSceneBgm,
    ApolloSelection,
    ScyllaSelection,
    DianaSelection,
    UISound1
}

public enum TargetID
{
    None,
    Enemy
}
public enum StateID
{
    Selection,
    Battle,
    Store
}
public enum CardStateID
{
    CardPanel,
    HandCard,
    Store,
    PrizeCard
}

public enum ArtifactID
{
    ������_����,
    ��ų��_����,
    ��Ƴ�_����
}


public static class Database
{
    public static List<PlayerInitData> PlayerInitData = new List<PlayerInitData>();
    public static Sprite[] StartSceneBackgroundCG = new Sprite[] { };
    public static Sprite[] CardIcon = new Sprite[] { };
    public static Sprite[] EnemySprite = new Sprite[] { };
    public static Sprite[] CharSprite = new Sprite[] { };
    public static Dictionary<CardID, CardBase> CardDataDict = new Dictionary<CardID, CardBase>();
    public static Dictionary<EffectID, EffectBase> EffectDataDict = new Dictionary<EffectID,EffectBase>();


}


public class PlayerInitData // ���ο� ������ ������ �� �ʱ�ȭ�ؾ��ϴ� �������� ����
{
    public int PlayerHP;
    public List<int> PlayerDeck;
    public ArtifactID ArtifactID;
    public PlayerInitData(int PlayerHP, List<int> PlayerDeck, ArtifactID artifactID)
    {

    }
}

public class EnemyInitData
{

}


public interface ICopy<T>
{
    T Copy();
}

public interface IEventEditor
{
    void AddEvent(TriggerID id);
    void RemoveEvent(TriggerID id);
}

public interface ITriggerEventEditor
{
    void AddTriggerEvent(VoidEvent trigger);
    void RemoveTriggerEvent(VoidEvent trigger);
}

public interface ITrigger
{
    public int Execute(int data);
}


public class DataInt
{

    private int _������ = 0;            // �⺻ ������.
    private List<float> _�⺻���;
    private List<int> _������;
    private List<float> _���;
    private List<int> _�߰���;

    public float �⺻��� { get; private set; }
    public int ������ { get; private set; }
    public float ��� { get; private set; }
    public int �߰��� { get; private set; }
    public int ������ { get; private set; }

    public DataInt(int �ʱⵥ���� = 0)
    {
        ��ġ�ʱ�ȭ(�ʱⵥ����);
    }
    public int Add�⺻���(float value)
    {
        int index = _�⺻���.Count;
        _�⺻���.Insert(index, value);
        Calc�⺻���();
        Calc������();
        return index;
    }
    public int Add������(int value)
    {
        int index = _������.Count;
        _������.Insert(index, value);
        Calc������();
        Calc������();
        return index;
    }
    public int Add���(float value)
    {
        int index = _���.Count;
        _���.Insert(index, value);
        Calc���();
        Calc������();
        return index;
    }
    public int Add�߰���(int value)
    {
        int index = _�߰���.Count;
        _�߰���.Insert(index, value);
        Calc�߰���();
        Calc������();
        return index;
    }
    public void Remove�⺻���(int index)
    {
        if (0 <= index && index < _�⺻���.Count)
        {
            _�⺻���.RemoveAt(index);
        }
        Calc�⺻���();
        Calc������();
    }
    public void Remove������(int index)
    {
        if (0 <= index && index < _������.Count)
        {
            _������.RemoveAt(index);
        }
        Calc������();
        Calc������();
    }
    public void Remove���(int index)
    {
        if (0 <= index && index < _���.Count)
        {
            _���.RemoveAt(index);
        }
        Calc���();
        Calc������();
    }
    public void Remove�߰���(int index)
    {
        if (0 <= index && index < _�߰���.Count)
        {
            _�߰���.RemoveAt(index);
        }
        Calc�߰���();
        Calc������();
    }
    private void Calc�⺻���()
    {
        �⺻��� = 1f;
        foreach (float value in _�⺻���)
        {
            if (value >= 1f)
            {
                �⺻��� += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                �⺻��� -= 1f - value;
            }
        }
        if (�⺻��� < 0) �⺻��� = 0;
    }
    private void Calc������()
    {
        ������ = 0;
        foreach (int value in _������)
        {
            ������ += value;
        }
    }
    private void Calc���()
    {
        ��� = 1f;
        foreach (float value in _���)
        {
            if (value >= 1f)
            {
                ��� += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                ��� -= 1f - value;
            }
        }
        if (��� < 0) ��� = 0;
    }
    private void Calc�߰���()
    {
        �߰��� = 0;
        foreach (int value in _�߰���)
        {
            �߰��� += value;
        }
    }
    private void Calc������()
    {
        ������ = Mathf.FloorToInt((_������ * �⺻��� + ������) * ��� + �߰���);
    }
    public void ��ġ�ʱ�ȭ(int ������)
    {
        _������ = ������;
        _�⺻��� = new List<float>();
        _������ = new List<int>();
        _��� = new List<float>();
        _�߰��� = new List<int>();
        �⺻��� = 1f;
        ������ = 0;
        ��� = 1f;
        �߰��� = 0;
        Calc������();
    }
}

public class DataFloat
{

    private float _������ = 0;            // �⺻ ������.
    private List<float> _�⺻���;
    private List<float> _������;
    private List<float> _���;
    private List<float> _�߰���;

    public float �⺻��� { get; private set; }
    public float ������ { get; private set; }
    public float ��� { get; private set; }
    public float �߰��� { get; private set; }
    public float ������ { get; private set; }

    public DataFloat(float �ʱⵥ���� = 0)
    {
        ��ġ�ʱ�ȭ(�ʱⵥ����);
    }
    public int Add�⺻���(float value)
    {
        int index = _�⺻���.Count;
        _�⺻���.Insert(index, value);
        Calc�⺻���();
        Calc������();
        return index;
    }
    public int Add������(float value)
    {
        int index = _������.Count;
        _������.Insert(index, value);
        Calc������();
        Calc������();
        return index;
    }
    public int Add���(float value)
    {
        int index = _���.Count;
        _���.Insert(index, value);
        Calc���();
        Calc������();
        return index;
    }
    public int Add�߰���(float value)
    {
        int index = _�߰���.Count;
        _�߰���.Insert(index, value);
        Calc�߰���();
        Calc������();
        return index;
    }
    public void Remove�⺻���(int index)
    {
        if (0 <= index && index < _�⺻���.Count)
        {
            _�⺻���.RemoveAt(index);
        }
        Calc�⺻���();
        Calc������();
    }
    public void Remove������(int index)
    {
        if (0 <= index && index < _������.Count)
        {
            _������.RemoveAt(index);
        }
        Calc������();
        Calc������();
    }
    public void Remove���(int index)
    {
        if (0 <= index && index < _���.Count)
        {
            _���.RemoveAt(index);
        }
        Calc���();
        Calc������();
    }
    public void Remove�߰���(int index)
    {
        if (0 <= index && index < _�߰���.Count)
        {
            _�߰���.RemoveAt(index);
        }
        Calc�߰���();
        Calc������();
    }
    private void Calc�⺻���()
    {
        �⺻��� = 1f;
        foreach (float value in _�⺻���)
        {
            if (value >= 1f)
            {
                �⺻��� += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                �⺻��� -= 1f - value;
            }
        }
        if (�⺻��� < 0) �⺻��� = 0;
    }
    private void Calc������()
    {
        ������ = 0;
        foreach (float value in _������)
        {
            ������ += value;
        }
    }
    private void Calc���()
    {
        ��� = 1f;
        foreach (float value in _���)
        {
            if (value >= 1f)
            {
                ��� += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                ��� -= 1f - value;
            }
        }
        if (��� < 0) ��� = 0;
    }
    private void Calc�߰���()
    {
        �߰��� = 0;
        foreach (float value in _�߰���)
        {
            �߰��� += value;
        }
    }
    private void Calc������()
    {
        ������ = (_������ * �⺻��� + ������) * ��� + �߰���;
    }
    public void ��ġ�ʱ�ȭ(float ������)
    {
        _������ = ������;
        _�⺻��� = new List<float>();
        _������ = new List<float>();
        _��� = new List<float>();
        _�߰��� = new List<float>();
        �⺻��� = 1f;
        ������ = 0;
        ��� = 1f;
        �߰��� = 0;
        Calc������();
    }
}