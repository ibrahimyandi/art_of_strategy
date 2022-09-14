using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class ArmyDesign : MonoBehaviour
{
    [SerializeField]
    private Button spearmanCountIncrease;
    [SerializeField]
    private Button archerCountIncrease;
    [SerializeField]
    private Button swordsmenCountIncrease;
    [SerializeField]
    private Button cavlaryArcherCountIncrease;
    [SerializeField]
    private Button camelRiderCountIncrease;
    [SerializeField]
    private Button knightCountIncrease;
    [SerializeField]
    private Button battleElephantCountIncrease;
    void Start()
    {
        GameObject.Find("Spearman").transform.Find("Text_Price").GetComponent<Text>().text = "75";
        GameObject.Find("Archer").transform.Find("Text_Price").GetComponent<Text>().text = "100";
        GameObject.Find("Swordsmen").transform.Find("Text_Price").GetComponent<Text>().text = "125";
        GameObject.Find("Cavalry Archer").transform.Find("Text_Price").GetComponent<Text>().text = "150";
        GameObject.Find("Camel Rider").transform.Find("Text_Price").GetComponent<Text>().text = "175";
        GameObject.Find("Knight").transform.Find("Text_Price").GetComponent<Text>().text = "200";
        GameObject.Find("Battle Elephant").transform.Find("Text_Price").GetComponent<Text>().text = "225";
    }
    
    public void ReadyButton()
    {
        UnitPanel.units = new List<Units>() { 
            new Units(){ unitType = "Spearman", count = int.Parse(GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Archer", count = int.Parse(GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Swordsmen", count = int.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Cavalry Archer", count = int.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Camel Rider", count = int.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Knight", count = int.Parse(GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Battle Elephant", count = int.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text)},
        };
        AIManager.enemyUnits = new List<Units>() { 
            new Units(){ unitType = "Spearman", count = int.Parse(GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Archer", count = int.Parse(GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Swordsmen", count = int.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Cavalry Archer", count = int.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Camel Rider", count = int.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Knight", count = int.Parse(GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text)},
            new Units(){ unitType = "Battle Elephant", count = int.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text)},
        };
        AIManager.difficulty =  GameObject.Find("DifficultyRadioGroups").GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().name;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0); 
    }
    public void MoneyControl()
    {
        int money = Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text);
        if (money < 75)
        {
            spearmanCountIncrease.interactable = false;
        }
        else
        {
            spearmanCountIncrease.interactable = true;
        }

        if (money < 100)
        {
            archerCountIncrease.interactable = false;
        }
        else
        {
            archerCountIncrease.interactable = true;
        }

        if (money < 125)
        {
            swordsmenCountIncrease.interactable = false;
        }
        else
        {
            swordsmenCountIncrease.interactable = true;
        }
         
        if (money < 150)
        {
            cavlaryArcherCountIncrease.interactable = false;
        }
        else
        {
            cavlaryArcherCountIncrease.interactable = true;
        }

        if (money < 175)
        {
            camelRiderCountIncrease.interactable = false;
        }
        else
        {
            camelRiderCountIncrease.interactable = true;
        }

        if (money < 200)
        {
            knightCountIncrease.interactable = false;
        }
        else
        {
            knightCountIncrease.interactable = true;
        }

        if (money < 225)
        {
            battleElephantCountIncrease.interactable = false;
        }
        else
        {
            battleElephantCountIncrease.interactable = true;
        }
    }

    public void SwordsmenCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Swordsmen").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void SwordsmenCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Swordsmen").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Swordsmen").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Swordsmen").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void SpearmanCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Spearman").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Spearman").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void SpearmanCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Spearman").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Spearman").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Spearman").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void ArcherCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Archer").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Archer").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void ArcherCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Archer").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Archer").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Archer").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void CavalryArcherCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Cavalry Archer").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void CavalryArcherDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Cavalry Archer").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Cavalry Archer").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Cavalry Archer").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void KnightCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Knight").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Knight").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void KnightCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Knight").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Knight").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Knight").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void CamelRiderCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Camel Rider").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void CamelRiderCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Camel Rider").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Camel Rider").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Camel Rider").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
    public void BattleElephantCountIncrease()
    {
        int count = Int32.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text = (count+1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) - Int32.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();

        if (count >= 0)
        {
            GameObject.Find("Battle Elephant").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = true;
        }
    }
    public void BattleElephantCountDecrease()
    {
        int count = Int32.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text);
        GameObject.Find("Battle Elephant").transform.Find("Text_Count").GetComponent<Text>().text = (count-1).ToString();
        GameObject.Find("Text_Money").GetComponent<Text>().text = (Int32.Parse(GameObject.Find("Text_Money").GetComponent<Text>().text) + Int32.Parse(GameObject.Find("Battle Elephant").transform.Find("Text_Price").GetComponent<Text>().text)).ToString();
        if (count == 1)
        {
            GameObject.Find("Battle Elephant").transform.Find("Btn_Decrease").GetComponent<Button>().interactable = false;
        }
    }
}
