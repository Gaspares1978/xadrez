
using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirPartida(partida);


                    Console.WriteLine();
                    Console.Write("digite a origem:");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.validarPosicaoDeorigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("digite o destino:");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);

                    partida.executaMovimento(origem, destino);
                    partida.realizaJogada(origem, destino);
                }

                Console.Clear();
                Tela.imprimirPartida(partida);



            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

