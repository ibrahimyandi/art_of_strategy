using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsmen : Unit
{
    public Swordsmen()
    {
        strength = 1000f;
        currentStrength = 1000f;
        attackDamage = 16f;
        range = 1f;
        accuracy = 0.9f;
        dodgeChange = 0.25f;
        meeleArmor = 4f;
        pierceArmor = 6f;
        movementSpeed = 8f;
        cost = 125;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 4},
            new UnitAttackBonus(){ unitType = "Archer", attack = 6},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
