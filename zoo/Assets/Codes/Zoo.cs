using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo
{
	static Zoo _instance;
	public static Zoo Instance { get; protected set;}
	
	public Tile[,] tiles;
	int width;
	int height;
	
	public int Width {
		get {
			return width;
		}
	}
	
	public int Height {
		get {
			return height;
		}
	}
	
	Dictionary<string, Building> buildingPrototypes;
	
	//zoo contructor, 2 dimenzioban, fix méretű világ
	public Zoo(int width = 100, int height = 100) {
		this.width = width;
		this.height = height;
		
		tiles = new Tile[width,height];
		
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				tiles[x,y] = new Tile(this, x, y);
			}
		}
		
		Debug.Log("World created with " +(width*height)+ " tiles.");
		
		CreateBuildingPrototypes();
	}
	
	void CreateBuildingPrototypes(){
		buildingPrototypes = new Dictionary<string, Building>();
		
		Building shopPrototype = Building.CreatePrototype("Shop",1,1);
		buildingPrototypes.Add("Shop", Building.CreatePrototype("Shop",1,1));
	}
	
	//access föggvény a coordináták eléréséhez
	public Tile GetTile(int x, int y) {
		if(x > width || x < 0 || y > height || y < 0) {
			//Debug.LogError("Tile ("+x+","+y+") is out of range.");
			return null;
		}
		return tiles[x,y];
	}
	
	//tile-ok randomizálása, CSAK TESZT!!!
	public void RandomizeTiles() {
		Debug.Log("RandomizeTiles()");
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				if(Random.Range(0, 2) == 0) {
					tiles[x,y].Type = Tile.TileType.EMPTY;
				}
				else {
					tiles[x,y].Type = Tile.TileType.ROUTE;
				}
			}
		}
	}
	
	public void GrasslandHabitBuild (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.GRASSHABIT2;
		tiles[x+2,y].Type = Tile.TileType.GRASSHABIT3;
		tiles[x,y+1].Type = Tile.TileType.GRASSHABIT4;
		tiles[x+1,y+1].Type = Tile.TileType.GRASSHABIT5;
		tiles[x+2,y+1].Type = Tile.TileType.GRASSHABIT6;
		tiles[x,y+2].Type = Tile.TileType.GRASSHABIT7;
		tiles[x+1,y+2].Type = Tile.TileType.GRASSHABIT8;
		tiles[x+2,y+2].Type = Tile.TileType.GRASSHABIT9;
		
	}
	
	public void DessertHabitBuild (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.DESSERTHABIT2;
		tiles[x+2,y].Type = Tile.TileType.DESSERTHABIT3;
		tiles[x,y+1].Type = Tile.TileType.DESSERTHABIT4;
		tiles[x+1,y+1].Type = Tile.TileType.DESSERTHABIT5;
		tiles[x+2,y+1].Type = Tile.TileType.DESSERTHABIT6;
		tiles[x,y+2].Type = Tile.TileType.DESSERTHABIT7;
		tiles[x+1,y+2].Type = Tile.TileType.DESSERTHABIT8;
		tiles[x+2,y+2].Type = Tile.TileType.DESSERTHABIT9;
		
	}
	
	public void DestroyHabit (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.EMPTY;
		tiles[x+2,y].Type = Tile.TileType.EMPTY;
		tiles[x,y+1].Type = Tile.TileType.EMPTY;
		tiles[x+1,y+1].Type = Tile.TileType.EMPTY;
		tiles[x+2,y+1].Type = Tile.TileType.EMPTY;
		tiles[x,y+2].Type = Tile.TileType.EMPTY;
		tiles[x+1,y+2].Type = Tile.TileType.EMPTY;
		tiles[x+2,y+2].Type = Tile.TileType.EMPTY;
	}
	
	public void PutRabbit (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.RABBIT2;
		tiles[x+2,y].Type = Tile.TileType.RABBIT3;
		tiles[x,y+1].Type = Tile.TileType.RABBIT4;
		tiles[x+1,y+1].Type = Tile.TileType.RABBIT5;
		tiles[x+2,y+1].Type = Tile.TileType.RABBIT6;
		tiles[x,y+2].Type = Tile.TileType.RABBIT7;
		tiles[x+1,y+2].Type = Tile.TileType.RABBIT8;
		tiles[x+2,y+2].Type = Tile.TileType.RABBIT9;
	}
	
	public void PutDeer (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.DEER2;
		tiles[x+2,y].Type = Tile.TileType.DEER3;
		tiles[x,y+1].Type = Tile.TileType.DEER4;
		tiles[x+1,y+1].Type = Tile.TileType.DEER5;
		tiles[x+2,y+1].Type = Tile.TileType.DEER6;
		tiles[x,y+2].Type = Tile.TileType.DEER7;
		tiles[x+1,y+2].Type = Tile.TileType.DEER8;
		tiles[x+2,y+2].Type = Tile.TileType.DEER9;	
	}
	
	public void PutMongoose (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.MONGOOSE2;
		tiles[x+2,y].Type = Tile.TileType.MONGOOSE3;
		tiles[x,y+1].Type = Tile.TileType.MONGOOSE4;
		tiles[x+1,y+1].Type = Tile.TileType.MONGOOSE5;
		tiles[x+2,y+1].Type = Tile.TileType.MONGOOSE6;
		tiles[x,y+2].Type = Tile.TileType.MONGOOSE7;
		tiles[x+1,y+2].Type = Tile.TileType.MONGOOSE8;
		tiles[x+2,y+2].Type = Tile.TileType.MONGOOSE9;
	}
	
	public void PutCamel (Tile tile_data){
		int x = tile_data.X;
		int y = tile_data.Y;
		tiles[x+1,y].Type = Tile.TileType.CAMEL2;
		tiles[x+2,y].Type = Tile.TileType.CAMEL3;
		tiles[x,y+1].Type = Tile.TileType.CAMEL4;
		tiles[x+1,y+1].Type = Tile.TileType.CAMEL5;
		tiles[x+2,y+1].Type = Tile.TileType.CAMEL6;
		tiles[x,y+2].Type = Tile.TileType.CAMEL7;
		tiles[x+1,y+2].Type = Tile.TileType.CAMEL8;
		tiles[x+2,y+2].Type = Tile.TileType.CAMEL9;
	}
	
	public bool EnoughtSpace (Tile tile_data) {
		int x = tile_data.X;
		int y = tile_data.Y;
		if(tiles[x+1,y].Type == Tile.TileType.EMPTY &&
			tiles[x+2,y].Type == Tile.TileType.EMPTY &&
			tiles[x,y+1].Type == Tile.TileType.EMPTY &&
			tiles[x+1,y+1].Type == Tile.TileType.EMPTY &&
			tiles[x+2,y+1].Type == Tile.TileType.EMPTY &&
			tiles[x,y+2].Type == Tile.TileType.EMPTY &&
			tiles[x+1,y+2].Type == Tile.TileType.EMPTY &&
			tiles[x+2,y+2].Type == Tile.TileType.EMPTY ){
				return true;
		}
		else return false;
	}
}


