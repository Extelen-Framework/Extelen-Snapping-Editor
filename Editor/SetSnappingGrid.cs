using UnityEngine;
using UnityEditor;

public class SetSnappingGrid : EditorWindow {

    private static float m_gridSnapX = 0.0f;
    private static float m_gridSnapY = 0.0f;

    [MenuItem("Snapping/Set Snap Settings")]
    private static void Init() {

        Rect r = new Rect(10, 10, 200, 86);
        SetSnappingGrid window = EditorWindow.GetWindowWithRect<SetSnappingGrid>(r, false, "Set Snapping Grid");
        window.Show();
    	}

    private void Awake() {

        m_gridSnapX = EditorPrefs.GetFloat("MoveSnapX", m_gridSnapX);
        m_gridSnapY = EditorPrefs.GetFloat("MoveSnapY", m_gridSnapY);
    	}

    private void OnGUI() {

        m_gridSnapX = EditorGUILayout.FloatField(m_gridSnapX);
        m_gridSnapY = EditorGUILayout.FloatField(m_gridSnapY);

        if (GUILayout.Button("Save into Editor Prefs")) {

            EditorPrefs.SetFloat("MoveSnapX", m_gridSnapX);
            EditorPrefs.SetFloat("MoveSnapY", m_gridSnapY);

            Debug.Log("The new snap values (" + m_gridSnapX + ", " + m_gridSnapY + ") have been saved into the Editor Prefs.");
            this.Close();
	        }
        
		if (GUILayout.Button("Close")) {

            this.Close();
			}
		}
	}
	