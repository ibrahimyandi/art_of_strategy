using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Unit
{
    public Knight()
    {
        strength = 500f;
        currentStrength = 500f;
        attackDamage = 24f;
        range = 1f;
        accuracy = 0.8f;
        dodgeChange = 0.3f;
        meeleArmor = 8f;
        pierceArmor = 10f;
        movementSpeed = 12f;
        cost = 200;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 6},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
