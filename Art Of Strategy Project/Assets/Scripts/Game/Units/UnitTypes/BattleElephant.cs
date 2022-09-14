using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleElephant : Unit
{
    public BattleElephant()
    {
        strength = 300f;
        currentStrength = 300f;
        attackDamage = 8f;
        range = 1f;
        attackSpeed = 0.6f;
        accuracy = 0.75f;
        dodgeChange = 0.1f;
        meeleArmor = 60f;
        pierceArmor = 60f;
        movementSpeed = 7f;
        cost = 225;
        attackBonus = new List<UnitAttackBonus>(){
            new UnitAttackBonus(){ unitType = "Spearman", attack = 0},
            new UnitAttackBonus(){ unitType = "Archer", attack = 4},
            new UnitAttackBonus(){ unitType = "Swordsmen", attack = 6},
            new UnitAttackBonus(){ unitType = "CavalryArcher", attack = 6},
            new UnitAttackBonus(){ unitType = "CamelRider", attack = 0},
            new UnitAttackBonus(){ unitType = "Knight", attack = 0},
            new UnitAttackBonus(){ unitType = "BattleElephant", attack = 0},
        };
    }
}
