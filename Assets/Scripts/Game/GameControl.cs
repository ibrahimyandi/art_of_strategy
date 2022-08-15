using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public bool startGame = false;
    public HexCell selectedHexCell;
    public HexGrid hexGrid; 
    public HexCell[] cells;

    HexMesh hexMesh;
    [SerializeField]
    private GameObject DamagePopupPrefab;

    private void Awake() {
        hexMesh = GetComponentInChildren<HexMesh>();
    }
    private void Start() {
        hexGrid = GameObject.Find("HexGrid").GetComponent<HexGrid>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput();
        }
        if (selectedHexCell != null)
        {
            if (selectedHexCell.full.GetComponent<Unit>().alive == true)
            {
                GameObject.Find("HealthBar").GetComponent<Slider>().maxValue = selectedHexCell.full.GetComponent<Unit>().unitStats.strength;
                GameObject.Find("HealthBar").GetComponent<Slider>().value = selectedHexCell.full.GetComponent<Unit>().unitStats.currentStrength;
                GameObject.Find("Text_Name").GetComponent<Text>().text = selectedHexCell.full.name;
                GameObject.Find("Text_Strength").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.currentStrength.ToString();
                GameObject.Find("Text_AttackDamage").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.attackDamage.ToString();
                GameObject.Find("Text_Range").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.range.ToString();
                GameObject.Find("Text_MeeleArmor").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.meeleArmor.ToString();
                GameObject.Find("Text_PierceArmor").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.pierceArmor.ToString();
                GameObject.Find("Text_MovementSpeed").GetComponent<Text>().text = selectedHexCell.full.GetComponent<Unit>().unitStats.movementSpeed.ToString();
                GameObject.Find("UnitStats").transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            GameObject.Find("UnitStats").transform.localScale = new Vector3(0, 0, 0);
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
        if (team == "A")
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
        else if (team == "B")
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
            if (GameObject.FindGameObjectWithTag("UnitPanel").GetComponent<UnitPanel>().moveUnit)
            {
                if (cell.full == null && cell.color == Color.white/2 + cell.defaultColor)
                {
                    GameObject newUnit = GameObject.FindGameObjectWithTag("UnitPanel").GetComponent<UnitPanel>().newUnit;
                    newUnit.transform.position = cell.transform.position;
                    newUnit.GetComponent<Unit>().position = cell.gameObject;
                    newUnit.transform.localScale = new Vector3(1f, 1f, 1f);
                    GameObject.FindGameObjectWithTag("UnitPanel").GetComponent<UnitPanel>().moveUnit = false;
                    GameObject.FindGameObjectWithTag("UnitPanel").transform.localScale = new Vector3(1, 1, 1);
                    cell.full = newUnit;
                    GameObject.FindGameObjectWithTag("UnitPanel").GetComponent<UnitPanel>().newUnit = null;
                    selectableHex(newUnit.GetComponent<Unit>().team);
                    cell.color = cell.defaultColor;
                }
            }
            else
            {
                //Doluysa ve seçili hücre varsa ve seçili hücre eski hücreye eşitse seçimi kaldır
                //Doluysa ve seçili hücre yoksa burayı seç
                //Doluysa ve seçili hücre varsa bu uniti seç
                //Boşsa ve seçili hücre varsa uniti buraya taşı
                if (cell.full != null && selectedHexCell != null && selectedHexCell == cell && cell.full.GetComponent<Unit>().team == "A")
                {
                    selectableHex(cell.full.GetComponent<Unit>().team);
                    cell.color = cell.defaultColor;
                    selectedHexCell = null;
                }
                else if (cell.full != null && selectedHexCell == null && cell.full.GetComponent<Unit>().team == "A")
                {
                    selectableHex(cell.full.GetComponent<Unit>().team);
                    selectedHexCell = cell;
                }
                else if (cell.full != null && selectedHexCell != null && cell.full.GetComponent<Unit>().team == "A")
                {
                    selectableHex(cell.full.GetComponent<Unit>().team);
                    selectedHexCell.color = selectedHexCell.defaultColor;
                    selectedHexCell = cell;
                    selectableHex(cell.full.GetComponent<Unit>().team);
                }
                else if (cell.full == null && selectedHexCell != null && cell.color == Color.white/2 + cell.defaultColor)
                {
                    selectableHex(selectedHexCell.full.GetComponent<Unit>().team);
                    cell.full = selectedHexCell.full;
                    selectedHexCell.full.transform.position = cell.transform.position;
                    selectedHexCell.full.GetComponent<Unit>().position = cell.gameObject;
                    selectedHexCell.full.GetComponent<Unit>().targetPosition = cell.gameObject;
                    selectedHexCell.full = null;
                    selectedHexCell = null;
                }
            }
		}
		else
		{
            //Doluysa ve seçili hücre varsa ve seçili hücre eski hücreye eşitse seçimi kaldır
            //Doluysa ve seçili hücre yoksa burayı seç
            //Doluysa ve seçili hücre varsa bu uniti seç
            //Boşsa ve seçili hücre varsa uniti buraya taşı
            //Color.white/2 + cell.defaultColor
            if (cell.full != null && selectedHexCell != null && selectedHexCell == cell && cell.full.GetComponent<Unit>().team == "A")
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
            else if (cell.full != null && selectedHexCell == null && cell.full.GetComponent<Unit>().team == "A")
            {
                //if (cell.full.transform.position == cell.full.GetComponent<Unit>().targetPosition.transform.position)
                //{
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
                //}
            }
            else if (cell.full != null && selectedHexCell != null && cell.full.GetComponent<Unit>().team == "A")
            {
                foreach (HexCell neighbor in selectedHexCell.neighbors)
                {
                    if (neighbor)
                    {
                        neighbor.color = neighbor.defaultColor;
                    }
                }
                if (cell.full.transform.position == cell.full.GetComponent<Unit>().targetPosition.transform.position)
                {
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
                        selectedHexCell.full.GetComponent<Unit>().targetPosition = cell.gameObject;
                        selectedHexCell.color = selectedHexCell.defaultColor;
                        selectedHexCell = null;
                    }
                }
            }
		}
        hexMesh.Triangulate(cells);
	}
}
