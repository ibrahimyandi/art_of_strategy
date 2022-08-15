using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    public GameObject UnitPrefab;
    public GameObject newUnit;
    public int unitCount;
    public bool moveUnit = false;
    List<Units> units = new List<Units>() { 
        new Units(){ unitType = "Swordsmen", count = 2},
        new Units(){ unitType = "Spearman", count = 1},
        new Units(){ unitType = "Archer", count = 1},
        new Units(){ unitType = "Cavalry Archer", count = 4},
        new Units(){ unitType = "Knight", count = 2},
        new Units(){ unitType = "Camel Rider", count = 2},
        new Units(){ unitType = "Battle Elephant", count = 1},
        new Units(){ unitType = "null", count = 0},
    };
    float timeLeft = 60.0f;
    private void Awake() {
        gameObject.transform.GetChild(0).GetComponent<Button>().interactable = false;
        int i = 1;
        foreach (var unit in units)
        {
            unitCount += unit.count;
            GameObject button = gameObject.transform.GetChild(i).gameObject;
            Text[] buttonText = button.GetComponentsInChildren<Text>();
            buttonText[0].text = unit.unitType;
            buttonText[1].text = unit.count.ToString();
            i++;
        }
    }

    private void Start() {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].count < 1)
            {
                gameObject.transform.GetChild(i+1).gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }
    
    private void Update() {
        if (!GameObject.Find("HexGrid").GetComponent<GameControl>().startGame)
        {
            timeLeft -= Time.deltaTime;
            GameObject.Find("Timer").GetComponent<Text>().text = ((int)timeLeft).ToString();
            if ( timeLeft < 0 )
            {
                //ReadyButton();
            }
            if (unitCount < 1)
            {
                gameObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ReadyButton()
    {
        transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("HexGrid").GetComponent<GameControl>().startGame = true;
        GameObject.Find("Timer").SetActive(false);
    }

    public void CreateSwordsmen()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "Swordsmen_" + units[0].count;
        newUnit.tag = "Unit";
        units[0].count--;
        unitCount--;
        if (units[0].count < 1)
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(1).GetChild(1).GetComponent<Text>().text = (units[0].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateSpearman()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "Spearman_" + units[0].count;
        newUnit.tag = "Unit";
        units[1].count--;
        unitCount--;
        if (units[1].count < 1)
        {
            gameObject.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = (units[1].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateArcher()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "Archer_" + units[0].count;
        newUnit.tag = "Unit";
        units[2].count--;
        unitCount--;
        if (units[2].count < 1)
        {
            gameObject.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(3).GetChild(1).GetComponent<Text>().text = (units[2].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");

    }
    public void CreateCavalryArcher()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "CavalryArcher_" + units[0].count;
        newUnit.tag = "Unit";
        units[3].count--;
        unitCount--;
        if (units[3].count < 1)
        {
            gameObject.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(4).GetChild(1).GetComponent<Text>().text = (units[3].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateKnight()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "Knight_" + units[0].count;
        newUnit.tag = "Unit";
        units[4].count--;
        unitCount--;
        if (units[4].count < 1)
        {
            gameObject.transform.GetChild(5).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(5).GetChild(1).GetComponent<Text>().text = (units[4].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateCamelRider()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "CamelRider_" + units[0].count;
        newUnit.tag = "Unit";

        units[5].count--;
        unitCount--;
        if (units[5].count < 1)
        {
            gameObject.transform.GetChild(6).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(6).GetChild(1).GetComponent<Text>().text = (units[5].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateBattleElephant()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "BattleElephant_" + units[0].count;
        newUnit.tag = "Unit";
        units[6].count--;
        unitCount--;
        if (units[6].count < 1)
        {
            gameObject.transform.GetChild(7).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(7).GetChild(1).GetComponent<Text>().text = (units[6].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
    public void CreateBattleElephant2()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<Unit>().team = "A";
        newUnit.name = "BattleElephant_" + units[0].count;
        newUnit.tag = "Unit";
        units[6].count--;
        unitCount--;
        if (units[6].count < 1)
        {
            gameObject.transform.GetChild(8).gameObject.GetComponent<Button>().interactable = false;
        }
        transform.GetChild(8).GetChild(1).GetComponent<Text>().text = (units[6].count).ToString();
        GameObject.Find("HexGrid").GetComponent<AI>().teamA.Add(newUnit);
        GameObject.Find("HexGrid").GetComponent<GameControl>().selectableHex("A");
    }
}