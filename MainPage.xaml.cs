using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

#if DEBUG
using System.Diagnostics;
#endif
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409




namespace App1
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };
    DeviceWatcher deviceWatcher;

    public MainPage()
    {
      this.InitializeComponent();

      //deviceWatcher =
      //  DeviceInformation.CreateWatcher(
      //     BluetoothDevice.GetDeviceSelectorFromPairingState(true),
      //      requestedProperties,
      //      DeviceInformationKind.AssociationEndpoint);

      deviceWatcher =
        DeviceInformation.CreateWatcher(
           BluetoothDevice.GetDeviceSelectorFromPairingState(true));

      //deviceWatcher =
      //     DeviceInformation.CreateWatcher(
      //             BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
      //             requestedProperties,
      //             DeviceInformationKind.AssociationEndpoint);
      deviceWatcher.Added += DeviceWatcher_Added;
      deviceWatcher.Removed += DeviceWatcher_Removed;
      deviceWatcher.Updated += DeviceWatcher_Updated;
      deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
      deviceWatcher.Stopped += DeviceWatcher_Stopped;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (deviceWatcher.Status != DeviceWatcherStatus.Started)
          deviceWatcher.Start();
      }
      catch (Exception ex)
      {
#if DEBUG
        Debug.WriteLine($"deviceWatcher.Start, error:{ex}");
#endif
      }
    }

    private void ButtonStop_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (deviceWatcher.Status != DeviceWatcherStatus.Stopped)
          deviceWatcher.Stop();
      }
      catch (Exception ex)
      {
#if DEBUG
        Debug.WriteLine($"deviceWatcher.Stop, error:{ex}");
#endif
      }
    }

    private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
    {
#if DEBUG
      Debug.WriteLine("DeviceWatcher_Stopped");
#endif
    }

    private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
    {
#if DEBUG
      Debug.WriteLine("DeviceWatcher_EnumerationCompleted");
#endif

    }

    private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
    {
      Debug.WriteLine($"DeviceWatcher_Removed, {args.Id}");
    }

    private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
    {
      Debug.WriteLine($"DeviceWatcher_Removed, {args.Id}");
    }

    private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
    {
      Debug.WriteLine($"DeviceWatcher_Added, id: {args.Id}, name: {args.Name}, Kind: {args.Kind}");
    }

    private async void ButtonConnect_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        BluetoothLEDevice bluetoothLeDevice;
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-75:74:d3:9d:aa:73");
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-70:a9:b9:1c:80:94");
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-6b:6e:7a:3a:c1:da");
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-6a:ac:e9:a9:d5:fa");
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-57:59:da:9d:0e:39");
        bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync("BluetoothLE#BluetoothLEdc:85:de:1f:8d:db-48:fd:28:27:e8:9e");

        BluetoothDevice bluetoothDevice;
        bluetoothDevice = await BluetoothDevice.FromIdAsync("Bluetooth#Bluetoothdc:85:de:1f:8d:db-3c:f7:a4:87:75:aa");
        //bluetoothDevice = await BluetoothDevice.

      }
      catch (Exception ex)
      {
#if DEBUG
        Debug.WriteLine($"BluetoothDevice.FromIdAsync, error:{ex}");
#endif
      }
    }

    private async void Button4_Click(object sender, RoutedEventArgs e)
    {

      foreach (DeviceInformation deviceInformation in await DeviceInformation.FindAllAsync())
      {
      }
    }
  }
}
