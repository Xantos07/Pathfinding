using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Cell cell;
    [SerializeField] private int gridX = 10;
    [SerializeField] private int gridY = 5;
    
    [SerializeField] private Vector2Int StartCell;
    [SerializeField] private Vector2Int EndCell;

    private Cell[,] arrayCells;
    
    private void Start()
    {
        arrayCells = new Cell[gridX, gridY];
        
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Cell newCell = Instantiate(cell, new Vector3(x,0, y) + transform.position, Quaternion.identity);
                arrayCells[x, y] = newCell;
                newCell.SetCoord(x, y);
            }
        }
        
        arrayCells[StartCell.x, StartCell.y].SetValue(0,0,0, CellIdentity.point); 
        arrayCells[EndCell.x, EndCell.y].SetValue(0,0,0,CellIdentity.point); 
        
        //AddNewAdjacent
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                for (int a = -1; a < 2; a++)
                {
                    for (int b = -1; b < 2; b++)
                    {
                        if (x + a >= 0 && x + a <= gridX - 1 && y + b >= 0 && y + b <= gridY - 1)
                        {
                            if (x + a != x || y + b != y)
                            {
                                arrayCells[x,y].AddNewAdjacent(arrayCells[x + a,y + b]);   
                            }
                        }
                    }
                }
            }
        }
    }
}
