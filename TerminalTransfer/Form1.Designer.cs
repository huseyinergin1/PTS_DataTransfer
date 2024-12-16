using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using TerminalTransfer.Models;

namespace TerminalTransfer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTerminal; // Terminal Panel
        private System.Windows.Forms.Panel panelSettings; // Settings Panel
        private System.Windows.Forms.Panel panelTransfer; // Transfer Panel
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGetMovements;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.CheckBox chkClearMemory;

        private System.Windows.Forms.Button btnTerminalPanel;
        private System.Windows.Forms.Button btnSettingsPanel;
        private System.Windows.Forms.Button btnTransferPanel;
        // Kaydet Butonu
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.DataGridView dgvTerminals;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTerminalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTerminalAdi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHafizaSil;



        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvTerminals = new System.Windows.Forms.DataGridView();
            this.colTerminalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTerminalAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelTerminal = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnTransferPanel = new System.Windows.Forms.Button();
            this.btnSettingsPanel = new System.Windows.Forms.Button();
            this.btnTerminalPanel = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.chkClearMemory = new System.Windows.Forms.CheckBox();
            this.btnGetMovements = new System.Windows.Forms.Button();
            this.panelTransfer = new System.Windows.Forms.Panel();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).BeginInit();
            this.panelTerminal.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelTransfer.SuspendLayout();
            this.SuspendLayout();

            this.colHafizaSil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            // 
            // colHafizaSil
            // 
            this.colHafizaSil.HeaderText = "Hafıza Sil";
            this.colHafizaSil.MinimumWidth = 6;
            this.colHafizaSil.Name = "colHafizaSil";
            this.colHafizaSil.Width = 50;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(710, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(821, 405);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 33);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvTerminals
            // 
            this.dgvTerminals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTerminalNo,
            this.colTerminalAdi,
            this.colIp,
            this.colPort,
            this.colSelect});
            this.dgvTerminals.Location = new System.Drawing.Point(-1, -2);
            this.dgvTerminals.Name = "dgvTerminals";
            this.dgvTerminals.RowHeadersWidth = 51;
            this.dgvTerminals.Size = new System.Drawing.Size(893, 343);
            this.dgvTerminals.TabIndex = 0;
            this.dgvTerminals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTerminals_CellContentClick);
            // 
            // colTerminalNo
            // 
            this.colTerminalNo.HeaderText = "Terminal No";
            this.colTerminalNo.MinimumWidth = 6;
            this.colTerminalNo.Name = "colTerminalNo";
            this.colTerminalNo.Width = 120;
            // 
            // colTerminalAdi
            // 
            this.colTerminalAdi.HeaderText = "Terminal Adı";
            this.colTerminalAdi.MinimumWidth = 6;
            this.colTerminalAdi.Name = "colTerminalAdi";
            this.colTerminalAdi.Width = 150;
            // 
            // colIp
            // 
            this.colIp.HeaderText = "IP Address";
            this.colIp.MinimumWidth = 6;
            this.colIp.Name = "colIp";
            this.colIp.Width = 150;
            // 
            // colPort
            // 
            this.colPort.HeaderText = "Port";
            this.colPort.MinimumWidth = 6;
            this.colPort.Name = "colPort";
            this.colPort.Width = 125;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.MinimumWidth = 6;
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // panelTerminal
            // 
            this.panelTerminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTerminal.Controls.Add(this.dgvTerminals);
            this.panelTerminal.Location = new System.Drawing.Point(20, 52);
            this.panelTerminal.Name = "panelTerminal";
            this.panelTerminal.Size = new System.Drawing.Size(893, 342);
            this.panelTerminal.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(165, 145);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Test";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnTransferPanel
            // 
            this.btnTransferPanel.Location = new System.Drawing.Point(217, 12);
            this.btnTransferPanel.Name = "btnTransferPanel";
            this.btnTransferPanel.Size = new System.Drawing.Size(92, 33);
            this.btnTransferPanel.TabIndex = 5;
            this.btnTransferPanel.Text = "Transfer";
            this.btnTransferPanel.Click += new System.EventHandler(this.btnTransferPanel_Click);
            // 
            // btnSettingsPanel
            // 
            this.btnSettingsPanel.Location = new System.Drawing.Point(119, 12);
            this.btnSettingsPanel.Name = "btnSettingsPanel";
            this.btnSettingsPanel.Size = new System.Drawing.Size(92, 33);
            this.btnSettingsPanel.TabIndex = 4;
            this.btnSettingsPanel.Text = "Ayarlar";
            this.btnSettingsPanel.Click += new System.EventHandler(this.btnSettingsPanel_Click);
            // 
            // btnTerminalPanel
            // 
            this.btnTerminalPanel.Location = new System.Drawing.Point(21, 12);
            this.btnTerminalPanel.Name = "btnTerminalPanel";
            this.btnTerminalPanel.Size = new System.Drawing.Size(92, 33);
            this.btnTerminalPanel.TabIndex = 3;
            this.btnTerminalPanel.Text = "Terminal";
            this.btnTerminalPanel.Click += new System.EventHandler(this.btnTerminalPanel_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.chkClearMemory);
            this.panelSettings.Location = new System.Drawing.Point(20, 51);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(893, 343);
            this.panelSettings.TabIndex = 1;
            this.panelSettings.Visible = false;
            // 
            // chkClearMemory
            // 
            this.chkClearMemory.AutoSize = true;
            this.chkClearMemory.Location = new System.Drawing.Point(16, 3);
            this.chkClearMemory.Name = "chkClearMemory";
            this.chkClearMemory.Size = new System.Drawing.Size(174, 20);
            this.chkClearMemory.TabIndex = 2;
            this.chkClearMemory.Text = "Cihaz Hafızasını Temizle";
            // 
            // btnGetMovements
            // 
            this.btnGetMovements.Location = new System.Drawing.Point(53, 145);
            this.btnGetMovements.Name = "btnGetMovements";
            this.btnGetMovements.Size = new System.Drawing.Size(92, 28);
            this.btnGetMovements.TabIndex = 0;
            this.btnGetMovements.Text = "Transfer";
            this.btnGetMovements.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // panelTransfer
            // 
            this.panelTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransfer.Controls.Add(this.btnConnect);
            this.panelTransfer.Controls.Add(this.btnGetMovements);
            this.panelTransfer.Controls.Add(this.lstMessages);
            this.panelTransfer.Controls.Add(this.lblStatus);
            this.panelTransfer.Location = new System.Drawing.Point(20, 51);
            this.panelTransfer.Name = "panelTransfer";
            this.panelTransfer.Size = new System.Drawing.Size(893, 343);
            this.panelTransfer.TabIndex = 2;
            this.panelTransfer.Visible = false;
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 16;
            this.lstMessages.Location = new System.Drawing.Point(50, 40);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(300, 84);
            this.lstMessages.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(50, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Bağlantı durumu: -";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.btnTerminalPanel);
            this.Controls.Add(this.btnSettingsPanel);
            this.Controls.Add(this.btnTransferPanel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panelTerminal);
            this.Controls.Add(this.panelTransfer);
            this.Controls.Add(this.panelSettings);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminals)).EndInit();
            this.panelTerminal.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelTransfer.ResumeLayout(false);
            this.panelTransfer.PerformLayout();
            this.ResumeLayout(false);

        }

        // Form Load event to set the initial visibility of panels
        // Form_Load metodu
        private void Form_Load(object sender, EventArgs e) { } // Bu kadar :) hafıza silme
        private void btnTerminalPanel_Click(object sender, EventArgs e)
        {
            panelTerminal.Visible = true;
            panelSettings.Visible = false;
            panelTransfer.Visible = false;
        }

        private void btnSettingsPanel_Click(object sender, EventArgs e)
        {
            panelTerminal.Visible = false;
            panelSettings.Visible = true;
            panelTransfer.Visible = false;
        }

        private void btnTransferPanel_Click(object sender, EventArgs e)
        {
            panelTerminal.Visible = false;
            panelSettings.Visible = false;
            panelTransfer.Visible = true;
        }
        // btnSave_Click metodu
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<DeviceData> devices = new List<DeviceData>();

                foreach (DataGridViewRow row in dgvTerminals.Rows)
                {
                    if (row.IsNewRow) continue; // Yeni satırı atla

                    // Satırdaki null veya boş değerleri kontrol et
                    DeviceData device = new DeviceData
                    {
                        Select = row.Cells["colSelect"].Value != null && Convert.ToBoolean(row.Cells["colSelect"].Value),  // Checkbox kontrolü
                        TerminalNo = row.Cells["colTerminalNo"].Value?.ToString() ?? "", // Null kontrolü
                        TerminalAdi = row.Cells["colTerminalAdi"].Value?.ToString() ?? "", // Null kontrolü
                        IpAddress = row.Cells["colIp"].Value?.ToString() ?? "", // Null kontrolü
                        Port = row.Cells["colPort"].Value?.ToString() ?? "", // Null kontrolü
                        hafizasil = chkClearMemory.Checked
                    };

                    devices.Add(device);
                }

                // JSON dosyasına kaydetme işlemi
                JsonHelper.SaveTerminalsToJson(devices); // Burada SaveTerminalsToJson metodunu kullanıyoruz.

                MessageBox.Show("Veriler kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            panelTerminal.Visible = true;
            panelSettings.Visible = false;
            panelTransfer.Visible = false;
            // Uygulamayı kapatmak için Close() metodunu kullanabilirsiniz
            this.Close();


        }


    }
}