using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMetrics : MonoBehaviour
{
    public const float outerRadius = 10f;

	public const float innerRadius = outerRadius * 0.866025404f;
	public const float solidFactor = 0.95f;
	
	public const float blendFactor = 1f - solidFactor;

    public static Vector3[] corners = {
		new Vector3(0f, outerRadius, 0f),
		new Vector3(innerRadius, 0.5f * outerRadius, 0f),
		new Vector3(innerRadius, -0.5f * outerRadius, 0f),
		new Vector3(0f, -outerRadius, 0f),
		new Vector3(-innerRadius, -0.5f * outerRadius, 0f),
		new Vector3(-innerRadius, 0.5f * outerRadius, 0f),
        new Vector3(0f, outerRadius, 0f)
	};
	public static Vector3 GetFirstCorner (HexDirection direction) {
		return corners[(int)direction];
	}

	public static Vector3 GetSecondCorner (HexDirection direction) {
		return corners[(int)direction + 1];
	}

	public static Vector3 GetFirstSolidCorner (HexDirection direction) {
		return corners[(int)direction] * solidFactor;
	}

	public static Vector3 GetSecondSolidCorner (HexDirection direction) {
		return corners[(int)direction + 1] * solidFactor;
	}

	public static Vector3 GetBridge (HexDirection direction) {
		return (corners[(int)direction] + corners[(int)direction + 1]) *
			0.5f * blendFactor;
	}
}
