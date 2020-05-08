namespace DGraph.Data
{
  using UnityEngine;

  [CreateAssetMenu(fileName = "CharacterObject", menuName = "DGraph/Character", order = 0)]
	public class CharacterObject : ScriptableObject
	{
		public string id;
		public string charName;
		public Sprite sprite;
		public Color color;

		public Character GetCharacter()
		{
			return new Character(this.id, this.charName, this.sprite, this.color);
		} 
	}
}
