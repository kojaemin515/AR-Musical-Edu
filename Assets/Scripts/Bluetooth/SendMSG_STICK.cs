using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMSG_STICK : MonoBehaviour
{
    public BluetoothManager bluetoothmanager;
    public string Message_drum ;  
    public string Message_cymbals;  

    // Start is called before the first frame update
    void Start()
    {

    }

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BluetoothTrigger_drum>() != null)
        {
            Debug.Log("DRUM!");
#if ENABLE_WINMD_SUPPORT
            if (bluetoothmanager != null)
            {
                    await bluetoothmanager.SendMessageHexAsync(Message_drum);
            }
            else
            {
                Debug.Log("Bluetooth Device is Mising...");
            }
#endif
        }
        if(collision.gameObject.GetComponent<BluetoothTrigger_Cymbals>() != null) 
        {
            Debug.Log("CYMBALS!");
#if ENABLE_WINMD_SUPPORT
            if (bluetoothmanager != null)
            {
                    await bluetoothmanager.SendMessageHexAsync(Message_cymbals);
            }
            else
            {
                Debug.Log("Bluetooth Device is Mising...");
            }
#endif
        }
    }
}
