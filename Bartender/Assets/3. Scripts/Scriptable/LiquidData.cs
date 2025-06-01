using UnityEngine;

enum LiquidType
{
    Wine,
    Beer,
    Vodka,
    Whiskey,
    Rum,
    Gin,
    Tequila,
    Brandy,
    Liqueur,
    Soda,
    Juice,
    Water,
    Milk
}


[CreateAssetMenu(fileName = "Liquid Data", menuName = "Scriptable Object/Liquid Data", order = int.MaxValue)]
public class LiquidData : ScriptableObject
{
    [SerializeField]
    private LiquidType liquidType;
    [SerializeField]
    [Range(0f, 100f)]
    private float liquidAlcohol;
}
