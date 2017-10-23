using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(PrizeCollection))]
public class PrizeCollectionEditor : Editor
{
	private static PrizeCollection prizeCollection;

	private PrizeEditor[] prizeEditors;

	private const float buttonWidth = 100f;

	private void OnEnable ()
	{
		prizeCollection = (PrizeCollection)target;

		if (prizeEditors == null) {
			CreateEditors ();
		}
	}

	private void OnDisable ()
	{
		for (int i = 0; i < prizeEditors.Length; i++) {
			DestroyImmediate (prizeEditors [i]);
		}

		prizeEditors = null;
	}

	public override void OnInspectorGUI ()
	{
		if (prizeEditors.Length != prizeCollection.prizes.Length)
		{
			for (int i = 0; i < prizeEditors.Length; i++)
			{
				DestroyImmediate(prizeEditors[i]);
			}
				
			CreateEditors ();
		}

		for (int i = 0; i < prizeEditors.Length; i++) {
			prizeEditors [i].OnInspectorGUI ();
		}	

		if (prizeEditors.Length > 0) {
			EditorGUILayout.Space ();
			EditorGUILayout.Space ();
		}
			

		if (GUILayout.Button ("Add New Prize", GUILayout.Width(buttonWidth))) {
			AddPrize ();
		}
	}

	private void AddPrize() {
		Prize newPrize = PrizeEditor.CreatePrize ();
		newPrize.id = prizeCollection.prizes.Length;

		Undo.RecordObject(newPrize, "Created new prize");

		AssetDatabase.AddObjectToAsset(newPrize, prizeCollection);

		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newPrize));

		ArrayUtility.Add(ref prizeCollection.prizes, newPrize);

		EditorUtility.SetDirty(prizeCollection);
	}

	public static void RemovePrize(Prize removePrize) {
		ArrayUtility.Remove(ref prizeCollection.prizes, removePrize);

		DestroyImmediate(removePrize, true);

		AssetDatabase.SaveAssets();

		EditorUtility.SetDirty(prizeCollection);
	}

	private void CreateEditors ()
	{
		prizeEditors = new PrizeEditor[prizeCollection.prizes.Length];
		for (int i = 0; i < prizeEditors.Length; i++) {
			prizeEditors [i] = CreateEditor (prizeCollection.prizes [i]) as PrizeEditor;
		}
	}
}
