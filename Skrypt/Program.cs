﻿using System;
using System.IO;
using System.Collections.Generic;
using Evaluation;
using Tokenisation;

namespace Skrypt
{
    class Program
    {
        static Tokenizer tokenizer = new Tokenizer();
        static List<Token> tokens;

        static bool printTokens = true;

        static void Main(string[] args)
        {
            string filePath = @"E:\Google Drive\CSharp\Skrypt_Project\code.skrypt";
            StreamReader sr = new StreamReader(filePath);
            string code = sr.ReadToEnd();
            sr.Close();

            code = code.Replace('\0', ' ');

            tokens = tokenizer.GetTokens(code);

            if (printTokens)
            {
                foreach (Token token in tokens)
                {

                    Console.Write("Token \t");

                    ConsoleColor color = ConsoleColor.White;
                    ConsoleColor seccolor = ConsoleColor.White;

                    if (token.type == TokenType.String) {
                        color = ConsoleColor.Red;    
                        seccolor = ConsoleColor.Yellow;  
                    }
                    else
                    if (token.type == TokenType.Keyword) {
                        color = ConsoleColor.Cyan;  
                        seccolor = color;                       
                    }
                    else
                    if (token.type == TokenType.Boolean) {
                        color = ConsoleColor.Red;  
                        seccolor = ConsoleColor.DarkMagenta;                       
                    }
                    else
                    if (token.type == TokenType.Numeric) {
                        color = ConsoleColor.Red;    
                       seccolor = ConsoleColor.DarkMagenta;                  
                    }
                    else
                    if (token.type == TokenType.Identifier) {
                        color = ConsoleColor.DarkBlue;    
                        seccolor = ConsoleColor.DarkBlue;                  
                    }
                    else
                    if (token.type == TokenType.Punctuator) {
                        color = ConsoleColor.White;    
                        seccolor = ConsoleColor.White;                  
                    }

                    Console.ForegroundColor = color;
                    Console.Write(token.type);
                    Console.ResetColor();
                    Console.Write("  \t");
                    Console.ForegroundColor = seccolor;
                    Console.Write(token.value + "\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
