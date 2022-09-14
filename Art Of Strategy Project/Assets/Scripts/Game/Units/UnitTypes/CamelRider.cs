using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamelRider : Unit
{
    public CamelRider()
    {
        strength = 500f;
        currentStrength = 500f;
        attackDamage = 8f;
        range = 1f;
        attackSpeed = 0.45f;
        accuracy = 0.8f;
        dodgeChange = 0.2f;
        meeleArmor = 4f;
        pierceArmor = 4f;
        movementSpeed = 20f;
        cost = 175;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 10},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 20},
            new UnitAttackBonus(){ unitType = "Knight", attack = 40},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 60},
        };
    }
}
