using System.ComponentModel.Design;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

/*

public class MenuTest : MonoBehaviour
{

    
    private string mainMenuName = "Helper system";
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("Helper system/Do Something")]
    static void DoSomething()
    {
        Debug.Log("Doing Something...");
    }

    // Validated menu item.
    // Add a menu item named "Log Selected Transform Name" to MyMenu in the menu bar.
    // We use a second function to validate the menu item
    // so it will only be enabled if we have a transform selected.
    [MenuItem("Helper system/Log Selected Transform Name")]
    static void LogSelectedTransformName()
    {
        Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
    }

    // Validate the menu item defined by the function above.
    // The menu item will be disabled if this function returns false.
    [MenuItem("Helper system/Log Selected Transform Name", true)]
    static bool ValidateLogSelectedTransformName()
    {
        // Return false if no transform is selected.
        return Selection.activeTransform != null;
    }

    // Add a menu item named "Do Something with a Shortcut Key" to MyMenu in the menu bar
    // and give it a shortcut (ctrl-g on Windows, cmd-g on macOS).
    [MenuItem("Helper system/Do Something with a Shortcut Key %g")]
    static void DoSomethingWithAShortcutKey()
    {
        Debug.Log("Doing something with a Shortcut Key...");
    }

    // Add a menu item called "Double Mass" to a Rigidbody's context menu.
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }


    // Add a menu item to create custom GameObjects.
    // Priority 10 ensures it is grouped with the other menu items of the same kind
    // and propagated to the hierarchy dropdown and hierarchy context menus.
    [MenuItem("GameObject/helpersystem/Help trigger", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        // GameObject go = new GameObject("Help trigger");

        GameObject myPrefab =(GameObject)AssetDatabase.LoadAssetAtPath("Assets/help module/helperTrigger.prefab", typeof(GameObject));
        Debug.Log(myPrefab);

        
        
        GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(myPrefab);
        

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
        
    }*/

 class HelperSystem : EditorWindow
{

    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myTimeout = 1.23f;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Helper system/trigger manager")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(HelperSystem));
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
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
        Debug.Log(myPrefab);



        GameObject helpTrigger = (GameObject)PrefabUtility.InstantiatePrefab(myPrefab);

        helpTrigger.GetComponent<HelpTrigger>().sittuation = "test sitt";

        helpTrigger.GetComponent<HelpTrigger>().storyLine = true;

        helpTrigger.GetComponent<HelpTrigger>().triggerOnce = true;

        helpTrigger.GetComponent<HelpTrigger>().contextualHints = true;

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