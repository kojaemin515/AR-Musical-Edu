using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHex = false;
    public BluetoothManager bluetoothManager;
    public string Messege;
    public async void OnSendButtonClick()
    {
        Debug.Log(Messege);
#if ENABLE_WINMD_SUPPORT
        if (bluetoothManager != null)
        {
            await bluetoothManager.SendMessageStringAsync(Messege);
        }
        else
        {
            Debug.LogError("BluetoothManager is not assigned.");
        }
#endif
    }

    // Update is called once per frame
}
