using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TerminalTransfer.Models;

public static class JsonHelper
{
    // Tam dosya yolunu belirtin
    private const string JsonFilePath = @"C:\Users\huseyin\source\repos\TerminalTransfer\TerminalTransfer\ayarlar.json";

    // Terminal verilerini JSON dosyasına kaydeder
    public static void SaveTerminalsToJson(List<DeviceData> terminalList)
    {
        try
        {
            // Listeyi null kontrolü ve geçerlilik kontrolü ekleyebilirsiniz
            if (terminalList == null || terminalList.Count == 0)
            {
                MessageBox.Show("Kaydedilecek terminal verisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verinin geçerliliğini kontrol etmek isterseniz (örnek)
            foreach (var terminal in terminalList)
            {
                if (string.IsNullOrEmpty(terminal.TerminalNo) || string.IsNullOrEmpty(terminal.IpAddress))
                {
                    MessageBox.Show("Terminal verisi eksik veya hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // JSON'a dönüştürme işlemi
            var json = JsonConvert.SerializeObject(terminalList, Formatting.Indented);
            File.WriteAllText(JsonFilePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // JSON dosyasından terminal verilerini okur
    public static List<DeviceData> LoadTerminalsFromJson()
    {
        try
        {
            if (File.Exists(JsonFilePath))
            {
                var json = File.ReadAllText(JsonFilePath);

                // Verinin geçerli olup olmadığını kontrol etme
                if (string.IsNullOrEmpty(json))
                {
                    MessageBox.Show("JSON dosyası boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<DeviceData>();
                }

                // JSON'dan veriyi deserialize etme
                var terminals = JsonConvert.DeserializeObject<List<DeviceData>>(json);

                // Deserialization sonrası null kontrolü
                if (terminals == null)
                {
                    MessageBox.Show("Veri okuma hatası: JSON verisi geçerli değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<DeviceData>();
                }

                return terminals;
            }
            else
            {
                MessageBox.Show("JSON dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return new List<DeviceData>(); // Eğer dosya yoksa ya da hata varsa boş bir liste döndürülür.
    }
}
