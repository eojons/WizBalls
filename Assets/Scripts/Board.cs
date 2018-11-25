using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;

    private int mXSize = 8;
    private int mYSize = 8;

    private int GridPixelCount = 100;
    private int GridPixelOffset = 50;

    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8]; // Hmmm...

    public void Create()
    {
        for (int y = 0; y < mYSize; y++)
        {
            for (int x = 0; x < mXSize; x++)
            {
                // Create cell
                GameObject newCell = Instantiate(mCellPrefab, transform);

                // Position
                RectTransform rectTransfrom = newCell.GetComponent<RectTransform>();
                rectTransfrom.anchoredPosition = new Vector2((x * GridPixelCount) 
                    + GridPixelOffset, (y * GridPixelCount) + GridPixelOffset);

                // Setup
                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
    }
}
