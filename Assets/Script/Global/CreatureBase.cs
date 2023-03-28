using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
// Data 없음

public class CreatureBase
{
    public int Max체력;
    public int 체력;

}

public class PlayerBase : CreatureBase
{
    public CharID Id;
    public List<유물ID> 유물List { get; private set; }
    public List<CardID> CardList { get; private set; }
    public PlayerBase(CharID id)
    {
        Id = id;
    }
    public void Load(List<string> data)
    {
        // Max체력, 체력, 유물List, CardList 로드
    }

    public List<string> Save()
    {
        List<string> save = new List<string>();
        // CharID, Max체력, 체력, 유물List, CardList 세이브
        return save;
    }
    // 필요없으면 나중에 삭제.
}

public class EnemyBase : CreatureBase
{
    // 필요없으면 나중에 삭제.
}

public sealed class 아폴로 : PlayerBase // 만약 캐릭터마다 특수 기믹이 있다면 여기에 각각 정의하고 콜백 등록
{
    public 아폴로(CharID id) : base(id)
    {

    }

}

public class 스킬라 : PlayerBase
{
    public 스킬라(CharID id) : base(id)
    {

    }

}

public class 디아나 : PlayerBase
{
    public 디아나(CharID id) : base(id)
    {

    }

}
public class 가고일 : EnemyBase
{
    // 각 객체의 전투 패턴 
}
