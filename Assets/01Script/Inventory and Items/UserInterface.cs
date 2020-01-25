using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public abstract class UserInterface : MonoBehaviour
{

    public InventoryObject inventory;

    public Dictionary<GameObject, InventorySlot> SlotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    private void Start()
    {
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }

        CreateSlots();

        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    private void OnSlotUpdate(InventorySlot _slot)
    {

        if (_slot.item.Id >= 0)
        {
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.BaseItem.icon;
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            _slot.slotDisplay.GetComponentInChildren<TextMeshProUGUI>().text = _slot.amount == 1 ? "" : _slot.amount.ToString("n0");
        }
        else
        {
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
            _slot.slotDisplay.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            _slot.slotDisplay.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    //private void Update()
    //{
    //    SlotsOnInterface.UpdateSlotDisplay();
    //}

    public abstract void CreateSlots();

    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }
    public void OnEnter(GameObject obj)
    {
        MouseData.SlotHoveredOver = obj;       
    }

    public void OnExit(GameObject obj)
    {
        MouseData.SlotHoveredOver = null;
    }

    public void OnBeginDrag(GameObject obj)
    {
        MouseData.TempItemBeingDraged = CreateTempItem(obj);
    }
    public GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if(SlotsOnInterface[obj].item.Id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = SlotsOnInterface[obj].BaseItem.icon;
            img.raycastTarget = false;
        }
        return tempItem;
    }
    public void OnEndDrag(GameObject obj)
    {
        Destroy(MouseData.TempItemBeingDraged);

        if(MouseData.interfaceMouseIsOver == null)
        {
            SlotsOnInterface[obj].RemoveItem();
            return;
        }
        if (MouseData.SlotHoveredOver)
        {
            InventorySlot mousesHoverSlotData = MouseData.interfaceMouseIsOver.SlotsOnInterface[MouseData.SlotHoveredOver];
            inventory.SwapItems(SlotsOnInterface[obj], mousesHoverSlotData);
        }
    }

    public void OnDrag(GameObject obj)
    {
        if (MouseData.TempItemBeingDraged != null)
            MouseData.TempItemBeingDraged.GetComponent<RectTransform>().position = Input.mousePosition;

    }
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
}

public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;

    public static GameObject TempItemBeingDraged;

    public static GameObject SlotHoveredOver;
}

public static class ExtentionMeathod
{
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InventorySlot> _slotsOnInterface)
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in _slotsOnInterface)
        {
            if (_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.Value.BaseItem.icon;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
}
