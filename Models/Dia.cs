using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace example_java_exercise_temp_water.Models
{
    public class Dia
    {
        public Dia(int nome, bool cenario, double[] temperaturas)
        {
            if (nome < 1 && cenario == false)
                throw new ArgumentException("O nome do dia deve ser um número inteiro positivo.");
            Cenario = cenario;
            Nome = Convert.ToString(nome);
            Temperaturas = temperaturas;
            Numero = nome;
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (Cenario == false)
                {
                    _nome = "Dia " + value;
                }
                else
                {
                    _nome = "Cenário " + value;
                }
            }
        }
        public double[] Temperaturas { get; set; }
        public bool Cenario { get; set; }
        public int Numero { get; set; }
        public static void InserirTemperatura(Dia dia, int hora, double temperatura)
        {
            if (hora <= 1 || hora >= 12)
                throw new ArgumentException("Hora deve estar entre 1 e 12.");
            dia.Temperaturas[hora] = temperatura;
        }
        public static void InserirTemperaturas(Dia dia, double[] temperaturas)
        {
            if (temperaturas.Length != 12)
                throw new ArgumentException("O array de temperaturas deve ter exatamente 12 elementos.");
            dia.Temperaturas = temperaturas;
        }
        public static void ExibirDias(List<Dia> dias, bool cenario)
        {
            foreach (var dia in dias)
            {
                if (dia.Cenario == cenario)
                {
                    Console.WriteLine(dia.Nome + ": ");
                    // Console.Write(string.Join("°C, ", dia.Temperaturas) + "°C");
                }
            }
        }
        public static bool SelecionarDia(List<Dia> dias, bool cenario, int select)
        {
            foreach (var dia in dias)
            {
                if (dia.Cenario == cenario && dia.Numero == select)
                {
                    Console.WriteLine("");
                    Console.WriteLine(dia.Nome + ": ");
                    Console.Write(string.Join("°C, ", dia.Temperaturas) + "°C");
                    Console.WriteLine("");
                    Console.WriteLine("Temperatura média: " + dia.Temperaturas.Average() + "°C");
                    return true;
                }
            }
            Console.WriteLine((cenario ? "Cenário " : "Dia ") + "especificado não foi encontrado!");
            return false;
        }
        public static bool ExcluirDia(List<Dia> dias, int select)
        {
            foreach (var dia in dias)
            {
                if (dia.Cenario == false && dia.Numero == select)
                {
                    dias.Remove(dia);
                    Console.WriteLine("");
                    Console.WriteLine(dia.Nome + " foi excluído com sucesso!");
                    return true;
                }
            }
            return false;
        }
    }
}