using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

#if ENABLE_WINMD_SUPPORT
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
#endif

public class BluetoothManager : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    private RfcommDeviceService _service;
    private StreamSocket _socket;
    private DataReader _dataReader;
    private DataWriter _dataWriter;
#endif
#if ENABLE_WINMD_SUPPORT
    private async void Start()
    {
        UnityEngine.Debug.Log("Start!");
        await InitializeBluetoothAsync();
    }
#endif
#if ENABLE_WINMD_SUPPORT
    private void OnDestroy()
    {
        _dataReader?.DetachStream();
        _dataWriter?.DetachStream();
        _socket?.Dispose();
    }

    private async Task InitializeBluetoothAsync()
    {
        try
        {
            var selector = RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort);
            var devices = await DeviceInformation.FindAllAsync(selector);

            if (devices.Count > 0)
            {
                UnityEngine.Debug.Log("Devices found: " + devices.Count);
                foreach (var device in devices)
                {
                    UnityEngine.Debug.Log("Device Name: " + device.Name);
                    UnityEngine.Debug.Log("Device Id: " + device.Id);
                }

                var deviceId = devices[0].Id;
                _service = await RfcommDeviceService.FromIdAsync(deviceId);

                if (_service != null)
                {
                    UnityEngine.Debug.Log("Connecting to device...");
                    await ConnectToDeviceAsync(_service);
                }
                else
                {
                    UnityEngine.Debug.Log("Failed to get RfcommDeviceService.");
                }
            }
            else
            {
                UnityEngine.Debug.Log("No devices found.");
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"InitializeBluetoothAsync Error: {ex.Message}");
        }
    }

    private async Task ConnectToDeviceAsync(RfcommDeviceService service)
    {
        try
        {
            _socket = new StreamSocket();
            await _socket.ConnectAsync(service.ConnectionHostName, service.ConnectionServiceName, SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);

            _dataReader = new DataReader(_socket.InputStream);
            _dataWriter = new DataWriter(_socket.OutputStream);

            UnityEngine.Debug.Log("Successfully connected to the device.");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"ConnectToDeviceAsync Error: {ex.Message}");
        }
    }

    public async Task SendMessageHexAsync(string message)
    {
        if (_dataWriter != null)
        {
            string[] hexValuesSplit = message.Split(' ');
            byte[] bytes = new byte[hexValuesSplit.Length];

            for (int i = 0; i < hexValuesSplit.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexValuesSplit[i], 16);
            }
            _dataWriter.WriteBytes(bytes.AsSpan(0, bytes.Length).ToArray());
            await _dataWriter.StoreAsync();

            UnityEngine.Debug.Log("Message sent: " + message);
        }
        else
        {
            UnityEngine.Debug.LogError("DataWriter is not initialized.");
        }
    }

    public async Task SendMessageStringAsync(string message)
    {
        if (_dataWriter != null)
        {
            _dataWriter.WriteString(message);
            await _dataWriter.StoreAsync();
            UnityEngine.Debug.Log("Message sent: " + message);
        }
        else
        {
            UnityEngine.Debug.LogError("DataWriter is not initialized.");
        }
    }
#endif
}
