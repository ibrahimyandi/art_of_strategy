using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public Archer()
    {
        strength = 750f;
        currentStrength = 750f;
        attackDamage = 7f;
        range = 3f;
        attackSpeed = 0.4f;
        accuracy = 0.7f;
        dodgeChange = 0f;
        meeleArmor = 0;
        pierceArmor = 0;
        movementSpeed = 5f;
        cost = 100;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Spearman", attack = 6},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
        };
    }
}
