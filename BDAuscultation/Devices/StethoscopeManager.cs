using MMM.HealthCare.Scopes.Device;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MockDevices = BDAuscultation.Devices.Mock;

namespace BDAuscultation.Devices
{
    public class StethoscopeManager
    {
//#if DEBUG
//        public static IEnumerable<MockDevices.Stethoscope> StethoscopeList = GetStethoscopeDevices();
//#else
        public static IEnumerable<Stethoscope> StethoscopeList=GetStethoscopeDevices();
//#endif

//#if DEBUG
        //public static IEnumerable<MockDevices.Stethoscope> GetStethoscopeDevices()
        //{
        //    try
        //    {
        //        MockDevices.Stethoscope[] devices = {
        //            new Mock.Stethoscope {
        //                 Name = "M3200 0015110001453469",
        //                  Filter = Filter.Bell,
        //                   BatteryLevel =2,
        //                    BuiltInDisplay  = BuiltInDisplay.Bluetooth,
        //                      IsConnected = false,
        //                       IsAutoBluetoothOn = false,
        //                        IsFilterButtonEnabled = true,
        //                         ModelNumber = "10579",
        //                          SerialNumber = "SN-1231",
        //                           TotalBytesRead =4890,
        //                            TotalBytesWritten = 302918,
        //            }
        //        };
        //        return devices;
        //    }
        //    catch (PlatformNotSupportedException)
        //    {
        //        throw new Exception("找不到电脑中的听诊器， 请确认蓝牙设备已经开启！");
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("取得听诊器失败！");
        //    }

        //}
//#else
        public static IEnumerable<Stethoscope> GetStethoscopeDevices()
        {

            try
            {
                IBluetoothManager manager = ConfigurationFactory.GetBluetoothManager();
                return manager.GetPairedDevices();
            }
            catch (PlatformNotSupportedException)
            {
                throw new Exception("找不到电脑中的听诊器， 请确认蓝牙设备已经开启！");
            }
            catch (Exception)
            {
                throw new Exception("取得听诊器失败！");
            }

        }
//#endif


    }

}

