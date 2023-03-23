using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum TriggerID //data, 효과 단위에서 일치 검사를 할 때 사용하는 ID
{
    None,
    MouseOver,
    MouseExit,
    ObjUse,
    TurnEnd,
    Attack, // 공격이 일어나는 경우 (n회 공격시 n회 불러짐)
    Defense,
    DirectAttack, // 실제 체력까지 데미지가 입혀지는 경우
    연소,
    Heal
}
public enum CardeRarityID
{
    견습,
    숙련,
    전문,
    전설
}

public enum CardTypeID
{
    공격,
    파워
}
 

public enum CharID
{
    아폴로,
    스킬라,
    디아나
}
public enum CardID
{
    검무
}

public enum EffectID
{
    //합연산
    //곱연산
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
    아폴로_시작,
    스킬라_시작,
    디아나_시작
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


public class PlayerInitData // 새로운 게임을 시작할 때 초기화해야하는 데이터의 모음
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

    private int _데이터 = 0;            // 기본 데이터.
    private List<float> _기본배수;
    private List<int> _증가량;
    private List<float> _배수;
    private List<int> _추가량;

    public float 기본배수 { get; private set; }
    public int 증가량 { get; private set; }
    public float 배수 { get; private set; }
    public int 추가량 { get; private set; }
    public int 데이터 { get; private set; }

    public DataInt(int 초기데이터 = 0)
    {
        수치초기화(초기데이터);
    }
    public int Add기본배수(float value)
    {
        int index = _기본배수.Count;
        _기본배수.Insert(index, value);
        Calc기본배수();
        Calc데이터();
        return index;
    }
    public int Add증가량(int value)
    {
        int index = _증가량.Count;
        _증가량.Insert(index, value);
        Calc증가량();
        Calc데이터();
        return index;
    }
    public int Add배수(float value)
    {
        int index = _배수.Count;
        _배수.Insert(index, value);
        Calc배수();
        Calc데이터();
        return index;
    }
    public int Add추가량(int value)
    {
        int index = _추가량.Count;
        _추가량.Insert(index, value);
        Calc추가량();
        Calc데이터();
        return index;
    }
    public void Remove기본배수(int index)
    {
        if (0 <= index && index < _기본배수.Count)
        {
            _기본배수.RemoveAt(index);
        }
        Calc기본배수();
        Calc데이터();
    }
    public void Remove증가량(int index)
    {
        if (0 <= index && index < _증가량.Count)
        {
            _증가량.RemoveAt(index);
        }
        Calc증가량();
        Calc데이터();
    }
    public void Remove배수(int index)
    {
        if (0 <= index && index < _배수.Count)
        {
            _배수.RemoveAt(index);
        }
        Calc배수();
        Calc데이터();
    }
    public void Remove추가량(int index)
    {
        if (0 <= index && index < _추가량.Count)
        {
            _추가량.RemoveAt(index);
        }
        Calc추가량();
        Calc데이터();
    }
    private void Calc기본배수()
    {
        기본배수 = 1f;
        foreach (float value in _기본배수)
        {
            if (value >= 1f)
            {
                기본배수 += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                기본배수 -= 1f - value;
            }
        }
        if (기본배수 < 0) 기본배수 = 0;
    }
    private void Calc증가량()
    {
        증가량 = 0;
        foreach (int value in _증가량)
        {
            증가량 += value;
        }
    }
    private void Calc배수()
    {
        배수 = 1f;
        foreach (float value in _배수)
        {
            if (value >= 1f)
            {
                배수 += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                배수 -= 1f - value;
            }
        }
        if (배수 < 0) 배수 = 0;
    }
    private void Calc추가량()
    {
        추가량 = 0;
        foreach (int value in _추가량)
        {
            추가량 += value;
        }
    }
    private void Calc데이터()
    {
        데이터 = Mathf.FloorToInt((_데이터 * 기본배수 + 증가량) * 배수 + 추가량);
    }
    public void 수치초기화(int 데이터)
    {
        _데이터 = 데이터;
        _기본배수 = new List<float>();
        _증가량 = new List<int>();
        _배수 = new List<float>();
        _추가량 = new List<int>();
        기본배수 = 1f;
        증가량 = 0;
        배수 = 1f;
        추가량 = 0;
        Calc데이터();
    }
}

public class DataFloat
{

    private float _데이터 = 0;            // 기본 데이터.
    private List<float> _기본배수;
    private List<float> _증가량;
    private List<float> _배수;
    private List<float> _추가량;

    public float 기본배수 { get; private set; }
    public float 증가량 { get; private set; }
    public float 배수 { get; private set; }
    public float 추가량 { get; private set; }
    public float 데이터 { get; private set; }

    public DataFloat(float 초기데이터 = 0)
    {
        수치초기화(초기데이터);
    }
    public int Add기본배수(float value)
    {
        int index = _기본배수.Count;
        _기본배수.Insert(index, value);
        Calc기본배수();
        Calc데이터();
        return index;
    }
    public int Add증가량(float value)
    {
        int index = _증가량.Count;
        _증가량.Insert(index, value);
        Calc증가량();
        Calc데이터();
        return index;
    }
    public int Add배수(float value)
    {
        int index = _배수.Count;
        _배수.Insert(index, value);
        Calc배수();
        Calc데이터();
        return index;
    }
    public int Add추가량(float value)
    {
        int index = _추가량.Count;
        _추가량.Insert(index, value);
        Calc추가량();
        Calc데이터();
        return index;
    }
    public void Remove기본배수(int index)
    {
        if (0 <= index && index < _기본배수.Count)
        {
            _기본배수.RemoveAt(index);
        }
        Calc기본배수();
        Calc데이터();
    }
    public void Remove증가량(int index)
    {
        if (0 <= index && index < _증가량.Count)
        {
            _증가량.RemoveAt(index);
        }
        Calc증가량();
        Calc데이터();
    }
    public void Remove배수(int index)
    {
        if (0 <= index && index < _배수.Count)
        {
            _배수.RemoveAt(index);
        }
        Calc배수();
        Calc데이터();
    }
    public void Remove추가량(int index)
    {
        if (0 <= index && index < _추가량.Count)
        {
            _추가량.RemoveAt(index);
        }
        Calc추가량();
        Calc데이터();
    }
    private void Calc기본배수()
    {
        기본배수 = 1f;
        foreach (float value in _기본배수)
        {
            if (value >= 1f)
            {
                기본배수 += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                기본배수 -= 1f - value;
            }
        }
        if (기본배수 < 0) 기본배수 = 0;
    }
    private void Calc증가량()
    {
        증가량 = 0;
        foreach (float value in _증가량)
        {
            증가량 += value;
        }
    }
    private void Calc배수()
    {
        배수 = 1f;
        foreach (float value in _배수)
        {
            if (value >= 1f)
            {
                배수 += value - 1f;
            }
            else if (0 < value && value < 1f)
            {
                배수 -= 1f - value;
            }
        }
        if (배수 < 0) 배수 = 0;
    }
    private void Calc추가량()
    {
        추가량 = 0;
        foreach (float value in _추가량)
        {
            추가량 += value;
        }
    }
    private void Calc데이터()
    {
        데이터 = (_데이터 * 기본배수 + 증가량) * 배수 + 추가량;
    }
    public void 수치초기화(float 데이터)
    {
        _데이터 = 데이터;
        _기본배수 = new List<float>();
        _증가량 = new List<float>();
        _배수 = new List<float>();
        _추가량 = new List<float>();
        기본배수 = 1f;
        증가량 = 0;
        배수 = 1f;
        추가량 = 0;
        Calc데이터();
    }
}