using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : Unit
{
    public Spearman()
    {
        strength = 1000f;
        currentStrength = 1000f;
        attackDamage = 6f;
        range = 1f;
        accuracy = 0.85f;
        dodgeChange = 0.1f;
        meeleArmor = 2;
        pierceArmor = 1;
        movementSpeed = 9f;
        cost = 75;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 7},
            new UnitAttackBonus(){ unitType = "Knight", attack = 6},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 5},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 4},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
