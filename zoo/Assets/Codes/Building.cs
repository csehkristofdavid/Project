using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
	Tile tile;
	string objectType;
	
	int witdth;
	int height;
	
	protected Building(){
		
	}
	
	static public Building CreatePrototype(string objectType, int witdth = 1, int height = 1){
		Building ob = new Building();
		
		ob.objectType = objectType;
		ob.witdth = witdth;
		ob.height = height;
		
		return ob;
	}
	
	static public Building PlaceInstance(Building building_ob, Tile tile){
		Building ob = new Building();
		
		ob.objectType = building_ob.objectType;
		ob.witdth = building_ob.witdth;
		ob.height = building_ob.height;
		ob.tile = tile;
		
		if(tile.PlaceObject(ob) == false){
			return null;
		}
		
		return ob;
	}
}
