using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.IO;

namespace ÜbersetzerChatGPT
{
    public class Program
    {
        static void Main(string[] args)
        {   
            //Füge deinen API Key hinzu 
            OpenAIAPI api = 
                new OpenAIAPI("");

            //Vorstellung Programm mit Funktionsweise
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(File.ReadAllText("./Beschreibung.txt"));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Drücken sie Enter");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
           
            //Einlesen von Quellcode mit Auswahl von welcher Sprache in welche andere übersetzt werden soll

            Console.WriteLine("Herzlich Willkommen, bitte wählen Sie die Sprache aus der übersetzt werden soll:");
            string input_language = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie nun den Code ein den Sie übersetzt haben möchten:");
            string code = Console.ReadLine();
            Console.WriteLine("Wählen Sie jetzt noch die Ziel-Sprache in die Sie den Code übersetzt haben möchten:");
            string output_language = Console.ReadLine();    
            ChatMessage msg = new ChatMessage();
            msg.Content = "Übersetzte folgenden" + input_language + "Code:" + code + "in" + output_language;

            
            

            ChatMessage[] messages = new ChatMessage[1];
            messages[0] = msg;
            


            ChatRequest req = new ChatRequest();
            req.Model = Model.ChatGPTTurbo;
            req.Temperature = 0.1;
            req.MaxTokens = 1000;
            req.Messages = messages;

            Task<ChatResult> result = api.Chat.CreateChatCompletionAsync(req);
            result.Wait();

            Console.WriteLine(result.Result);

           

            
            Console.ReadLine();

        }
    }
}
