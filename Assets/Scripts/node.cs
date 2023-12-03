using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color hoverColor;

    public Color notEnoughMoneyColor;

    public Quaternion ajustes;
    
    public Vector3 positionOffset;
    
    private Renderer rend;

    private Color startColor;

[Header("Optional")]
    public GameObject currentTurret;
    BuildManager buildManager;

    //feedback cuando el mouse pasa sobre un nodo 
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        return;
        if(!buildManager.CanBuild)
        return;
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    
    //para que vulva a como estaba antes
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

public Vector3 GetBuildPosition()
{
    return transform.position + positionOffset;
}
    void OnMouseDown()
    {   
        
        if(EventSystem.current.IsPointerOverGameObject())
        return;
        if(!buildManager.CanBuild)
        return;

        if (currentTurret != null)
        {
            Debug.Log("Ya hay una torre ahi -TODO: Display on screen");
            return;
        }
        buildManager.BuildTurretOn(this);
    }
}
