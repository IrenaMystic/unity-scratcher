using UnityEngine;

public enum ItemType {
	Money,
	HeadStart,
	MegaHeadStart,
	Revival
}

[CreateAssetMenu]
public class Item : ScriptableObject {
	public int value;
	public ItemType type;
	public Sprite sprite;
	public Sprite spriteBig;
	public Sprite spriteDouble;
}
