using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout)
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

            if (foldout)
            {
                Editor editor = CreateEditor(settings);
                editor.OnInspectorGUI();

                if (check.changed && onSettingsUpdated != null)
                    onSettingsUpdated();
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
