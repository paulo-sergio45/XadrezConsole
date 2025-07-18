﻿using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            ConsoleColor aux = Console.ForegroundColor;
            if (!partida.terminada)
            {


                Console.Write("Aguardando jogada: ");
                if (partida.jogadorAtual == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(partida.jogadorAtual);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(partida.jogadorAtual);
                }


                if (partida.xeque)
                {
                    if (partida.jogadorAtual == Cor.Branca)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("XEQUE!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("XEQUE!");
                    }
                    Console.ForegroundColor = aux;
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.Write("Vencedor: ");
                if (partida.jogadorAtual == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(partida.jogadorAtual);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(partida.jogadorAtual);
                }

            }
            Console.ForegroundColor = aux;
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Brancas: ");

            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Pretas: ");

            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(peca);

                }
                Console.ForegroundColor = aux;
                Console.Write(" ");
            }
        }

    }
}
