using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorposition, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPostions = FindWallInDirections(floorposition, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPostions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallInDirections(HashSet<Vector2Int> floorposition, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorposition)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if(floorposition.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;

    }
}
