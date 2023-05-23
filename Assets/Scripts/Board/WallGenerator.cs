using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorpositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPostions = FindWallInDirections(floorpositions, Direction2D.cardinalDirectionsList);
        var cornerWallPositions = FindWallInDirections(floorpositions, Direction2D.diagonalDirectionsList);

        CreateBasicWall(tilemapVisualizer, basicWallPostions, floorpositions);
        CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorpositions);
    }

    private static void CreateCornerWalls(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorpositions)
    {
        foreach (var position in cornerWallPositions)
        {
            string neighboursBinaryTypes = "";
            foreach (var direction in Direction2D.diagonalDirectionsList)
            {
                var neighbourPosition = position + direction;
                if (floorpositions.Contains(neighbourPosition))
                {
                    neighboursBinaryTypes += "1";
                }
                else
                {
                    neighboursBinaryTypes += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerWall(position,neighboursBinaryTypes);
        }
    }

    private static void CreateBasicWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPostions, HashSet<Vector2Int> floorpositions)
    {
        foreach (var position in basicWallPostions)
        {
            string neighboursBinaryTypes = "";
            foreach (var direction in Direction2D.cardinalDirectionsList)
            {
                var neighbourPosition = position + direction;
                if (floorpositions.Contains(neighbourPosition))
                {
                    neighboursBinaryTypes += "1";
                }
                else
                {
                    neighboursBinaryTypes += "0";
                }
            }
            tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaryTypes);
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
                if (floorposition.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;

    }
}
