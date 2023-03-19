using UnityEngine;
using UnityEditor.PackageManager.UI;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Class)]
public class ProjectMapImportant : PropertyAttribute { }

public class ProjectMap : EditorWindow
{
    private struct ScriptCategories
    {
        public string Title;
        public Color Color;

        public ScriptCategories(string title, Color color)
        {
            Title = title;
            Color = color;
        }
    }

    private const string ProjectPrefix = "BalloonSurfer";
    private const int ColumnsCount = 5;
    private Dictionary<string, List<Type>> _scriptTypes = new Dictionary<string, List<Type>>();

    private List<Type> _allTypes = null;
    private List<Type> _unsortedTypes = null;

    private Vector2 scrollPosition;
    private GUIStyle _richText;
    private GUIStyle _baseStyle;

    private List<ScriptCategories> _scriptCategories = null;
    private List<string> _importantClasses = null;

    #region API

    [MenuItem("Window/Project Map")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ProjectMap));
    }

    private void OnEnable()
    {
        _richText = new GUIStyle { richText = true, alignment = TextAnchor.UpperCenter };

        _scriptCategories = new List<ScriptCategories>
        {
            new ScriptCategories("Core", new Color(0.75f, 1f, 1f)),
            new ScriptCategories("Helpers", Color.white),
            new ScriptCategories("Creators", Color.white),
            new ScriptCategories("UI", new Color(1f, 1f, 0.55f)),

            new ScriptCategories("Components", Color.white),
            new ScriptCategories("Systems", Color.white),
            new ScriptCategories("InitData", Color.white),
            new ScriptCategories("EntitySources", Color.white),
        };

        _importantClasses = new List<string>
        {
            "GameLoader",
            "EntityCreator",
            "MainData",
            "SharedData",
            "EntitySource"
        };

        InitMap();
    }

    #endregion

    void OnGUI()
    {
        _baseStyle = new GUIStyle(GUI.skin.GetStyle("Button"))
        {
            richText = true
        };

        GUI.backgroundColor = Color.white;
        ShowErrorMessage();

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandWidth(true));

        DrawAreas(0, 4);    //Unity
        DrawAreas(4, 4);    //Ecs

        //Unsorted
        if (_unsortedTypes != null && _unsortedTypes.Count > 0)
        {
            GUI.backgroundColor = new Color(1f, 0.75f, 0.75f);
            GUILayout.Label("<color=red><b>Unsorted</b></color>", _richText);
            DrawGrid(_unsortedTypes, string.Empty);
            GUI.backgroundColor = Color.white;
        }

        GUILayout.EndScrollView();
    }

    private void InitMap()
    {
        var assembly = System.AppDomain.CurrentDomain.GetAssemblies().First(x => x.FullName == "Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
        _allTypes = assembly.GetTypes().Where(x => !x.Name.Contains('<')).ToList();
        _unsortedTypes = new List<Type>(_allTypes);

        foreach (var category in _scriptCategories)
        {
            var types = _allTypes.Where(t => string.Equals(t.Namespace, $"{ProjectPrefix}.{category.Title}", StringComparison.Ordinal)).ToList();
            _scriptTypes[category.Title] = types;
            _unsortedTypes.RemoveAll(x => _scriptTypes[category.Title].Contains(x));
        }
    }

    #region Draw elements

    private void ShowErrorMessage()
    {
        if (_unsortedTypes != null && _unsortedTypes.Count > 0)
        {
            string errorText = _unsortedTypes.Count > 0
                ? $"<color=red>Unsorted classes: {_unsortedTypes.Count}</color>"
                : $"<color=green>Unsorted classes: {_unsortedTypes.Count}</color>";
            GUILayout.Label(errorText, _richText);
        }
        GUILayout.Space(20);
    }

    private void DrawGrid(int categoryIndex)
    {
        if (_scriptCategories.Count > categoryIndex && _scriptTypes.ContainsKey(_scriptCategories[categoryIndex].Title))
        {
            GUILayout.Label($"<b>{_scriptCategories[categoryIndex].Title}</b>", _richText);
            DrawGrid(_scriptTypes[_scriptCategories[categoryIndex].Title], _scriptCategories[categoryIndex].Title);
        }
        GUILayout.Space(20);
    }

    private void DrawGrid(List<Type> types, string category)
    {
        int rowsCount = (int)Math.Ceiling((double)types.Count / ColumnsCount);
        int columnsCount = types.Count > ColumnsCount ? ColumnsCount : types.Count;

        GUILayout.BeginHorizontal();
        for (int i = 0; i < columnsCount; i++)
        {
            GUILayout.BeginVertical(GUILayout.Width(position.width / columnsCount));
            for (int j = 0; j < rowsCount; j++)
            {
                if (j * ColumnsCount + i < types.Count)
                {
                    DrawButton(types[j * ColumnsCount + i], category);
                }
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();
    }

    private void DrawAreas(int startsFrom, int columns)
    {
        int index = 0;
        GUILayout.BeginHorizontal();

        for (int i = startsFrom; i < startsFrom + columns; i++)
        {
            if (_scriptCategories.Count > i && _scriptTypes.ContainsKey(_scriptCategories[i].Title))
            {
                GUI.backgroundColor = _scriptCategories[i].Color;
                GUILayout.BeginVertical(GUILayout.MinWidth(position.width / columns));

                GUILayout.Label($"<b>{_scriptCategories[i].Title}</b>", _richText);
                foreach (var script in _scriptTypes[_scriptCategories[i].Title])
                {
                    DrawButton(script, _scriptCategories[i].Title);
                }

                GUILayout.EndVertical();
                GUI.backgroundColor = Color.white;
            }
            index++;
        }

        GUILayout.EndHorizontal();
        GUILayout.Space(20);
    }

    private void DrawButton(Type script, string category)
    {
        string buttonTitle = script.Name;

        if (_importantClasses.Contains(script.Name))
        {
            buttonTitle = $"<b>{script.Name}</b>";
        }


        if (GUILayout.Button(buttonTitle, _baseStyle))
        {
            var guids = AssetDatabase.FindAssets(script.Name, new[] { $"Assets/Scripts" });

            if ((guids == null || guids.Length == 0) && !string.IsNullOrEmpty(category))
            {
                var split = category.Split('.');
                if (split.Length > 1)
                {
                    string postfix = split[1];
                    guids = AssetDatabase.FindAssets(postfix, new[] { $"Assets/Scripts" });
                }
            }

            if (guids != null && guids.Length > 0)
            {
                var asset = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]));
                AssetDatabase.OpenAsset(asset);
            }
        }
    }

    #endregion

}
#endif
