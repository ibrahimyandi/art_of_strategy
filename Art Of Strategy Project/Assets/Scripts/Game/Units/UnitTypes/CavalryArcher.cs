using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavalryArcher : Unit
{
    public CavalryArcher()
    {
        strength = 550f;
        currentStrength = 550f;
        attackDamage = 14f;
        range = 2f;
        attackSpeed = 0.55f;
        accuracy = 0.65f;
        dodgeChange = 0.2f;
        meeleArmor = 1f;
        pierceArmor = 2f;
        movementSpeed = 15f;
        cost = 150;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Spearman", attack = 12},
            new UnitAttackBonus(){ unitType = "Archer", attack = 0},
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 0},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 0},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
        };
    }
}
