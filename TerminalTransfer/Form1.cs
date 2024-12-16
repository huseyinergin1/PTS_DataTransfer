using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using zkemkeeper;  // ZKTeco SDK'sının doğru namespace'i
using TerminalTransfer.Models; // DeviceData sınıfını kullanabilmek için
using TerminalTransfer.Devices; // DeviceDataManager sınıfını kullanabilmek için

namespace TerminalTransfer
{
    public partial class Form1 : Form
    {
        private dynamic reader; // CZKEM nesnesi için dinamik bir değişken

        public Form1()
        {
            InitializeComponent();
            try
            {
                reader = new zkemkeeper.CZKEM();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        #region Terminal Sayfası Kodları
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = "";
            int port = 0;
            bool isSelected = false;

            foreach (DataGridViewRow row in dgvTerminals.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colSelect"].Value))
                {
                    ip = row.Cells["colIp"].Value.ToString().Trim();
                    if (int.TryParse(row.Cells["colPort"].Value.ToString().Trim(), out port) && port > 0)
                    {
                        isSelected = true;
                        break;
                    }
                }
            }

            if (!isSelected)
            {
                MessageBox.Show("Lütfen bir cihaz seçin.");
                return;
            }

            try
            {
                bool isConnected = reader.Connect_Net(ip, port);
                if (isConnected)
                {
                    lblStatus.Text = "Bağlantı başarılı!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lstMessages.Items.Add("Bağlantı testi başarılı.");
                }
                else
                {
                    lblStatus.Text = "Bağlantı başarısız!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lstMessages.Items.Add("Bağlantı sağlanamadı. IP ve portu kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Bağlantı sırasında hata: {ex.Message}";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lstMessages.Items.Add($"Hata: {ex.Message}");
            }
        }
        #endregion

        #region Ayarlar Sayfası Kodları
        private void btnClearMemory_Click(object sender, EventArgs e)
        {
            if (chkClearMemory.Checked)
            {
                try
                {
                    if (reader.ClearGLog(1))
                    {
                        lstMessages.Items.Add("Cihaz hafızası başarıyla temizlendi.");
                    }
                    else
                    {
                        lstMessages.Items.Add("Cihaz hafızası temizlenemedi. Hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                    lstMessages.Items.Add($"Hata: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Hafıza temizleme seçeneği işaretlenmemiş.");
            }
        }
        #endregion

        #region Transferler Sayfası Kodları
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string ip = "";
            int port = 0;
            bool isSelected = false;

            foreach (DataGridViewRow row in dgvTerminals.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colSelect"].Value))
                {
                    ip = row.Cells["colIp"].Value.ToString().Trim();
                    if (int.TryParse(row.Cells["colPort"].Value.ToString().Trim(), out port) && port > 0)
                    {
                        isSelected = true;
                        break;
                    }
                }
            }

            if (!isSelected)
            {
                MessageBox.Show("Lütfen bir cihaz seçin.");
                return;
            }

            try
            {
                bool isConnected = reader.Connect_Net(ip, port);
                if (!isConnected)
                {
                    MessageBox.Show("Bağlantı sağlanamadı. IP ve portu kontrol edin.");
                    return;
                }

                lstMessages.Items.Clear();
                lstMessages.Items.Add("Cihaza bağlantı sağlandı, hareketler çekiliyor...");

                if (!reader.ReadGeneralLogData(1))
                {
                    MessageBox.Show("Hareket verileri okunamadı veya boş.");
                    return;
                }

                string filePathA = @"C:\\Users\\huseyin\\source\\repos\\TerminalTransfer\\TerminalTransfer\\Veriler\\a.txt";
                string filePathB = @"C:\\Users\\huseyin\\source\\repos\\TerminalTransfer\\TerminalTransfer\\Veriler\\b.txt";

                using (StreamWriter writerA = new StreamWriter(filePathA, true))
                using (StreamWriter writerB = new StreamWriter(filePathB, true))
                {
                    while (reader.SSR_GetGeneralLogData(1,
                                                        out string enrollNumber,
                                                        out int verifyMode,
                                                        out int inOutMode,
                                                        out int year,
                                                        out int month,
                                                        out int day,
                                                        out int hour,
                                                        out int minute,
                                                        out int second,
                                                        out int workCode))
                    {
                        string direction = inOutMode == 0 ? "001" : "002";
                        string cardNumber = enrollNumber.PadLeft(10, '0');
                        string terminalNo = "01";
                        string date = $"{year:0000}-{month:00}-{day:00}";
                        string time = $"{hour:00}:{minute:00}:{second:00}";

                        string logLine = $"{direction},{cardNumber},{terminalNo},{date},{time}";

                        writerA.WriteLine(logLine);
                        writerB.WriteLine(logLine);
                        lstMessages.Items.Add($"Kaydedildi: {logLine}");
                    }
                }

                MessageBox.Show("Hareketler başarıyla dosyalara kaydedildi.");

                // If the ClearMemory checkbox is checked, clear the memory
                if (chkClearMemory.Checked)
                {
                    try
                    {
                        if (reader.ClearGLog(1))
                        {
                            lstMessages.Items.Add("Cihaz hafızası başarıyla temizlendi.");
                        }
                        else
                        {
                            lstMessages.Items.Add("Cihaz hafızası temizlenemedi. Hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        lstMessages.Items.Add($"Hata: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
                lstMessages.Items.Add($"Hata: {ex.Message}");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test butonu çalıştı.");
        }
        #endregion

        private void dgvTerminals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // JSON dosyasındaki verileri yükle
                var terminalList = JsonHelper.LoadTerminalsFromJson();
                // Eğer JSON'da cihazlar varsa, ilk cihazın hafizasil değerine göre checkbox'ı işaretle
                if (terminalList != null && terminalList.Count > 0)
                {
                    chkClearMemory.Checked = terminalList[0].hafizasil; // İlk cihazın hafizasil durumunu checkbox'a uygula
                }
                else
                {
                    chkClearMemory.Checked = false; // Varsayılan olarak unchecked yap
                }

                // Verileri DataGridView'e aktar
                foreach (var terminal in terminalList)
                {
                    // Satır eklerken null kontrolü ekleyin
                    dgvTerminals.Rows.Add(
                        terminal.TerminalNo ?? "",
                        terminal.TerminalAdi ?? "",
                        terminal.IpAddress ?? "",
                        terminal.Port ?? "",
                        terminal.Select
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}