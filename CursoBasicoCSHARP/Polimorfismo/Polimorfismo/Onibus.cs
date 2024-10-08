﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    public class Onibus : Veiculo
    {
        private int capacidade;
        public override int Capacidade
        {
            get
            {
                return capacidade;
            }
            set
            {
                if ((value >= 18) && (value <= 60))
                {
                    capacidade = value;
                }
                else
                {
                    throw new ArgumentException("O Onibus pode ter capacidade de 18 a 60 pessoas");
                }
            }
        }
        public int PotenciaCv { get; set; }
        public override void Abastecer(double quantidadeLitros)
        {
            QuantidadeCombustivel += quantidadeLitros;
            Console.WriteLine($"Carro foi abastecido com {quantidadeLitros} litros de diesel");
        }
        public override void Mover(double distanciKm)
        {
            if (QuantidadeCombustivel > (distanciKm / 5))
            {
                QuantidadeCombustivel -= (distanciKm / 5);
                Console.WriteLine($"O carro se moveu por {distanciKm} kilometros.");
            }
            else
            {
                Console.WriteLine("Não ha combustivel para percorrer a distancia informada");
            }
        }
        public override void Frear()
        {
            Console.WriteLine("Acionando os Freios a AR... Parou");
        }
        public Onibus(int pesoKg, DateTime dataFabricacao, int capacidade = 45) : base(pesoKg, dataFabricacao)
        {
            Capacidade = capacidade;
        }
    }
}
