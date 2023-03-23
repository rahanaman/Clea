using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBase
{
    protected int MaxHP;
    protected int CurrentHP;
    protected int Defense;

    

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

    public void GetDamage(int dam)
    {

    }

}

public class PlayerBase : CreatureBase
{
    
}

public class EnemyBase : CreatureBase
{
    
}