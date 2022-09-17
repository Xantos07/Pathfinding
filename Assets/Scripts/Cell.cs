using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]  private TextMeshProUGUI textValue;
    [SerializeField]  private Vector2Int CoordInWorld;
    
    [SerializeField]  private int startingValue;
    [SerializeField]  private int endingValue;
    [SerializeField]  private int distanceValue;

    [SerializeField] private List<Cell> adjacentCell;

    [SerializeField] private Material matCellPoint; 
    [SerializeField] private Material matCellPath; 
    [SerializeField] private Material matCellAroundPath;
    [SerializeField] private MeshRenderer meshRenderer;
    public void SetCoord(int _x, int _y)
    {
        CoordInWorld = new Vector2Int(_x, _y);
    }
    
    public void SetValue(int _startingValue, int _endingValue, int _distanceValue, CellIdentity _newCellIdentity)
    {
        textValue.text = _startingValue + " " + _endingValue + " " + _distanceValue;

        switch (_newCellIdentity)
        {
            case CellIdentity.point:
                meshRenderer.materials = new[] {matCellPoint};
                break;
            case CellIdentity.path:
                meshRenderer.materials = new[] {matCellPath};
                break;
            case CellIdentity.around:
                meshRenderer.materials = new[] {matCellAroundPath};
                break;
        }
    }
    
    public void AddNewAdjacent(Cell _cellData)
    {
        adjacentCell.Add(_cellData);
    }
}

public enum CellIdentity
{
    point = 0,
    path = 1,
    around =2
}
