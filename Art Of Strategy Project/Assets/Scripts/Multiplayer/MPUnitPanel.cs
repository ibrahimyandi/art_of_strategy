using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MPUnitPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject MPGameController;
    public GameObject UnitPrefab;
    public GameObject newUnit;
    public int unitCount;
    public bool moveUnit = false;
    public static List<Units> teamAUnits;
    public static List<Units> teamBUnits;
    public List<Units> units;
    float timeLeft = 90.0f;
    private void Awake() {
        
    }
    
    private void Start() {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].count < 1)
            {
                gameObject.transform.GetChild(i+1).gameObject.GetComponent<Button>().interactable = false;
                var tempColor = gameObject.transform.GetChild(i+1).GetChild(1).GetComponent<Image>().color;
                tempColor.a = 0.4f;
                gameObject.transform.GetChild(i+1).GetChild(1).GetComponent<Image>().color = tempColor;
            }
        }
    }
    
    private void Update() {
        gameObject.transform.GetChild(0).GetComponent<Button>().interactable = false;
        int i = 1;
        if (PhotonNetwork.LocalPlayer.NickName == "red")
        {
            units = GameObject.Find("RedPlayer").GetComponent<playerUnits>().units;
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "blue")
        {
            units = GameObject.Find("BluePlayer").GetComponent<playerUnits>().units;
        }

        foreach (var unit in units)
        {
            unitCount += unit.count;
            GameObject button = gameObject.transform.GetChild(i).gameObject;
            Text[] buttonText = button.GetComponentsInChildren<Text>();
            buttonText[0].text = unit.unitType;
            buttonText[1].text = unit.count.ToString();
            i++;
        }
        if (!GameObject.Find("MPController").GetComponent<MPGameController>().startGame)
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
        GameObject.Find("HexGrid").GetComponent<AIManager>().armyDesign();
        GameObject.Find("MPController").GetComponent<MPGameController>().startGame = true;
        GameObject.Find("Timer").transform.localScale = new Vector3(0, 0, 0);
    }


    public void CreateSpearman()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "Spearman_" + units[0].count;
        newUnit.tag = "Unit";
        units[0].count--;
        unitCount--;
        if (units[0].count < 1)
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(1).GetChild(2).GetComponent<Text>().text = (units[0].count).ToString();
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
    }
    public void CreateArcher()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "Archer_" + units[1].count;
        newUnit.tag = "Unit";
        units[1].count--;
        unitCount--;
        if (units[1].count < 1)
        {
            gameObject.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(2).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(2).GetChild(1).GetComponent<Image>().color = tempColor;
            
        }
        transform.GetChild(2).GetChild(2).GetComponent<Text>().text = (units[1].count).ToString();
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        

    }
    public void CreateSwordsmen()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "Swordsmen_" + units[2].count;
        newUnit.tag = "Unit";
        units[2].count--;
        unitCount--;
        if (units[2].count < 1)
        {
            gameObject.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(3).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(3).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(3).GetChild(2).GetComponent<Text>().text = (units[2].count).ToString();
        
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        
    }
    public void CreateCavalryArcher()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "CavalryArcher_" + units[3].count;
        newUnit.tag = "Unit";
        units[3].count--;
        unitCount--;
        if (units[3].count < 1)
        {
            gameObject.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(4).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(4).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(4).GetChild(2).GetComponent<Text>().text = (units[3].count).ToString();
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        
        
    }

    public void CreateCamelRider()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "CamelRider_" + units[4].count;
        newUnit.tag = "Unit";

        units[4].count--;
        unitCount--;
        if (units[4].count < 1)
        {
            gameObject.transform.GetChild(5).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(5).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(5).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(5).GetChild(2).GetComponent<Text>().text = (units[4].count).ToString();
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        
        
    }
    public void CreateKnight()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "Knight_" + units[5].count;
        newUnit.tag = "Unit";
        units[5].count--;
        unitCount--;
        if (units[5].count < 1)
        {
            gameObject.transform.GetChild(6).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(6).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(6).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(6).GetChild(2).GetComponent<Text>().text = (units[5].count).ToString();
        
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        
    }
    public void CreateBattleElephant()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moveUnit = true;
        newUnit = GameObject.Instantiate(UnitPrefab);
        newUnit.transform.localScale = new Vector3(0, 0, 0);
        newUnit.GetComponent<MPUnit>().team = "red";
        newUnit.name = "BattleElephant_" + units[6].count;
        newUnit.tag = "Unit";
        units[6].count--;
        unitCount--;
        if (units[6].count < 1)
        {
            gameObject.transform.GetChild(7).gameObject.GetComponent<Button>().interactable = false;
            var tempColor = gameObject.transform.GetChild(7).GetChild(1).GetComponent<Image>().color;
            tempColor.a = 0.4f;
            gameObject.transform.GetChild(7).GetChild(1).GetComponent<Image>().color = tempColor;
        }
        transform.GetChild(7).GetChild(2).GetComponent<Text>().text = (units[6].count).ToString();
        MPGameController.GetComponent<MPGameController>().selectableHex("red");
        
        
    }
}
