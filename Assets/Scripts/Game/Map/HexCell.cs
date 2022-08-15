using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Color color;
	public Color defaultColor;
	public GameObject full;
	public HexCell[] neighbors;
	public float movementCost;
	public int attackerPenalty;
	public int heightLevel;

	private void Update() {
		
	}
    public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

    public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()] = this;
	}

}
