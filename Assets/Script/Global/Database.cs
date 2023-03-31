using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum CharID
{
    ������,
    ��ų��,
    ��Ƴ�
}
public enum CardID
{
    �˹�,
    ���¿��,
    ȭ���罽,
    ���,
    Ÿ��,
    ����,
}

public enum EffectID
{

}
public enum TriggerID //data, ȿ�� �������� ��ġ �˻縦 �� �� ����ϴ� ID //���� ���÷� �� ����� ������
{
    None, // �ߵ��Ǽ� ���� ������ ����ϴ� �ֵ�
    ObjUse,
    ������,
    Attack, // ������ �Ͼ�� ��� (nȸ ���ݽ� nȸ �ҷ���)
    Defense,
    DirectAttack, // ���� ü�±��� �������� �������� ���
    ����,
    Heal
}

public enum DataID
{
    ����,
    ���,
    ��,
    ����,
    ��ȯ
    
}

public enum Card���ID
{
    �߽�,
    ����,
    ����,
    ����
}

public enum Card����ID
{
    ����,
    �Ŀ�
}

public enum SoundID
{
    MainSceneBgm,
    ������_����,
    ��ų��_����,
    ��Ƴ�_����,
    UISound1
}

public enum TargetID
{
    None,
    Enemy
}
public enum StateID
{
    ����,
    ����,
    ����,
    ����
}
public enum CardStateID
{
    ����,
    �г�,
    ����,
    ����
}

public enum ����ID
{
    ������_����,
    ��ų��_����,
    ��Ƴ�_����
}

public enum PanelID
{
    ĳ���ͼ���,
    ����
}
public class DataCon<T> // ���� ���� ������ - ID�� ���� ID�� �´� DataInt ȣ��, ���� data ���
{
    public DataCon(T id, int data)
    {
        Data = data;
        Id = id;
    }
    public T Id;
    public int Data { get; private set; }

    public void AddData(int data)
    {
        Data += data;
    }
    
}

namespace Data // C ����
{
    public static class Database
    {
        public static Sprite[] StartSceneBackgroundCG = new Sprite[] { };
        public static Sprite[] CardIcon = new Sprite[] { };
        public static Sprite[] EnemySprite = new Sprite[] { };
        public static Sprite[] CharSprite = new Sprite[] { }; // ����� �׸� ������ ��
        public static Dictionary<CardID, CardBase> CardDataDict = new Dictionary<CardID, CardBase>(); // ��� ������ ���⿡�� �Ͼ�� '~`
        public static Dictionary<EffectID, EffectBase> EffectDataDict = new Dictionary<EffectID, EffectBase>();// ��� ������ ���⿡�� �Ͼ�� '~`
        public static PanelBase[] Panel = new PanelBase[] { };
        //public static Dictionary<����ID, ����Base>
    }

    public class DataInt
    {

        private int _������
        { get
            {
                if (_is��������)
                {
                    return _����������;
                }
                else
                {
                    return _�⺻������;
                }
            }

        }
        private int _�⺻������=0;
        private int _����������=0;
        private List<float> _�⺻���;
        private List<int> _������;
        private List<float> _���;
        private List<int> _�߰���;
        private bool _is��������;

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
                _�⺻���[index] = 1.0f;
            }
            Calc�⺻���();
            Calc������();
        }
        public void Remove������(int index)
        {
            if (0 <= index && index < _������.Count)
            {
                _������[index] = 0;
            }
            Calc������();
            Calc������();
        }
        public void Remove���(int index) // remove�� �ٲ����
        {
            if (0 <= index && index < _���.Count)
            {
                _���[index] = 1.0f;
            }
            Calc���();
            Calc������();
        }
        public void Remove�߰���(int index)
        {
            if (0 <= index && index < _�߰���.Count)
            {
                _�߰���[index] = 0;
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

        public void Set��������(int min, int max) //min �̻� max �̸�
        {
            _is�������� = true;
            _���������� = UnityEngine.Random.Range(min, max);
            Calc������();

        }

        public void Remove��������()
        {
            if (_is�������� == true)
            {
                _is�������� = false;
                Calc������();
            }
        }
        public void ��ġ�ʱ�ȭ(int ������)
        {
            _�⺻������ = ������;
            _is�������� = false;
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
        private float _temp������ = 0;
        private List<float> _�⺻���;
        private List<float> _������;
        private List<float> _���;
        private List<float> _�߰���;
        private bool _is�������� = false;
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

        public void Set��������(float min, float max) //min �̻� max ����
        {
            if (_is�������� == false)
            {
                _temp������ = _������;
                _is�������� = true;
            }
            _������ = UnityEngine.Random.Range(min, max);
            Calc������();

        }

        public void Remove��������()
        {
            if (_is�������� == true)
            {
                _������ = _temp������;
                _is�������� = false;
                Calc������();
            }
        }

        public void ��ġ�ʱ�ȭ(float ������)
        {
            _������ = ������;
            _�⺻��� = new List<float>();
            _������ = new List<float>();
            _��� = new List<float>();
            _�߰��� = new List<float>();
            _is�������� = false;
            �⺻��� = 1f;
            ������ = 0;
            ��� = 1f;
            �߰��� = 0;
            Calc������();
        }
    } // �ʿ��ϸ� ���µ� �ϴ� �� �� ��

    


}




public abstract class PanelBase : MonoBehaviour
{

}




