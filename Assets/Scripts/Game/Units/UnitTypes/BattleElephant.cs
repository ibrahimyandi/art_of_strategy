using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleElephant : Unit
{
    public BattleElephant()
    {
        strength = 250f;
        currentStrength = 250f;
        attackDamage = 8f;
        range = 1f;
        accuracy = 0.75f;
        dodgeChange = 0.05f;
        meeleArmor = 6f;
        pierceArmor = 20f;
        movementSpeed = 7f;
        cost = 225;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
            new UnitAttackBonus(){ unitType = "null", attack = 0},
        };
    }
}
