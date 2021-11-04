using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo
{
	Tile[,] tiles;
	int width;
	int height;
	
	public Zoo( int width = 100, int height = 100 ){
		this.width = width;
		this.height = height;
		tiles = new Tile[width,height];
	
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				tiles[x,y] = new Tile(this, x, y);
			}
		}
		
		Debug.Log("Zoo created with" +(width*height)+" tiles.");
	}
	
	public Tile GetTile(int x, int y){
		if(x > width || x < 0 || y > height || y < 0){
			Debug.LogError("Tile ("+x+","+y+") is out of range");
			return null;
		}
		return tiles[x,y];
	}
	
	public int Width {
		get {
			return width;
		}
	}
	
	public int Height{
		get{
			return height;
		}
	}
}
