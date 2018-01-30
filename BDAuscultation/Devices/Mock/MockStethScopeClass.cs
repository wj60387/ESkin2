using MMM.HealthCare.Scopes.Device;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BDAuscultation.Devices.Mock
{
    public class Stethoscope :  IComparable<Stethoscope>, IComparable, IDisposable
    {
        public int ActiveTimeoutDeciseconds { get; set; }
        public Stream AudioInputStream { get; set; }
        public Stream AudioOutputStream { get; set; }
        public int AutomaticOffTimeoutDeciseconds { get; set; }
        public int BacklightTimeoutDeciseconds { get; set; }
        public int BatteryLevel { get; set; }
        public int BluetoothPairTimeoutDeciseconds { get; set; }
        public int BluetoothTimeoutDeciseconds { get; set; }
        public BuiltInDisplay BuiltInDisplay { get; set; }
        public long BytesReadPerSecond { get; set; }
        public long BytesWrittenPerSecond { get; set; }
        public Bitmap Display { get; set; }
        public Filter Filter { get; set; }
        public int FineGain { get; set; }
        public double FirmwareVersion { get; set; }
        public bool IsAutoBluetoothOn { get; set; }
        public bool IsConnected { get; set; }
        public bool IsFilterButtonEnabled { get; set; }
        public bool IsMButtonEnabled { get; set; }
        public bool IsPlusAndMinusButtonsEnabled { get; set; }
        public bool IsULawEncoded { get; set; }
        public string ModelNumber { get; set; }
        public string Name { set;  get; }
        public int RawOutputGainStep { get; set; }
        public string SerialNumber { get; set; }
        public int SleepTimeoutMinutes { get; set; }
        public int SoundAmplificationLevel { get; set; }
        public Filter StartUpFilter { get; set; }
        public int StartUpGainStep { get; set; }
        public int StartUpSoundAmplificationLevel { get; set; }
        public IList<StethoscopeTrack> StethoscopeTracks { get; set; }
        public long TotalBytesRead { get; set; }
        public long TotalBytesWritten { get; set; }

        public event EventHandler Disconnected;
        public event EventHandler EndOfInputStream;
        public event EventHandler EndOfOutputStream;
        public event EventHandler<MMM.HealthCare.Scopes.Device.ErrorEventArgs> Error;
        public event EventHandler<ButtonEventArgs> FilterButtonDown;
        public event EventHandler FilterButtonUp;
        public event EventHandler LowBatteryLevel;
        public event EventHandler<ButtonEventArgs> MButtonDown;
        public event EventHandler MButtonUp;
        public event EventHandler<ButtonEventArgs> MinusButtonDown;
        public event EventHandler MinusButtonUp;
        public event EventHandler<ButtonEventArgs> OnAndOffButtonDown;
        public event EventHandler OnAndOffButtonUp;
        public event EventHandler<OutOfRangeEventArgs> OutOfRange;
        public event EventHandler<ButtonEventArgs> PlusButtonDown;
        public event EventHandler PlusButtonUp;
        public event EventHandler<UnderrunOrOverrunEventArgs> UnderrunOrOverrun;

        public int CompareTo(Stethoscope otherStethoscope)
        {
            return this.Name.Equals(otherStethoscope.Name) ? 1 : 0;
        }
        public int CompareTo(object obj)
        {
            return ((Stethoscope)this).Name.Equals(((Stethoscope)obj).Name) ? 1 : 0;
        }
        public void Connect() { }
        public void Disconnect() { }
        public void Dispose() { }
        public void SetDisplay(string filePath) { }
        public void SetDisplay(Stream bitmapStream) { }
        public void StartAudioInput() { }
        public void StartAudioInput(AudioInputSwitch filterType) { }
        public void StartAudioOutput() { }
        public void StartAudioOutput(AudioOutputSwitch filterType, HeadsetAudioSource selectorMode) { }
        public void StartDownloadTrack() { }
        public void StartDownloadTrack(int trackIndex, AudioType audioType) { }
        public void StartUploadTrack() { }
        public void StartUploadTrack(int trackIndex, AudioType audioType) { }
        public void StopAudioInput() { }
        public void StopAudioInputAndOutput() { }
        public void StopAudioOutput() {  }
        public void StopDownloadTrack() { }
        public void StopUploadAndDownloadTrack() { }
        public void StopUploadTrack() { }
        public override string ToString() { return this.ToString(); }
    }
}
