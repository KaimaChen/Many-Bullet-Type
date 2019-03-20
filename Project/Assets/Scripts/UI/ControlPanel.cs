﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public Button BtnFire;
    public Dropdown BulletDropdown;
    public Transform Enemy;
    
    void Awake()
    {
        List<Dropdown.OptionData> optionDatas = new List<Dropdown.OptionData>()
        {
            new Dropdown.OptionData("普通子弹"),
            new Dropdown.OptionData("跟踪子弹"),
            new Dropdown.OptionData("进停子弹"),
            new Dropdown.OptionData("抛物线子弹"),
        };

        BulletDropdown.AddOptions(optionDatas);

        BtnFire.onClick.AddListener(OnFire);
    }
    
    void OnFire()
    {
        int index = BulletDropdown.value;
        switch(index)
        {
            case 0:
                LoadBullet("NormalBullet");
                break;
            case 1:
                GameObject go = LoadBullet("FollowBullet");
                go.GetComponent<FollowBullet>().DoStart(Enemy, 10);
                break;
            case 2:
                GameObject go2 = LoadBullet("MoveStopBullet");
                break;
            case 3:
                GameObject go3 = LoadBullet("ParabolaBullet");
                go3.GetComponent<ParabolaBullet>().DoStart(5, 1, Enemy.position);
                break;
        }
    }

    GameObject LoadBullet(string name)
    {
        GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + name + ".prefab");
        GameObject go = Instantiate(prefab);
        go.transform.position = Vector3.zero;
        go.transform.rotation = Camera.main.transform.rotation;
        return go;
    }
}
