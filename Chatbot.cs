using System;
using System.Media;

namespace CybersecurityAwarenessBot
{
    public class Chatbot
    {
        private string userName = string.Empty;

        public void Start()
        {
            PlayGreeting();
            WriteColored(AsciiArt.Logo, ConsoleColor.Cyan);
            WriteColored(new string('=', 50), ConsoleColor.DarkCyan);
            WriteColored("Welcome to the Cybersecurity Awareness Bot/chatapp", ConsoleColor.Green);
            AskName();
            WriteColored($"Nice to meet you, {userName}! Let's talk about staying safe online.", ConsoleColor.Green);
            RunConversationLoop();
            
            string response = GetResponse(input);
            WriteColored($"Bot: {response}", ConsoleColor.Yellow);
        }

        private void AskName()
        {
            Console.Write("What's your name? ");
            userName = Console.ReadLine() ?? string.Empty;

            while (string.IsNullOrWhiteSpace(userName))
            {
            Console.Write("I didn't catch that — what should I call you? ");
            userName = Console.ReadLine() ?? string.Empty;
            }
        }
        private void PlayGreeting()
{
    try
    {
            SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
            player.PlaySync();
    }
    catch
    {
            WriteColored("(Voice greeting unavailable)" , ConsoleColor.Red);
    }
}

        private void RunConversationLoop()
        {
            WriteColored("You can ask me things like 'What is phishing?' or 'How do I create a strong password?", ConsoleColor.Yellow);
            WriteColored("Type 'exit' to end the conversation.", ConsoleColor.Yellow);

            while (true)
            {
                   Console.Write($"{userName}:");
                   string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("I didn't catch that. Please try again.");
                    continue;
                }

                if (input.Trim().ToLower() == "exit")
                {
                    Console.WriteLine($"Bot: stay stay safe online, {userName} Goodbye");
                    break;
                }

                    string response = GetResponse(input);
                    Console.WriteLine($"Bot: {response}");
                
            }
        }
        private string GetResponse(string input)
{
                string text = input.Trim().ToLower();

                if (text.Contains("how are you"))
                return "I'm doing great, thanks for asking! Ready to help you stay safe online.";

                if (text.Contains("purpose") || text.Contains("what can i ask"))
                 return "I'm here to help you learn about cybersecurity — you can ask me about phishing, password safety, and safe browsing.";

                if (text.Contains("phishing"))
                return "Phishing is when attackers trick you into revealing personal info, often via fake emails or links. Never click suspicious links or share passwords via email.";

                if (text.Contains("password"))
                return "Use strong passwords with a mix of letters, numbers, and symbols. Never reuse the same password across sites, and consider a password manager.";

                if (text.Contains("safe browsing") || text.Contains("browsing"))
                return "Stick to HTTPS sites, avoid clicking unknown links, and keep your browser updated to stay safe online.";

                return "I didn't quite understand that. Could you rephrase?";
}
        
        private void WriteColored(string text, ConsoleColor color)
        {
            
        
                 Console.ForegroundColor = color;
                 Console.WriteLine(text);
                 Console.ResetColor();
        {
        }
    }
    }
}

    