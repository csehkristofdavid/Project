using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
	//a tile-ok 2 féle értéket vehetnek fel, ha üres építhetünk
	//rá ha pedig út akkor az mellé építhetünk
    public enum TileType {EMPTY, ROUTE, SHOP, GRASSHABIT1, GRASSHABIT2, GRASSHABIT3, GRASSHABIT4, GRASSHABIT5, GRASSHABIT6, GRASSHABIT7, GRASSHABIT8, GRASSHABIT9,
							DESSERTHABIT1, DESSERTHABIT2, DESSERTHABIT3, DESSERTHABIT4, DESSERTHABIT5, DESSERTHABIT6, DESSERTHABIT7, DESSERTHABIT8, DESSERTHABIT9,
							RABBIT1, RABBIT2, RABBIT3, RABBIT4, RABBIT5, RABBIT6, RABBIT7, RABBIT8, RABBIT9, DEER1, DEER2, DEER3, DEER4, DEER5, DEER6, DEER7, DEER8, DEER9,
							MONGOOSE1, MONGOOSE2, MONGOOSE3, MONGOOSE4, MONGOOSE5, MONGOOSE6, MONGOOSE7, MONGOOSE8, MONGOOSE9,
							CAMEL1, CAMEL2, CAMEL3, CAMEL4, CAMEL5, CAMEL6, CAMEL7, CAMEL8, CAMEL9};
	
	TileType type = TileType.EMPTY;
	
	Action<Tile> tileTypeChangedCB;
	
	public TileType Type {
		get {
			return type;
		}
		set {
			TileType oldType = type;
			type = value;
			//callback! jelezzük, hogy megváltozott
			if(tileTypeChangedCB != null && oldType != type){
				tileTypeChangedCB(this);
			}
		}
	}
	
	Building buildingObject;
	Animal animalObject;
	
	Zoo zoo;
	int x; 
	int y;
	
	public int X {
		get {
			return x;
		}
	}
	
	public int Y {
		get {
			return y;
		}
	}
	
	//tile contructor
	public Tile(Zoo zoo, int x, int y) {
		this.zoo = zoo;
		this.x = x;
		this.y = y;
	}
	
	public void RegisterTileTypeChangedCallback(Action<Tile> callback){
		tileTypeChangedCB += callback;
	}
	
	public void UnregisterTileTypeChangedCallback(Action<Tile> callback){
		tileTypeChangedCB -= callback;
	}
	
	public bool PlaceObject(Building ob){
		if(ob == null){
			buildingObject = null;
			return true;
		}
		
		if(buildingObject != null){
			Debug.LogError("Trying to assign a building to a tile that already has one");			
			return false;
		}
		 buildingObject = ob;
		 return true;
	}
}
