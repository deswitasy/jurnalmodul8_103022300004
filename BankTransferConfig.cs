using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static modul8_103022300004.BankTransferConfig;

namespace modul8_103022300004
{
    public class BankTransferConfig
    {
        private BankTransferConfig konfig;
        private const string filePath = "bank_transfer_config";
        public string lang { get; set; } = "en";
        public int threshold { get; set; } = 25000000;
        public int low_fee { get; set; } = 6500;
        public Transfer transfer { get; set; }
        public Confirmation confirmation { get; set; }
        public int high_fee { get; set; } = 15000;
        public List<string> methods { get; set; } = "[RTO(real - time)”, “SKN”, “RTGS”, “BI FAST”]";
        public string en { get; set; } = "yes";
        public string id { get; set; } = "ya";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                writeConfigFile();
            }
        }
        public void ReadConfigFile()
        {
            String json = File.ReadAllText(filePath);
            konfig = JsonSerializer.Deserialize<BankTransferConfig>(json);

        }
        public void SetDefault()
        {
            konfig = new BankTransferConfig();
            konfig lang = "en";
            Transfer transfer = new Transfer(25000000, 6500, 1500);
            konfig.transfer = transfer;
            List<string> isi = new List<string>();
            isi Add("RTO(real - time)");
            isi Add("SKN");
            isi Add("RTGS");
            isi Add("BI FAST");
            Confirmation confirm = new Confirmation();
            confirm.en = "yes";
            confirm.id = "ya";
            confirm.confirm = confirm;
        }

            public void writeConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(konfig, options);
            File.WriteAllText(filePath, jsonString);
        }
        public class config
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
            public config(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
            {
                this.lang = new lang;
                this.transfer = new Transfer;
                this.methods = new methods;
                this.confirmation = new Confirmation;
            }
        }
        static void Main(string[] args)
        {
            BankTransferConfig bank = new BankTransferConfig();
            if (bank Konfig lang == "en"){
                Console.WriteLine("Please insert the amount of money to transfer: ");
            } else
            {
                Console.WriteLine(“Masukkan jumlah uang yang akan di - transfer:”);
            }
            
        }
    }
    
}