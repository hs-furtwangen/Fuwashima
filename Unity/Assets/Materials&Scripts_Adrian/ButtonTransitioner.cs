using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_normalColor = Color.white;
    public Color32 m_hoverColor = Color.grey;
    public Color32 m_Pressed = Color.white;

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_Image.color = m_hoverColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_Image.color = m_Pressed;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Image.color = m_hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Image.color = m_normalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

}