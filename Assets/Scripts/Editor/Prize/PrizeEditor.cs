using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Prize))]
public class PrizeEditor : Editor
{
	public enum EditorType
	{
		PrizeCollectionAsset
	}

	public EditorType editorType;

	public bool showPrize;

	public SerializedProperty prizesProperty;

	private Prize prize;

	private const float buttonWidth = 30;

	private void OnEnable ()
	{
		prize = (Prize)target;

		if (target == null) {
			DestroyImmediate (this);
			return;
		}
	}

	public override void OnInspectorGUI ()
	{
		switch (editorType) {
		case EditorType.PrizeCollectionAsset:
			PrizeCollectionGUI ();
			break;
		default:
			PrizeGUI ();
			break;
		}
	}

	private void PrizeCollectionGUI ()
	{
		EditorGUILayout.BeginVertical (GUI.skin.box);
		EditorGUI.indentLevel++;

		EditorGUILayout.BeginHorizontal ();
		showPrize = EditorGUILayout.Foldout (showPrize, "Prize " + prize.id);
		if (GUILayout.Button ("-", GUILayout.Width (buttonWidth))) {
			PrizeCollectionEditor.RemovePrize (prize);
		}
		EditorGUILayout.EndHorizontal ();

		if (showPrize) {
			PrizeGUI ();
		}

		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical ();
	}

	private void PrizeGUI ()
	{
		DrawDefaultInspector ();
	}

	public static Prize CreatePrize ()
	{
		return CreateInstance<Prize> ();
	}
}
