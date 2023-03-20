using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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