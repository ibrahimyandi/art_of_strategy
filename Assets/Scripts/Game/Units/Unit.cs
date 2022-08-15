using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Unit : MonoBehaviour
{
    private float priv_strength;
    private float priv_currentStrength;
    private float priv_attackDamage;
    private float priv_range;
    private float priv_accuracy;
    private float priv_dodgeChange;
    private float priv_meeleArmor;
    private float priv_pierceArmor;
    private float priv_movementSpeed;
    private int priv_cost;
    private List<UnitAttackBonus> priv_attackBonus;
    private float priv_elapsedTime = 0;
    [SerializeField]

    private GameObject priv_position;
    [SerializeField]

    private GameObject priv_targetPosition;
    [SerializeField]
    private GameObject priv_enemyTarget;
    private bool priv_alive;
    [SerializeField]
    private string priv_team;


    public float strength
    {
        get { return priv_strength; }
        set { priv_strength = value; }
    }
    public float currentStrength
    {
        get { return priv_currentStrength; }
        set { priv_currentStrength = value; }
    }
    public float attackDamage
    {
        get { return priv_attackDamage; }
        set { priv_attackDamage = value; }
    }
    public float range
    {
        get { return priv_range; }
        set { priv_range = value; }
    }
    public float accuracy
    {
        get { return priv_accuracy; }
        set { priv_accuracy = value; }
    }
    public float dodgeChange
    {
        get { return priv_dodgeChange; }
        set { priv_dodgeChange = value; }
    }
    public float meeleArmor
    {
        get { return priv_meeleArmor; }
        set { priv_meeleArmor = value; }
    }
    public float pierceArmor
    {
        get { return priv_pierceArmor; }
        set { priv_pierceArmor = value; }
    }
    public float movementSpeed
    {
        get { return priv_movementSpeed; }
        set { priv_movementSpeed = value; }
    }
    public int cost
    {
        get { return priv_cost; }
        set { priv_cost = value; }
    }
    public List<UnitAttackBonus> attackBonus
    {
        get { return priv_attackBonus; }
        set { priv_attackBonus = value; }
    }
    public float elapsedTime
    {
        get { return priv_elapsedTime; }
        set { priv_elapsedTime = value; }
    }
    public GameObject position
    {
        get { return priv_position; }
        set { priv_position = value; }
    }
    public GameObject targetPosition
    {
        get { return priv_targetPosition; }
        set { priv_targetPosition = value; }
    }
    public GameObject enemyTarget
    {
        get { return priv_enemyTarget; }
        set { priv_enemyTarget = value; }
    }
    public bool alive
    {
        get { return priv_alive; }
        set { priv_alive = value; }
    }
    public string team
    {
        get { return priv_team; }
        set { priv_team = value; }
    }
    public Unit unitStats;
    public GameObject battleIcon;
    GameObject newBattleIcon;
    public bool attacking = false;
    public Sprite range1;
    public Sprite ranged;
    public Sprite[] unitTypeSprites;
    void Start()
    {
        foreach (Sprite sprite in unitTypeSprites)
        {
            if (team + gameObject.name.Split("_")[0] == sprite.name)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
        newBattleIcon = Instantiate(battleIcon);
        newBattleIcon.transform.localScale = new Vector3(0, 0, 0);

        alive = true;
        targetPosition = null;
        //targetPosition = position;
        if (gameObject.name.Split("_")[0] == "Swordsmen")
        {
            unitStats = new Swordsmen();
        }
        else if (gameObject.name.Split("_")[0] == "Spearman")
        {
            unitStats = new Spearman();
        }
        else if (gameObject.name.Split("_")[0] == "Archer")
        {
            unitStats = new Archer();
        }
        else if (gameObject.name.Split("_")[0] == "CavalryArcher")
        {
            unitStats = new CavalryArcher();
        }
        else if (gameObject.name.Split("_")[0] == "Knight")
        {
            unitStats = new Knight();
        }
        else if (gameObject.name.Split("_")[0] == "CamelRider")
        {
            unitStats = new CamelRider();
        }
        else if (gameObject.name.Split("_")[0] == "BattleElephant")
        {
            unitStats = new BattleElephant();
        }
        else if (gameObject.name.Split("_")[0] == "BattleElephant2")
        {
            unitStats = new BattleElephant();
        }
    }

    void Update()
    {
        if (GameObject.Find("HexGrid").GetComponent<GameControl>().startGame && alive == true)
        {
            if (targetPosition)
            {
                if (targetPosition.GetComponent<HexCell>().full != null)
                {
                    Move(position);
                }
                else
                {
                    Move(targetPosition);
                }
                 
            }
            if (team == "A")
            {
                searchTarget(targetPosition);
            }
            attacking = false;
            var offset = -90f;
            float enemyDistance = 9999999f;
            if (enemyTarget)
            {
                if (enemyTarget.GetComponent<Unit>().alive == true)
                {
                    enemyDistance = Vector2.Distance(position.transform.position, enemyTarget.GetComponent<Unit>().position.transform.position);
                }
            }
            if (enemyDistance <= 26f)
            {
                Vector2 direction = enemyTarget.GetComponent<Unit>().position.transform.position - gameObject.GetComponent<Unit>().position.transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                newBattleIcon.GetComponent<SpriteRenderer>().sprite = range1;
                newBattleIcon.transform.position = (position.transform.position + enemyTarget.GetComponent<Unit>().position.transform.position) / 2;
                newBattleIcon.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
                newBattleIcon.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                attacking = true;
                if (Time.time > elapsedTime)
                {
                    Attack(enemyTarget);
                    elapsedTime = Time.time + 0.2f;
                } 
            }
            else if (enemyDistance > 26f && enemyDistance < 35f && unitStats.range > 1)
            {
                Vector2 direction = enemyTarget.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                newBattleIcon.GetComponent<SpriteRenderer>().sprite = ranged;
                newBattleIcon.transform.position = position.transform.position;
                newBattleIcon.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
                newBattleIcon.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                attacking = true;
                if (Time.time > elapsedTime)
                {
                    Attack(enemyTarget);
                    elapsedTime = Time.time + 0.2f;
                } 
            }
            else if (enemyDistance >= 35f && enemyDistance <= 52f && unitStats.range > 2)
            {
                Vector2 direction = enemyTarget.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                newBattleIcon.GetComponent<SpriteRenderer>().sprite = ranged;
                newBattleIcon.transform.position = position.transform.position;
                newBattleIcon.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
                newBattleIcon.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                attacking = true;
                if (Time.time > elapsedTime)
                {
                    Attack(enemyTarget);
                    elapsedTime = Time.time + 0.4f;
                } 
            }
            



            if (attacking == false)
            {
                newBattleIcon.transform.localScale = new Vector3(0, 0, 0);
            }
            if (unitStats.currentStrength <= 0)
            {
                Debug.Log(GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell);
                if (GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell)
                {
                    if (GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell.full == gameObject)
                    {
                        foreach (HexCell neighbor in GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell.neighbors)
                        {
                            if (neighbor)
                            {
                                neighbor.color = neighbor.defaultColor;
                            }
                        }
                        GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell.full = null;
                        GameObject.Find("HexGrid").GetComponent<GameControl>().selectedHexCell = null;
                    }
                }
                
                newBattleIcon.transform.localScale = new Vector3(0, 0, 0);
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                alive = false;
                position.GetComponent<HexCell>().full = null;
                position = null;
            }
        }
    }

    public void searchTarget(GameObject position)
    {
        float distance = 9999999f;
        GameObject tempCell = position;

        foreach (GameObject enemyUnit in GameObject.Find("HexGrid").GetComponent<AI>().teamB)
        {
            if (enemyUnit.GetComponent<Unit>().alive == true && distance > Vector3.Distance(enemyUnit.transform.position, transform.position))
            {
                distance = Vector3.Distance(enemyUnit.transform.position, transform.position);
                enemyTarget = enemyUnit;
            }
        }
    }

    public virtual void Attack(GameObject enemyTarget)
    {
        float counterAttack = 0f;
        foreach (var unit in unitStats.attackBonus)
        {
            if (enemyTarget.GetComponent<Unit>().name.Contains(unit.unitType))
            {
                counterAttack = unit.attack;
                break;
            }
        }
        float longRange = 0f;
        float enemyDistance = Vector2.Distance(position.transform.position, enemyTarget.GetComponent<Unit>().position.transform.position);

        if (enemyDistance > 26f && enemyDistance < 35f && unitStats.range > 1)
        {
            longRange = 0.2f;
        }
        else if (enemyDistance >= 35f && enemyDistance <= 52f && unitStats.range > 2)
        {
            longRange = 0.4f;
        }

        float nightDebuff = 1f;
        if (unitStats.range > 1 && GameObject.Find("GameClock").GetComponent<GameClock>().night)
        {
            nightDebuff = 0.5f;
        }
        if (enemyTarget.GetComponent<Unit>().unitStats.currentStrength > 0)
        {
            
            float flanking = 1f;
            if (enemyTarget.GetComponent<Unit>().enemyTarget != gameObject && enemyTarget.GetComponent<Unit>().range == 1)
            {
                flanking = 1.25f;
            }
            float baseDamage;
            if (unitStats.range > 1)
            {
                baseDamage = Math.Max(0, (float)Math.Ceiling((Random.Range(0,7) - enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().attackerPenalty + unitStats.attackDamage + counterAttack) * 100 / (100 + enemyTarget.GetComponent<Unit>().unitStats.pierceArmor) * unitStats.currentStrength / unitStats.strength));
            }
            else
            {
                baseDamage = Math.Max(0, (float)Math.Ceiling((Random.Range(0,7) - enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().attackerPenalty + unitStats.attackDamage  + counterAttack) * 100 / (100 + enemyTarget.GetComponent<Unit>().unitStats.meeleArmor) * unitStats.currentStrength / unitStats.strength));
            }
            float incidence = Random.Range(nightDebuff * (1 - longRange) * (unitStats.accuracy - enemyTarget.GetComponent<Unit>().unitStats.dodgeChange), unitStats.accuracy - enemyTarget.GetComponent<Unit>().unitStats.dodgeChange);
            float hillBonus = 1f;
            if (unitStats.range == 1 && enemyTarget.GetComponent<Unit>().unitStats.range == 1)
            {
                if (enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().heightLevel > enemyTarget.GetComponent<Unit>().enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().heightLevel)
                {
                    hillBonus = hillBonus * 4/3;
                }
                else if (enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().heightLevel < enemyTarget.GetComponent<Unit>().enemyTarget.GetComponent<Unit>().position.GetComponent<HexCell>().heightLevel)
                {
                    hillBonus = hillBonus * 3/4;
                }
            }
            int damage = (int)Math.Round(baseDamage * incidence * hillBonus * flanking);
            enemyTarget.GetComponent<Unit>().unitStats.currentStrength -= damage;
        }
        else
        {
            enemyTarget = null;
        }
    }

    public virtual void Move(GameObject targetPosition)
    {
        float movementSpeedAvarage = Time.deltaTime * unitStats.movementSpeed * position.GetComponent<HexCell>().movementCost * targetPosition.GetComponent<HexCell>().movementCost;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, movementSpeedAvarage);
        if (transform.position == targetPosition.transform.position)
        {
            position.GetComponent<HexCell>().full = null;
            targetPosition.GetComponent<HexCell>().full = gameObject;
            position = targetPosition;
            targetPosition = null;
        }
    }
}
