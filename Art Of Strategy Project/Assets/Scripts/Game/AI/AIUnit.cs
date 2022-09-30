using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIUnit : MonoBehaviour
{
    public List<Unit> teamAUnits = new List<Unit>();
    private string typeName;
    public float elapsedTime = 0f;

    private void Start() {
       typeName = gameObject.GetComponent<Unit>().typeName;
       
    }
    private void Update() {
        if (Time.time > elapsedTime)
        {
            if (this.GetComponent<Unit>().alive == true)
            {
                if (this.gameObject.GetComponent<Unit>().unitStats.range > 1)
                {
                    this.GetComponent<Unit>().enemyTarget = SearchTarget(this.GetComponent<Unit>().position);
                    float enemyDistance = Vector2.Distance(this.gameObject.GetComponent<Unit>().position.transform.position, gameObject.GetComponent<Unit>().enemyTarget.transform.position);

                    if (enemyDistance < 26f)
                    {
                        this.gameObject.GetComponent<Unit>().targetPosition = kiteMechanic(this.gameObject.GetComponent<Unit>());
                    }
                    else if (enemyDistance > 35f)
                    {
                        this.GetComponent<Unit>().targetPosition = targetPosition(this.GetComponent<Unit>().position, SearchTarget(this.GetComponent<Unit>().position));
                    }
                }
                else
                {
                    if (targetLowStrength(this.GetComponent<Unit>().position) != null)
                    {
                        this.GetComponent<Unit>().enemyTarget = SearchTarget(this.GetComponent<Unit>().position);
                    }
                    else
                    {
                        if (this.GetComponent<Unit>().targetPosition)
                        {
                            if (this.GetComponent<Unit>().targetPosition.GetComponent<HexCell>().full != null)
                            {
                                float distance = 9999999f;
                                HexCell tempCell = this.GetComponent<Unit>().position;

                                foreach (Unit enemyUnit in teamAUnits)
                                {
                                    if (enemyUnit.GetComponent<Unit>().alive == true && distance > Vector3.Distance(enemyUnit.transform.position, this.transform.position))
                                    {
                                        distance = Vector3.Distance(enemyUnit.transform.position, this.transform.position);
                                        this.GetComponent<Unit>().enemyTarget = enemyUnit;
                                    }
                                }
                                foreach (HexCell cell in this.GetComponent<Unit>().position.GetComponent<HexCell>().neighbors)
                                {
                                    if (cell)
                                    {
                                        if (cell.full == null)
                                        {
                                            if (distance > Vector3.Distance(this.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position))
                                            {
                                                distance = Vector3.Distance(this.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position);
                                                tempCell = cell;
                                            }
                                        }
                                    }
                                }
                                this.GetComponent<Unit>().targetPosition = tempCell;
                            }
                        }
                        else
                        {
                            this.GetComponent<Unit>().targetPosition = targetPosition(this.GetComponent<Unit>().position, SearchTarget(this.GetComponent<Unit>().position));
                        }
                    }
                }
            }
            elapsedTime = Time.time + 0.5f;
        }
    }

    public HexCell kiteMechanic(Unit unit)
    {
        float distance = 0f;
        HexCell temp = null;
        foreach (HexCell neighbor in unit.position.neighbors)
        {
            if (neighbor)
            {
                if (neighbor.full != null)
                {
                    if (neighbor.full.GetComponent<Unit>().team == "A")
                    {
                        foreach (HexCell neighbor2 in unit.position.neighbors)
                        {
                            if (neighbor2)
                            {
                                if (neighbor2.full == null)
                                {
                                    if (distance < Vector3.Distance(neighbor.full.transform.position, neighbor2.transform.position))
                                    {
                                        distance = Vector3.Distance(neighbor.full.transform.position, neighbor2.transform.position);
                                        temp = neighbor2;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return temp;
    }

    public Unit SearchTarget(HexCell positionCell)
    {
        float distance = 99999f;

        foreach (Unit enemyUnit in teamAUnits)
        {
            if (enemyUnit.GetComponent<Unit>().alive == true && distance > Vector3.Distance(enemyUnit.transform.position, this.transform.position))
            {
                distance = Vector3.Distance(enemyUnit.transform.position, this.transform.position);
                this.GetComponent<Unit>().enemyTarget = enemyUnit;
            }
        }
        return this.GetComponent<Unit>().enemyTarget;
    }

    public HexCell checkEnemyPath(HexCell from, Unit enemyTarget) //Kullanılmıyor
    {
        HexCell temp = null;
        foreach (HexCell neighbor in from.neighbors)
        {
            if (neighbor)
            {
                if (neighbor.full == null)
                {
                    foreach (HexCell enemyNeighbor in enemyTarget.position.neighbors)
                    {
                        if (enemyNeighbor)
                        {
                            if (enemyNeighbor.full == null)
                            {
                                if (enemyNeighbor == neighbor)
                                {
                                    temp = neighbor;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (temp == null)
        {
            enemyTarget = null;
        }
        return temp;
    }

    public Unit targetLowStrength(HexCell from)
    {
        float strengthUnit = float.MaxValue;
        Unit temp = null;

        foreach (HexCell neighbor in from.neighbors)
        {
            if (neighbor)
            {
                if (neighbor.full != null)
                {
                    if (strengthUnit > neighbor.full.GetComponent<Unit>().unitStats.strength && neighbor.full.GetComponent<Unit>().team == "A")
                    {
                        strengthUnit = neighbor.full.GetComponent<Unit>().unitStats.strength;
                        temp = neighbor.full.GetComponent<Unit>();
                    }
                }
            }
        }
        return temp;
    }

    public List<Unit> sortTargetDistance(List<Unit> targetList)
    {
        return targetList.OrderBy(
            x => Vector2.Distance(this.gameObject.GetComponent<Unit>().position.transform.position, x.transform.position)
        ).ToList();
    }

    public HexCell targetPosition(HexCell from, Unit enemyTarget)
    {
        float distance = 9999999f;
        HexCell tempCell = this.GetComponent<Unit>().position;

        foreach (HexCell cell in this.GetComponent<Unit>().position.GetComponent<HexCell>().neighbors)
        {
            if (cell)
            {
                if (cell.full == null)
                {
                    if (distance > Vector3.Distance(this.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position))
                    {
                        distance = Vector3.Distance(this.GetComponent<Unit>().enemyTarget.transform.position, cell.gameObject.transform.position);
                        tempCell = cell;
                    }
                }
            }
        }
        return tempCell;
    }
}
