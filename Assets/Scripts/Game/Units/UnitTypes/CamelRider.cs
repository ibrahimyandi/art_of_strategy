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
        accuracy = 0.8f;
        dodgeChange = 0.15f;
        meeleArmor = 4f;
        pierceArmor = 2f;
        movementSpeed = 20f;
        cost = 175;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 4},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 20},
            new UnitAttackBonus(){ unitType = "Knight", attack = 20},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 20},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 20},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
