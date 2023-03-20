using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBase
{
    private int MaxHP;
    private int CurrentHP;
    private int Defense;
    public List<EffectID> Effects;
    public void MinusHP(int hp)
    {
        CurrentHP -= hp;
    }

    public void PlusHP(int hp)
    {
        CurrentHP += hp;
    }

    public void PlusDef(int def)
    {
        Defense += def;
    }

    public void MinusDef(int def)
    {
        Defense -= def;
    }

}

public class PlayerBase : CreatureBase
{

}

public class EnemyBase : CreatureBase
{

}