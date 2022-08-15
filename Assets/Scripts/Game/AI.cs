using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject unitPrefab;
    bool aiReady = false;
    public GameObject newUnit;
    public List<GameObject> teamA = new List<GameObject>();
	public List<GameObject> teamB = new List<GameObject>();
    public HexCell[] cells;
    public float elapsedTime = 0f;
    int counter = 0;
    List<Units> units = new List<Units>() { 
        new Units(){ unitType = "Swordsmen", count = 4}, //4
        new Units(){ unitType = "Spearman", count = 4}, //4
        new Units(){ unitType = "Archer", count = 3}, //3
        new Units(){ unitType = "CavalryArcher", count = 2}, //2
        new Units(){ unitType = "Knight", count = 1}, //1
        new Units(){ unitType = "CamelRider", count = 1}, //1
        new Units(){ unitType = "BattleElephant", count = 1}, //1
        new Units(){ unitType = "BattleElephant2", count = 0},
    };
    void Start()
    {
        counter = 0;
        foreach (var unit in units)
        {
            counter += unit.count;
        }
        counter = 0;
    }

    void Update()
    {
        if (GameObject.Find("HexGrid").GetComponent<GameControl>().startGame == false && aiReady == false)
        {
            unitDesign();
            aiReady = true;
        }
        else if (GameObject.Find("HexGrid").GetComponent<GameControl>().startGame == true)
        {
            if (Time.time > elapsedTime)
            {

                foreach (GameObject unit in teamB)
                {
                    //if (unit.GetComponent<Unit>().position == unit.GetComponent<Unit>().targetPosition)
                    //{
                    if (unit.GetComponent<Unit>().alive == true)
                    {
                        if (unit.GetComponent<Unit>().targetPosition)
                        {
                            if (unit.GetComponent<Unit>().targetPosition.GetComponent<HexCell>().full != null)
                            {
                                float distance = 9999999f;
                                GameObject tempCell = unit.GetComponent<Unit>().position;

                                foreach (GameObject enemyUnit in teamA)
                                {
                                    if (enemyUnit.GetComponent<Unit>().alive == true && distance > Vector3.Distance(enemyUnit.transform.position, unit.transform.position))
                                    {
                                        distance = Vector3.Distance(enemyUnit.transform.position, unit.transform.position);
                                        unit.GetComponent<Unit>().enemyTarget = enemyUnit;
                                    }
                                }
                                foreach (HexCell cell in unit.GetComponent<Unit>().position.GetComponent<HexCell>().neighbors)
                                {
                                    if (cell)
                                    {
                                        if (cell.full == null)
                                        {
                                            if (distance > Vector3.Distance(unit.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position))
                                            {
                                                distance = Vector3.Distance(unit.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position);
                                                tempCell = cell.gameObject;
                                            }
                                        }
                                    }
                                }
                                unit.GetComponent<Unit>().targetPosition = tempCell;
                            }
                        }
                        else
                        {
                            float distance = 9999999f;
                            GameObject tempCell = unit.GetComponent<Unit>().position;

                            foreach (GameObject enemyUnit in teamA)
                            {
                                if (enemyUnit.GetComponent<Unit>().alive == true && distance > Vector3.Distance(enemyUnit.transform.position, unit.transform.position))
                                {
                                    distance = Vector3.Distance(enemyUnit.transform.position, unit.transform.position);
                                    unit.GetComponent<Unit>().enemyTarget = enemyUnit;
                                }
                            }
                            foreach (HexCell cell in unit.GetComponent<Unit>().position.GetComponent<HexCell>().neighbors)
                            {
                                if (cell)
                                {
                                    if (cell.full == null)
                                    {
                                        if (distance > Vector3.Distance(unit.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position))
                                        {
                                            distance = Vector3.Distance(unit.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position);
                                            tempCell = cell.gameObject;
                                        }
                                    }
                                }
                            }
                            unit.GetComponent<Unit>().targetPosition = tempCell;
                        }
                    }
                }
                elapsedTime = Time.time + 1f;
            } 
        }
    }

    public void unitDesign()
    {
        for (int i = 0; i < units.Count; i++)
        {
            for (int j = 0; j < units[i].count; j++)
            {
                
                if (units[i].unitType == "Swordsmen")
                {
                    createUnit(208 + j, "Swordsmen_AI" + j, counter);
                }
                else if (units[i].unitType == "Spearman")
                {
                    createUnit(215 + j, "Spearman_AI" + j, counter);
                }
                else if (units[i].unitType == "Archer")
                {
                    createUnit(239 + j, "Archer_AI" + j, counter);
                }
                else if (units[i].unitType == "CavalryArcher")
                {
                    createUnit(244 + j, "CavalryArcher_AI" + j, counter);
                }
                else if (units[i].unitType == "Knight")
                {
                    createUnit(223 + j, "Knight_AI" + j, counter);
                }
                else if (units[i].unitType == "CamelRider")
                {
                    createUnit(229 + j, "CamelRider_AI" + j, counter);
                }
                else if (units[i].unitType == "BattleElephant")
                {
                    createUnit(232 + j, "BattleElephant_AI" + j, counter);
                }
                counter++;
            }
        }
    }

    public void createUnit(int index, string name, int counter)
    {
        newUnit = GameObject.Instantiate(unitPrefab);
        newUnit.transform.localScale = new Vector3(1f, 1f, 1f);
        newUnit.GetComponent<Unit>().team = "B";
        newUnit.tag = "AIUnit";
        teamB.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index].full = newUnit;
        newUnit.transform.position = GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index].transform.position;
        newUnit.GetComponent<Unit>().position = GameObject.Find("HexGrid").GetComponent<GameControl>().cells[index].gameObject;
        newUnit.name = name;
    }

}