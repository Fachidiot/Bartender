using UnityEngine;

public enum LiquidType
{
    Wine, Beer, Vodka, Whiskey, Rum, Gin,
    Tequila, Brandy, Liqueur, Soda, Juice, Water, Milk
}

[CreateAssetMenu(fileName = "Liquid Data", menuName = "Scriptable Object/Liquid Data")]
public class LiquidData : ScriptableObject
{
    public LiquidType liquidType;

    [Range(0f, 100f)]
    public float liquidAlcohol;
}
