using UnityEngine;
using System.Collections;

public class BaseItem {

	#region Variables, Constants & Initializers

	public string id;
	public string baseName;
	public string imageName;
	public bool isLocked;
	public int price;

	#endregion
	
	public BaseItem()
	{
		
	}
	
	public BaseItem (string id, string baseName, string imageName, bool isLocked, int price)
	{
		this.id = id;
		this.baseName = baseName;
		this.imageName = imageName;
		this.isLocked = isLocked;
		this.price = price;
	}

	public virtual string getGridImagePath()
	{
		string path = "GridItems/"+ this.baseName + "/" + this.imageName;
		return path;
	}

	public virtual string getInGameImageName()
	{
		return this.baseName + "/" + this.imageName;
	}
}
