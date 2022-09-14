using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public GameObject newUnit;
    public List<Unit> teamA = new List<Unit>();
	public List<Unit> teamB = new List<Unit>();
    public HexCell[] cells;
    public float elapsedTime = 0f;
    public bool playerReady = false;
    public static string difficulty;
    public static List<Units> enemyUnits;
    List<Units> units = new List<Units>() { 
        new Units(){ unitType = "Spearman", count = 0},
        new Units(){ unitType = "Archer", count = 0},
        new Units(){ unitType = "Swordsmen", count = 0},
        new Units(){ unitType = "CavalryArcher", count = 0},
        new Units(){ unitType = "CamelRider", count = 0},
        new Units(){ unitType = "Knight", count = 0},
        new Units(){ unitType = "BattleElephant", count = 0},
    };
    public void armyDesign()
    {
        int money = 2000;
        int count = 0;
        
        if (difficulty == "Easy")
        {
            while (money >= 200)
            {
                
                if (money >= 75 && units[0].count == 0)
                {
                    count = Random.Range(1, 4);
                    units[0].count += count;
                    money -= count * 75;
                    count = 0;
                }
                if (money >= 100 && units[1].count == 0)
                {
                    count = Random.Range(1, 4);
                    units[1].count += count;
                    money -= count * 100;
                    count = 0;
                }
                if (money >= 125 && units[2].count == 0)
                {
                    count = Random.Range(1, 4);
                    units[2].count += count;
                    money -= count * 125;
                    count = 0;
                }
                if (money >= 150 && units[3].count == 0)
                {
                    count = Random.Range(1, 3);
                    units[3].count += count;
                    money -= count * 150;
                    count = 0;
                }
                
                if (money >= 175 && units[4].count == 0)
                {
                    count = Random.Range(1, 3);
                    units[4].count += count;
                    money -= count * 175;
                    count = 0;
                }
                if (money >= 200)
                {
                    count = Random.Range(1, Mathf.FloorToInt(money/200) + 1);
                    units[5].count += count;
                    money -= count * 200;
                    count = 0;
                }
                if (money >= 225)
                {
                    count = Random.Range(1, Mathf.FloorToInt(money/225) + 1);
                    units[6].count += count;
                    money -= count * 225;
                    count = 0;
                }
            }
        }
        else if (difficulty == "Medium" || difficulty == "Hard")
        {
            count = Random.Range(0, 3);
            units[1].count = count;
            money -= count * 100;
            count = 0;
            count = Random.Range(1, 4);
            units[3].count = count;
            money -= count * 150;
            count = 0;
            while (money >= 225)
            {
                if (enemyUnits[3].count != 0 && money >= 225)
                {
                    units[6].count++;
                    money -= 225;
                }
                if (enemyUnits[1].count != 0 && money >= 200)
                {
                    units[5].count++;
                    money -= 200;
                }
                if (enemyUnits[6].count != 0 && money >= 175)
                {
                    units[4].count++;
                    money -= 175;
                }
                if (enemyUnits[0].count != 0 && money >= 125)
                {
                    units[2].count++;
                    money -= 125;
                }
                if (enemyUnits[2].count != 0 && money >= 125)
                {
                    units[2].count++;
                    money -= 125;
                }
                if (enemyUnits[4].count != 0 && money >= 75)
                {
                    units[0].count++;
                    money -= 75;
                }
                if (enemyUnits[5].count != 0 && money >= 175)
                {
                    units[4].count++;
                    money -= 175;
                }
                
            }
        }
        
        unitDesign();
    }

    public void unitDesign()
    {
        if (difficulty == "Hard")
        {
            foreach (Units unit in units)
            {
                for (int i = 0; i < unit.count; i++)
                {
                    int index = 207;
                    do
                    {
                        index++;
                    } while (cells[index].GetComponent<HexCell>().full != null && index != 255);
                    
                    if (cells[index].GetComponent<HexCell>().full == null)
                    {
                        if (unit.unitType == "Swordsmen")
                        {
                            createUnit(index, "Swordsmen_AI" + i);
                        }
                        else if (unit.unitType == "Spearman")
                        {
                            createUnit(index, "Spearman_AI" + i);
                        }
                        else if (unit.unitType == "Archer")
                        {
                            createUnit(index, "Archer_AI" + i);
                        }
                        else if (unit.unitType == "CavalryArcher")
                        {
                            createUnit(index, "CavalryArcher_AI" + i);
                        }
                        else if (unit.unitType == "Knight")
                        {
                            createUnit(index, "Knight_AI" + i);
                        }
                        else if (unit.unitType == "CamelRider")
                        {
                            createUnit(index, "CamelRider_AI" + i);
                        }
                        else if (unit.unitType == "BattleElephant")
                        {
                            createUnit(index, "BattleElephant_AI" + i);
                        }
                    }
                }
            }
        }
        else
        {
            foreach (Units unit in units)
            {
                for (int i = 0; i < unit.count; i++)
                {
                    int index;
                    do
                    {
                        index = Random.Range(208, 256);
                    } while (cells[index].GetComponent<HexCell>().full != null);
                    
                    if (cells[index].GetComponent<HexCell>().full == null)
                    {
                        if (unit.unitType == "Swordsmen")
                        {
                            createUnit(index, "Swordsmen_AI" + i);
                        }
                        else if (unit.unitType == "Spearman")
                        {
                            createUnit(index, "Spearman_AI" + i);
                        }
                        else if (unit.unitType == "Archer")
                        {
                            createUnit(index, "Archer_AI" + i);
                        }
                        else if (unit.unitType == "CavalryArcher")
                        {
                            createUnit(index, "CavalryArcher_AI" + i);
                        }
                        else if (unit.unitType == "Knight")
                        {
                            createUnit(index, "Knight_AI" + i);
                        }
                        else if (unit.unitType == "CamelRider")
                        {
                            createUnit(index, "CamelRider_AI" + i);
                        }
                        else if (unit.unitType == "BattleElephant")
                        {
                            createUnit(index, "BattleElephant_AI" + i);
                        }
                    }
                }
            }
        }
        
        teamCounts();
    }
    public void teamCounts()
    {
        GameObject.Find("HexGrid").GetComponent<GameControl>().teamACount = teamA.Count;
        GameObject.Find("HexGrid").GetComponent<GameControl>().teamBCount = teamB.Count;
    }
    public void createUnit(int index, string name)
    {
        newUnit = GameObject.Instantiate(unitPrefab);
        newUnit.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        newUnit.AddComponent<AIUnit>();
        newUnit.GetComponent<AIUnit>().teamAUnits = teamA;
        newUnit.GetComponent<Unit>().team = "B";
        newUnit.tag = "AIUnit";
        teamB.Add(newUnit.GetComponent<Unit>());
        GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index].full = newUnit;
        newUnit.transform.position = GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index].transform.position;
        newUnit.GetComponent<Unit>().position = GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index];
        newUnit.name = name;
    }

}