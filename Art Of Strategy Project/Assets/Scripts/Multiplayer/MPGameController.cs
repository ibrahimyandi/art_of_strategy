using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MPGameController : MonoBehaviour
{
    [SerializeField]
    public GameObject redPlayer;
    [SerializeField]
    public GameObject bluePlayer;
    [SerializeField]
    private GameObject UIFinishBattlePanel;
    [SerializeField]
    private GameObject UIUnitPanel;
    [SerializeField]
    private GameObject UITimer;
    [SerializeField]
    private GameObject UIGameClock;
    [SerializeField]
    private GameObject UIUnitStats;
    [SerializeField]
    private GameObject UIEnemyStats;
    [SerializeField]
    private Camera cam;
    public bool startGame = false;
    public HexCell selectedHexCell;
    public MPHexGrid hexGrid; 
    public HexCell[] cells;
    HexMesh hexMesh;

    public int redTeamCount = 0;
    public int blueTeamCount = 0;


    private void Awake() {
        hexMesh = GameObject.Find("HexMesh").GetComponent<HexMesh>();
    }
    private void Start() {
        redPlayer.GetComponent<playerUnits>().units = RoomController.redPLayer; 
        bluePlayer.GetComponent<playerUnits>().units = RoomController.bluePLayer;

        hexGrid = GameObject.Find("HexGrid").GetComponent<MPHexGrid>();
        PhotonNetwork.PlayerList[0].NickName = "red";
        //PhotonNetwork.PlayerList[1].NickName = "blue";
        /*
        if (PhotonNetwork.LocalPlayer.NickName == "red")
        {
            cam.transform.position = new Vector3(130f, 35f, -10f);
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "blue")
        {
            cam.transform.position = new Vector3(140f, 180f, -10f);
            cam.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        */
    }


    private void Update() {
        if (startGame == true)
        {
            if (redTeamCount < 1)
            {
                UIUnitPanel.SetActive(false);
                UITimer.SetActive(false);
                UIGameClock.SetActive(false);
                UIUnitStats.SetActive(false);
                UIEnemyStats.SetActive(false);
                UIFinishBattlePanel.SetActive(true);
                GameObject.Find("Text_endGameTitle").GetComponent<Text>().text = "BLUE WIN";
                startGame = false;
            }
            else if (blueTeamCount < 1)
            {
                UIUnitPanel.SetActive(true);
                UITimer.SetActive(true);
                UIGameClock.SetActive(true);
                UIUnitStats.SetActive(true);
                UIEnemyStats.SetActive(true);
                UIFinishBattlePanel.SetActive(false);
                GameObject.Find("Text_endGameTitle").GetComponent<Text>().text = "BLUE WIN";
                startGame = false;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            HandleInput();
        }
        if (selectedHexCell != null)
        {
            if (selectedHexCell.full)
            {
                if (selectedHexCell.full.GetComponent<MPUnit>().alive == true)
                {
                     UIUnitStats.SetActive(true);
                    GameObject.Find("HealthBar").GetComponent<Slider>().maxValue = selectedHexCell.full.GetComponent<MPUnit>().unitStats.strength;
                    GameObject.Find("HealthBar").GetComponent<Slider>().value = selectedHexCell.full.GetComponent<MPUnit>().unitStats.currentStrength;
                    GameObject.Find("Text_Name").GetComponent<Text>().text = selectedHexCell.full.name;
                    GameObject.Find("Text_Strength").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.currentStrength.ToString();
                    GameObject.Find("Text_AttackDamage").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.attackDamage.ToString();
                    GameObject.Find("Text_AttackSpeed").GetComponent<Text>().text = (1 - selectedHexCell.full.GetComponent<MPUnit>().unitStats.attackSpeed).ToString();
                    GameObject.Find("Text_Range").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.range.ToString();
                    GameObject.Find("Text_MeeleArmor").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.meeleArmor.ToString();
                    GameObject.Find("Text_PierceArmor").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.pierceArmor.ToString();
                    GameObject.Find("Text_MovementSpeed").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().unitStats.movementSpeed.ToString();

                    if (selectedHexCell.full.GetComponent<MPUnit>().enemyTarget)
                    {
                        UIEnemyStats.SetActive(true);
                        GameObject.Find("EnemyHealthBar").GetComponent<Slider>().maxValue = selectedHexCell.full.GetComponent<MPUnit>().enemyTarget.GetComponent<MPUnit>().unitStats.strength;
                        GameObject.Find("EnemyHealthBar").GetComponent<Slider>().value = selectedHexCell.full.GetComponent<MPUnit>().enemyTarget.GetComponent<MPUnit>().unitStats.currentStrength;
                        GameObject.Find("Text_EnemyName").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().enemyTarget.name;
                        GameObject.Find("Text_EnemyStrength").GetComponent<Text>().text = selectedHexCell.full.GetComponent<MPUnit>().enemyTarget.GetComponent<MPUnit>().unitStats.currentStrength.ToString();
                    }
                }
            }
        }
        else
        {
            UIUnitStats.SetActive(false);
            UIEnemyStats.SetActive(false);
        }
    }

    void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point, startGame);
		}
	}
    public void selectableHex(string team)
    {
        Debug.Log(team);
        if (team == "red")
        {
            for (int i = 0; i < 48; i++) // 48
            {
                if (cells[i].full == null)
                {
                    if (cells[i].color == Color.white/2 + cells[i].defaultColor)
                    {
                        cells[i].color = cells[i].defaultColor;
                    }
                    else
                    {
                        cells[i].color = Color.white/2 + cells[i].defaultColor;
                    }
                }
            }
        }
        else if (team == "blue")
        {
            for (int i = 208; i < 256; i++)
            {
                if (cells[i].full == null)
                {
                    if (cells[i].color == Color.white/2 + cells[i].defaultColor)
                    {
                        cells[i].color = cells[i].defaultColor;
                    }
                    else
                    {
                        cells[i].color = Color.white/2 + cells[i].defaultColor;
                    }
                }
            }
        }
        hexMesh.Triangulate(cells);
    }
	public void TouchCell (Vector3 position, bool startGame) {
        position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Z * hexGrid.width + coordinates.Z / 2;
		HexCell cell = cells[index];
        
		if (startGame == false)
		{
            if (UIUnitPanel.GetComponent<MPUnitPanel>().moveUnit)
            {
                if (cell.full == null && cell.color == Color.white/2 + cell.defaultColor)
                {
                    GameObject newUnit = UIUnitPanel.GetComponent<MPUnitPanel>().newUnit;
                    newUnit.transform.position = cell.transform.position;
                    newUnit.GetComponent<MPUnit>().position = cell;
                    newUnit.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    UIUnitPanel.GetComponent<MPUnitPanel>().moveUnit = false;
                    UIUnitPanel.transform.localScale = new Vector3(1, 1, 1);
                    cell.full = newUnit;
                    UIUnitPanel.GetComponent<MPUnitPanel>().newUnit = null;
                    selectableHex(newUnit.GetComponent<MPUnit>().team);
                    cell.color = cell.defaultColor;
                }
            }
            else
            {
                //Doluysa ve seçili hücre varsa ve seçili hücre eski hücreye eşitse seçimi kaldır
                //Doluysa ve seçili hücre yoksa burayı seç
                //Doluysa ve seçili hücre varsa bu uniti seç
                //Boşsa ve seçili hücre varsa uniti buraya taşı
                if (cell.full != null && selectedHexCell != null && selectedHexCell == cell && cell.full.GetComponent<MPUnit>().team == "red")
                {
                    selectableHex(cell.full.GetComponent<MPUnit>().team);
                    cell.color = cell.defaultColor;
                    selectedHexCell = null;
                    UIUnitPanel.transform.localScale = new Vector3(1f, 1f, 1f);

                }
                else if (cell.full != null && selectedHexCell == null && cell.full.GetComponent<MPUnit>().team == "red")
                {
                    selectableHex(cell.full.GetComponent<MPUnit>().team);
                    selectedHexCell = cell;
                    UIUnitPanel.transform.localScale = new Vector3(0, 0, 0);

                }
                else if (cell.full != null && selectedHexCell != null && cell.full.GetComponent<MPUnit>().team == "red")
                {
                    selectableHex(cell.full.GetComponent<MPUnit>().team);
                    selectedHexCell.color = selectedHexCell.defaultColor;
                    selectedHexCell = cell;
                    selectableHex(cell.full.GetComponent<MPUnit>().team);
                    UIUnitPanel.transform.localScale = new Vector3(0, 0, 0);
                }
                else if (cell.full == null && selectedHexCell != null && cell.color == Color.white/2 + cell.defaultColor)
                {
                    selectableHex(selectedHexCell.full.GetComponent<MPUnit>().team);
                    cell.full = selectedHexCell.full;
                    selectedHexCell.full.transform.position = cell.transform.position;
                    selectedHexCell.full.GetComponent<MPUnit>().position = cell;
                    selectedHexCell.full.GetComponent<MPUnit>().targetPosition = cell;
                    selectedHexCell.full = null;
                    selectedHexCell = null;
                    UIUnitPanel.transform.localScale = new Vector3(1f, 1f, 1f);

                }
            }
		}
		else
		{
            //Doluysa ve seçili hücre varsa ve seçili hücre eski hücreye eşitse seçimi kaldır
            //Doluysa ve seçili hücre yoksa burayı seç
            //Doluysa ve seçili hücre varsa bu uniti seç
            //Boşsa ve seçili hücre varsa uniti buraya taşı
            if (cell.full != null && selectedHexCell != null && selectedHexCell == cell && cell.full.GetComponent<MPUnit>().team == "red")
            {
                foreach (HexCell neighbor in selectedHexCell.neighbors)
				{
                    if (neighbor)
                    {
                        neighbor.color = neighbor.defaultColor;
				    }
                }
                selectedHexCell = null;
            }
            else if (cell.full != null && selectedHexCell == null && cell.full.GetComponent<MPUnit>().team == "red")
            {
                selectedHexCell = cell;
                foreach (HexCell neighbor in cell.neighbors)
                {
                    if (neighbor)
                    {
                        if (neighbor.full == null)
                        {
                            neighbor.color = Color.white/2 + cell.defaultColor;
                        }
                    }
                }
            }
            else if (cell.full != null && selectedHexCell != null && cell.full.GetComponent<MPUnit>().team == "red")
            {
                foreach (HexCell neighbor in selectedHexCell.neighbors)
                {
                    if (neighbor)
                    {
                        neighbor.color = neighbor.defaultColor;
                    }
                }
                foreach (HexCell neighbor in cell.neighbors)
                {
                    if (neighbor)
                    {
                        if (neighbor.full == null)
                        {
                            neighbor.color = Color.white/2 + cell.defaultColor;
                            selectedHexCell = cell;
                        }
                    }
                }
            }
            else if (cell.full == null && selectedHexCell != null)
            {
                foreach (HexCell neighbor in selectedHexCell.neighbors)
                {
                    if (neighbor == cell)
                    {
                        foreach (HexCell i in selectedHexCell.neighbors)
                        {
                            if (i)
                            {
                                i.color = i.defaultColor;
                            }
                        }
                        cell.color = cell.defaultColor;
                        selectedHexCell.full.GetComponent<MPUnit>().targetPosition = cell;
                        selectedHexCell.color = selectedHexCell.defaultColor;
                        selectedHexCell = null;
                    }
                }
            }
		}
        hexMesh.Triangulate(cells);
	}
    public void returnMainMenu()
    {
        SceneManager.LoadScene(0); 
    }
}
