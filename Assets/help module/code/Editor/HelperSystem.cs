using System.ComponentModel.Design;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

 class HelperSystem : EditorWindow
{
    private string mySitt = "";
    bool groupEnabled;
    bool myStoryLine = true;
    bool myTriggerOnce = true;
    bool myContextualHints = true;

    float myTimeout = 2f;


   


    // Add menu item named "My Window" to the Window menu
    [MenuItem("Helper system/trigger manager")]
    public static void ShowWindow()
    {

        // mySitt = "found";
    

        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(HelperSystem));
    }

    void OnGUI()
    {

       
      

        GUILayout.Label("Trigger Settings", EditorStyles.boldLabel);

        mySitt = EditorGUILayout.TextField("Sittuation", mySitt);


        groupEnabled = EditorGUILayout.BeginToggleGroup("Customize Settings", groupEnabled);

        myStoryLine = EditorGUILayout.Toggle("Story line help", myStoryLine);

        myTriggerOnce = EditorGUILayout.Toggle("Trigger story line once", myTriggerOnce);

        myContextualHints = EditorGUILayout.Toggle("Contextual hints", myContextualHints);



        myTimeout = EditorGUILayout.Slider("Timeout period in seconds", myTimeout, 0, 120);
          EditorGUILayout.EndToggleGroup();
        
   
        if (GUILayout.Button("Add trigger"))
        {
            AddTrigger();
        }
  
}


    void AddTrigger()
    {
        // Create a custom game object
        // GameObject go = new GameObject("Help trigger");

        GameObject myPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/help module/helperTrigger.prefab", typeof(GameObject));
      

        GameObject helpTrigger = (GameObject)PrefabUtility.InstantiatePrefab(myPrefab);

        helpTrigger.GetComponent<HelpTrigger>().sittuation = "test sitt";

        helpTrigger.GetComponent<HelpTrigger>().storyLine = myStoryLine;

        helpTrigger.GetComponent<HelpTrigger>().triggerOnce = myTriggerOnce;

        helpTrigger.GetComponent<HelpTrigger>().contextualHints = myContextualHints;

        helpTrigger.GetComponent<HelpTrigger>().WaitPeriod = myTimeout;


        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        // GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(helpTrigger, "Create " + myPrefab.name);
        Selection.activeObject = helpTrigger;

    }

}


/*
 *  public string sittuation = "test";

    [Header("Show storyline help first")]
    public bool storyLine = true;

    [Header("Show storyline once in app liftime")]
    public bool triggerOnce = true;

    [Header("Show contextual hints")]
    public bool contextualHints = true;

    [Header("Timeout period for help trigger")]
    [Tooltip("in seconds")]
    public float WaitPeriod = 2;
*/