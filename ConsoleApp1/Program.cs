using System;
using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string qtd = "";
            int quantidade = 0;
            while (!int.TryParse(qtd, out quantidade))
            {
                Console.Write("Digite um valor Inteiro: ");
                qtd = Console.ReadLine();
            }

            var utilitarios = new Utils();
            var matrix = utilitarios.Matrix(quantidade);
            for (int r = 0; r < quantidade; r++)
            {
                for (int c = 0; c < quantidade; c++)
                {
                    Console.Write("{0, 4}", matrix[r, c]);
                }
                Console.WriteLine();
            }
        }


    }

    public class Utils
    {
        public int[,] Matrix(int qtd)
        {
            int[,] matrix = new int[qtd, qtd];
            int maxRotacoes = qtd * qtd;
            int linha = 0;
            int coluna = 0;
            string direction = "right";
            for (int i = 1; i <= maxRotacoes; i++)
            {
                if ((direction == "right") && (coluna > qtd - 1 || matrix[linha, coluna] != 0))
                {
                    direction = "down";
                    coluna--;
                    linha++;
                }
                if ((direction == "down") && (linha > qtd - 1 || matrix[linha, coluna] != 0))
                {
                    direction = "left";
                    linha--;
                    coluna--;
                }
                if ((direction == "left") && (coluna < 0 || matrix[linha, coluna] != 0))
                {
                    direction = "up";
                    coluna++;
                    linha--;
                }
                if ((direction == "up") && (linha < 0 || matrix[linha, coluna] != 0))
                {
                    direction = "right";
                    linha++;
                    coluna++;
                }
                matrix[linha, coluna] = i;
                if (direction == "right")
                {
                    coluna++;
                }
                if (direction == "down")
                {
                    linha++;
                }
                if (direction == "left")
                {
                    coluna--;
                }
                if (direction == "up")
                {
                    linha--;
                }
            }

            return matrix;
        }
    }
}
