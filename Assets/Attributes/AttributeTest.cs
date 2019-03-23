using UnityEngine;
using Nirvana.Attributes;

public class AttributeTest : MonoBehaviour
{
    [FolderPath]
    public string folder;

    [FolderPath]
    public int folderInt;

    [Tag]
    public string tagSelector;

    [Tag]
    public int tagSelector2;

    [SceneName]
    public string scene;

    [ReadOnly]
    public int readOnly = 10;

    [Label("Label Test1")]
    public int a = 10;

    [Label("Label Test2")]
    public string b = "jagsd";

    [InfoBox("InfoBox Test", InfoBoxAttribute.MessageType.Info)]
    public Vector3 infoBox;
}