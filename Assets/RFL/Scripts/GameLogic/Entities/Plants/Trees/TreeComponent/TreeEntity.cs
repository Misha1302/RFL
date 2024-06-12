namespace RFL.Scripts.GameLogic.Entities.Plants.Trees.TreeComponent
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository.DataContainers;
    using UnityEngine;

    [RequireComponent(typeof(TreeSaver))]
    [RequireComponent(typeof(TreeGrower))]
    public class TreeEntity : MonoBeh
    {
        private SceneName _sceneGrownName;
        public TreeData TreeData { get; private set; }

        public void Init(TreeData treeData)
        {
            TreeData = treeData;
            transform.position = treeData.position;

            GetComponent<TreeGrower>().Init(this);
            GetComponent<TreeSaver>().Init(this);
        }
    }
}