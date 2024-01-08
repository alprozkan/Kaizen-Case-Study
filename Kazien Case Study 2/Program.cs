using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OCRResultParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // JSON dosya yolu gerekli oldugunda degistirilmelidir
            string jsonFilePath = @"C:\Users\alpro\OneDrive\Desktop\Kaizen\response.json";

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);

                OCRResult ocrResult = JsonConvert.DeserializeObject<OCRResult>(jsonContent);

                if (ocrResult != null)
                {
                    foreach (var item in ocrResult.Description)
                    {
                        Console.WriteLine($"Metin: {item.Text}");
                        Console.WriteLine($"Konum: {string.Join(", ", item.BoundingBox)}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("OCR sonucu boş veya hatalı.");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını yazdır
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
        }
    }

    public class OCRResult
    {
        [JsonProperty("description")]
        public List<DescriptionItem> Description { get; set; }
    }

    public class DescriptionItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("boundingBox")]
        public List<int> BoundingBox { get; set; }
    }
}
