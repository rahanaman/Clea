using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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