﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDeCasoPessoa
{
    internal class Pessoa
    {
        private string cpf;

        public string CPF
        {
            get { return cpf; }
            set
            {
                if ((value.Length == 11) && value.HasOnlyDigits())
                    cpf = value;
                else
                    throw new Exception("O CPF deve possuir 11 digitos.");            
            }
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DatadeNascimento { get; set; }
        public double Peso {  get; set; }
        public double Altura { get; set; }
        public double IMC
        {
            get 
            { 
                return (this.Peso / (this.Altura*this.Altura)); 
            }
        }
        public Pessoa(string nome, string sobrenome, DateTime datadeNascimento, string cpf)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DatadeNascimento = datadeNascimento;
            this.CPF = cpf;
        }
        public Pessoa(string nome, string sobrenome, DateTime datadeNascimento, string cpf, double peso, double altura) : this(nome, sobrenome, datadeNascimento, cpf)
        {
            this.Peso = peso;
            this.Altura = altura;
        }
        public void Comer(double pesoKg)
        {
            this.Peso += pesoKg / 10;
            Console.WriteLine($"{this.Nome} {this.Sobrenome} comeu {pesoKg}kg de comida");
        }
        public void Comer(int calorias)
        {
            this.Peso += calorias / 30000;
            Console.WriteLine($"{this.Nome} {this.Sobrenome} ingeriu {calorias} calorias");
        }
        public void Correr(double distanciaKm, int dias = 1)
        {
            this.Peso -= (distanciaKm / 40) * dias;
            Console.WriteLine($"{this.Nome} {this.Sobrenome} correu {distanciaKm} kms diarios por {dias} dia(s)");
        }
        public void MostrarDados()
        {
            Console.WriteLine($"Nome Completo: {this.Nome} {this.Sobrenome}");
            Console.WriteLine($"Idade: {Math.Truncate((DateTime.Now - this.DatadeNascimento).TotalDays / 365.25)}");
            Console.WriteLine($"IMC: {this.IMC:F2}");
        }
    }
}
