using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPHexGrid : MonoBehaviour {

	public int width = 16;
	public int height = 16;

	public Color selectedColor = Color.white;
	[SerializeField]
	private GameObject MPGameController;

	public HexCell cellPrefab;
	public Color[] colors;

	public HexCell[] cells;

	HexMesh hexMesh;
	
	void Awake () {
		hexMesh = GetComponentInChildren<HexMesh>();
		cells = new HexCell[height * width];

		for (int y = 0, i = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, y, i++);
			}
		}
		createTerrain(cells);
	}
	void Start () {
		MPGameController.GetComponent<MPGameController>().cells = cells;

		hexMesh.Triangulate(cells);
	}

	public void ColorCell (Vector3 position, Color color) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Y * width + coordinates.Y / 2;
		HexCell cell = cells[index];
		cell.color = color;
		hexMesh.Triangulate(cells);
	}

	void CreateCell (int x, int y, int i) {
		Vector3 position;
		position.x = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f);
		position.z = 0f;
		position.y = y * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);
		cell.color = colors[Random.Range(0,2)];
		cell.name = x + "_" + y;
		//cell.color = colors[Random.Range(0,8)];
		//cell.defaultColor = cell.color;
		

		if (x > 0) {
			cell.SetNeighbor(HexDirection.W, cells[i - 1]);
		}
		if (y > 0) {
			if ((y & 1) == 0) {
				cell.SetNeighbor(HexDirection.SE, cells[i - width]);
				if (x > 0) {
					cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
				}
			}
			else {
				cell.SetNeighbor(HexDirection.SW, cells[i - width]);
				if (x < width - 1) {
					cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
				}
			}
		}
	}

	public void createTerrain(HexCell[] cells)
	{
		//Create Mountain and Hills
		int rndMountain;
		int rndForest;
		for (int i = 0; i < 5; i++)
		{
			rndMountain = Random.Range(100, 156);
			cells[rndMountain].color = colors[7];
			foreach (HexCell j in cells[rndMountain].neighbors)
			{
				if (j)
				{
					j.color = colors[7];
					foreach (var k in j.neighbors)
					{
						if (k)
						{
							if (k.color != j.color)
							{
								k.color = colors[5];
							}
						}
					}

				}
			}
			
		}
		for (int i = 0; i < 2; i++)
		{
			rndForest = Random.Range(0, 80);
			cells[rndForest].color = colors[3];
			foreach (HexCell j in cells[rndForest].neighbors)
			{
				if (j)
				{
					j.color = colors[3];
					foreach (var k in j.neighbors)
					{
						if (k)
						{
							if (k.color != j.color)
							{
								k.color = colors[2];
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < 2; i++)
		{
			rndForest = Random.Range(176, 256);
			cells[rndForest].color = colors[3];
			foreach (HexCell j in cells[rndForest].neighbors)
			{
				if (j)
				{
					j.color = colors[3];
					foreach (var k in j.neighbors)
					{
						if (k)
						{
							if (k.color != j.color)
							{
								k.color = colors[2];
							}
						}
					}
				}
			}
		}
		foreach (HexCell cell in cells)
		{
			if (cell.color == colors[0] || cell.color == colors[1])
			{
				if (Random.Range(0,10) == 0)
				{
					cell.color = colors[6];
					foreach (var item in cell.neighbors)
					{
						if (item)
						{
							if (item.color == colors[0] || item.color == colors[1])
							{
								if (Random.Range(0,3) == 0)
								{
									item.color = colors[4];
								}
								else
								{
									item.color = colors[6];
								}
							}
						}
					}
				}
			}
			cell.defaultColor = cell.color;
		}

		foreach (var cell in cells)
		{
			if (cell.defaultColor == colors[0])
			{
				cell.GetComponent<HexCell>().movementCost = 1.00f;
				cell.GetComponent<HexCell>().attackerPenalty = 0;
				cell.GetComponent<HexCell>().heightLevel = 1;
			}
			else if (cell.defaultColor == colors[1])
			{
				cell.GetComponent<HexCell>().movementCost = 0.95f;
				cell.GetComponent<HexCell>().attackerPenalty = 0;
				cell.GetComponent<HexCell>().heightLevel = 1;
			}
			else if (cell.defaultColor == colors[2])
			{
				cell.GetComponent<HexCell>().movementCost = 0.85f;
				cell.GetComponent<HexCell>().attackerPenalty = 0;
				cell.GetComponent<HexCell>().heightLevel = 1;
			}
			else if (cell.defaultColor == colors[3])
			{
				cell.GetComponent<HexCell>().movementCost = 0.75f;
				cell.GetComponent<HexCell>().attackerPenalty = 1;
				cell.GetComponent<HexCell>().heightLevel = 1;
			}
			else if (cell.defaultColor == colors[4])
			{
				cell.GetComponent<HexCell>().movementCost = 0.70f;
				cell.GetComponent<HexCell>().attackerPenalty = 2;
				cell.GetComponent<HexCell>().heightLevel = 0;
			}
			else if (cell.defaultColor == colors[5])
			{
				cell.GetComponent<HexCell>().movementCost = 0.75f;
				cell.GetComponent<HexCell>().attackerPenalty = 2;
				cell.GetComponent<HexCell>().heightLevel = 2;
			}
			else if (cell.defaultColor == colors[6])
			{
				cell.GetComponent<HexCell>().movementCost = 0.60f;
				cell.GetComponent<HexCell>().attackerPenalty = 3;
				cell.GetComponent<HexCell>().heightLevel = 0;
			}
			else if (cell.defaultColor == colors[7])
			{
				cell.GetComponent<HexCell>().movementCost = 0.55f;
				cell.GetComponent<HexCell>().attackerPenalty = 4;
				cell.GetComponent<HexCell>().heightLevel = 3;
			}
		}
	}
	
}