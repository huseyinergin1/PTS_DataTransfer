using System;
using System.Collections.Generic;
using System.IO;  // File işlemleri için
using Newtonsoft.Json;  // Json işlemleri için
using TerminalTransfer.Models;  // DeviceData sınıfını kullanabilmek için

namespace TerminalTransfer.Devices
{
    public class DeviceDataManager
    {
        private const string FilePath = "DeviceData.json";  // JSON dosyasının yolu

        // Cihazları JSON dosyasına kaydetme
        public void SaveDeviceData(List<DeviceData> devices)
        {
            string jsonData = JsonConvert.SerializeObject(devices, Newtonsoft.Json.Formatting.Indented);  // Burada tam yol kullanıldı
            File.WriteAllText(FilePath, jsonData);
        }

        // JSON dosyasından cihaz verilerini okuma
        public List<DeviceData> LoadDeviceData()
        {
            if (File.Exists(FilePath))
            {
                string jsonData = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<DeviceData>>(jsonData);
            }
            else
            {
                return new List<DeviceData>(); // Eğer dosya yoksa, boş liste döner
            }
        }
    }
}
