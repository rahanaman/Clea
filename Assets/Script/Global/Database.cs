using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum CharID
{
    아폴로,
    스킬라,
    디아나
}
public enum CardID
{
    검무,
    불태우기,
    화염사슬,
    찌르기,
    타격,
    무모,
}

public enum EffectID
{

}
public enum TriggerID //data, 효과 단위에서 일치 검사를 할 때 사용하는 ID //대충 예시로 막 적어둔 상태임
{
    None, // 발동되서 최종 데미지 계산하는 애들
    ObjUse,
    턴종료,
    Attack, // 공격이 일어나는 경우 (n회 공격시 n회 불러짐)
    Defense,
    DirectAttack, // 실제 체력까지 데미지가 입혀지는 경우
    연소,
    Heal
}

public enum DataID
{
    공격,
    방어,
    독,
    연소,
    순환
    
}

public enum Card등급ID
{
    견습,
    숙련,
    전문,
    전설
}

public enum Card종류ID
{
    공격,
    파워
}

public enum SoundID
{
    MainSceneBgm,
    아폴로_시작,
    스킬라_시작,
    디아나_시작,
    UISound1
}

public enum TargetID
{
    None,
    Enemy
}
public enum StateID
{
    선택,
    전투,
    보상,
    상점
}
public enum CardStateID
{
    전투,
    패널,
    상점,
    보상
}

public enum 유물ID
{
    아폴로_시작,
    스킬라_시작,
    디아나_시작
}

public enum PanelID
{
    캐릭터선택,
    설정
}
public class DataCon<T> // 공격 관련 데이터 - ID를 통해 ID에 맞는 DataInt 호출, 최종 data 계산
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

namespace Data // C 정보
{
    public static class Database
    {
        public static Sprite[] StartSceneBackgroundCG = new Sprite[] { };
        public static Sprite[] CardIcon = new Sprite[] { };
        public static Sprite[] EnemySprite = new Sprite[] { };
        public static Sprite[] CharSprite = new Sprite[] { }; // 여기는 그림 가져올 거
        public static Dictionary<CardID, CardBase> CardDataDict = new Dictionary<CardID, CardBase>(); // 모든 참조는 여기에서 일어나용 '~`
        public static Dictionary<EffectID, EffectBase> EffectDataDict = new Dictionary<EffectID, EffectBase>();// 모든 참조는 여기에서 일어나용 '~`
        public static PanelBase[] Panel = new PanelBase[] { };
        //public static Dictionary<유물ID, 유물Base>
    }

    public class DataInt
    {

        private int _데이터
        { get
            {
                if (_is랜덤범위)
                {
                    return _랜덤데이터;
                }
                else
                {
                    return _기본데이터;
                }
            }

        }
        private int _기본데이터=0;
        private int _랜덤데이터=0;
        private List<float> _기본배수;
        private List<int> _증가량;
        private List<float> _배수;
        private List<int> _추가량;
        private bool _is랜덤범위;

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
                _기본배수[index] = 1.0f;
            }
            Calc기본배수();
            Calc데이터();
        }
        public void Remove증가량(int index)
        {
            if (0 <= index && index < _증가량.Count)
            {
                _증가량[index] = 0;
            }
            Calc증가량();
            Calc데이터();
        }
        public void Remove배수(int index) // remove로 바꿔야함
        {
            if (0 <= index && index < _배수.Count)
            {
                _배수[index] = 1.0f;
            }
            Calc배수();
            Calc데이터();
        }
        public void Remove추가량(int index)
        {
            if (0 <= index && index < _추가량.Count)
            {
                _추가량[index] = 0;
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

        public void Set랜덤범위(int min, int max) //min 이상 max 미만
        {
            _is랜덤범위 = true;
            _랜덤데이터 = UnityEngine.Random.Range(min, max);
            Calc데이터();

        }

        public void Remove랜덤범위()
        {
            if (_is랜덤범위 == true)
            {
                _is랜덤범위 = false;
                Calc데이터();
            }
        }
        public void 수치초기화(int 데이터)
        {
            _기본데이터 = 데이터;
            _is랜덤범위 = false;
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
        private float _temp데이터 = 0;
        private List<float> _기본배수;
        private List<float> _증가량;
        private List<float> _배수;
        private List<float> _추가량;
        private bool _is랜덤범위 = false;
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

        public void Set랜덤범위(float min, float max) //min 이상 max 이하
        {
            if (_is랜덤범위 == false)
            {
                _temp데이터 = _데이터;
                _is랜덤범위 = true;
            }
            _데이터 = UnityEngine.Random.Range(min, max);
            Calc데이터();

        }

        public void Remove랜덤범위()
        {
            if (_is랜덤범위 == true)
            {
                _데이터 = _temp데이터;
                _is랜덤범위 = false;
                Calc데이터();
            }
        }

        public void 수치초기화(float 데이터)
        {
            _데이터 = 데이터;
            _기본배수 = new List<float>();
            _증가량 = new List<float>();
            _배수 = new List<float>();
            _추가량 = new List<float>();
            _is랜덤범위 = false;
            기본배수 = 1f;
            증가량 = 0;
            배수 = 1f;
            추가량 = 0;
            Calc데이터();
        }
    } // 필요하면 쓰는데 일단 안 쓸 듯

    


}




public abstract class PanelBase : MonoBehaviour
{

}




