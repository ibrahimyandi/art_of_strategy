using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavalryArcher : Unit
{
    public CavalryArcher()
    {
        strength = 500f;
        currentStrength = 500f;
        attackDamage = 10f;
        range = 2f;
        accuracy = 0.65f;
        dodgeChange = 0.15f;
        meeleArmor = 1;
        pierceArmor = 1;
        movementSpeed = 15f;
        cost = 150;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 10},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
