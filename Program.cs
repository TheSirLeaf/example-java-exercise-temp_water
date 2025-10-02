using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using example_java_exercise_temp_water.Models;

bool exit = false;
string select;

List<Dia> dias = new List<Dia>();
double[] insert = new double[12];


Dia Cenario1 = new Dia(nome: 1, temperaturas: new double[12], cenario: true);
Dia.InserirTemperaturas(dia: Cenario1, temperaturas: [10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0]);
dias.Add(Cenario1);

Dia Cenario2 = new Dia(nome: 2, temperaturas: new double[12], cenario: true);
Dia.InserirTemperaturas(dia: Cenario2, temperaturas: [6.0, 5.0, 4.0, 7.0, 8.0, 9.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0]);
dias.Add(Cenario2);

while (!exit)
{
    try
    {
        Console.WriteLine("======================================");
        Console.WriteLine("Menu - Sistema de Aferimento da Temperatura da Água");
        Console.WriteLine("Selecione uma opção para continuar:");
        Console.WriteLine("");
        Console.WriteLine("1 - Testar cenários de funcionamento");
        Console.WriteLine("2 - Inserir um dia ao sistema");
        Console.WriteLine("3 - Visualizar informações sobre um dia inserido");
        Console.WriteLine("4 - Listar dias inseridos");
        Console.WriteLine("5 - Excluir um dia inserido");
        Console.WriteLine("0 - Desconectar do sistema");
        Console.WriteLine("======================================");
        Console.Write("Seleção: ");
        select = Console.ReadLine();
        switch (select)
        {
            case "0":
                Console.WriteLine("Desconectando sistema...");
                exit = true;
                break;
            case "1":
                Console.WriteLine("Selecione o cenário (Digite o número correspondente):");
                Dia.ExibirDias(dias: dias, cenario: true);
                Console.WriteLine("");
                select = Console.ReadLine();
                if (int.TryParse(select, out int cenarioSelect))
                {
                    Dia.SelecionarDia(dias: dias, cenario: true, select: cenarioSelect);
                }
                else
                {
                    Console.WriteLine("Valor não pôde ser convertido, tente novamente.");
                }
                break;
            case "2":
                Console.WriteLine("Digite o número do dia a ser inserido:");
                select = Console.ReadLine();
                int numero = Convert.ToInt32(select);
                foreach (var dia in dias)
                {
                    if (dia.Cenario == false && dia.Numero == numero)
                    {
                        throw new Exception("Dia especificado já existe!");
                    }
                }
                for (int i = 1; i <= 12; i++)
                {
                    double temp;
                    while (true)
                    {
                        Console.WriteLine($"Digite o valor da temperatura da hora {i}/12 (entre 4 e 10):");
                        if (double.TryParse(Console.ReadLine(), out temp) && temp >= 4 && temp <= 10)
                        {
                            insert[i - 1] = temp;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Temperatura inválida! Digite um valor entre 4 e 10.");
                        }
                    }
                }
                dias.Add(new Dia(nome: numero, cenario: false, temperaturas: insert));
                Dia diaAdicionado = dias.Find(d => d.Numero == numero && d.Cenario == false);
                Console.WriteLine(diaAdicionado.Nome + " foi adicionado com sucesso!");
                Console.WriteLine("Valores de temperatura: ");
                Console.WriteLine(string.Join("°C, ", diaAdicionado.Temperaturas) + "°C");
                break;
            case "3":
                if (!dias.Any(d => d.Cenario == false))
                {
                    Console.WriteLine("Não existem dias cadastrados!");
                }
                else
                {
                    Console.WriteLine("Digite o número do dia a ser visualizado:");
                    select = Console.ReadLine();
                    if (int.TryParse(select, out int diaSelect))
                    {
                        Dia.SelecionarDia(dias: dias, cenario: false, select: diaSelect);
                    }
                    else
                    {
                        Console.WriteLine("Valor não pôde ser convertido, tente novamente.");
                    }
                }
                break;
            case "4":
                if (!dias.Any(d => d.Cenario == false))
                {
                    Console.WriteLine("Não existem dias cadastrados!");
                }
                else
                {
                    Dia.ExibirDias(dias: dias, cenario: false);
                }
                break;
            case "5":
                if (!dias.Any(d => d.Cenario == false))
                {
                    Console.WriteLine("Não existem dias cadastrados!");
                }
                else
                {
                    Console.WriteLine("Digite o número do dia a ser excluído (digite 0 para cancelar):");
                    select = Console.ReadLine();
                    if (int.TryParse(select, out int diaSelect))
                    {
                        if (diaSelect == 0)
                        {
                            Console.WriteLine("Operação cancelada!");
                        }
                        else
                        {
                            Dia.ExcluirDia(dias: dias, diaSelect);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor não pôde ser convertido, tente novamente.");
                    }
                }
                break;
            default:
                Console.WriteLine("Valor incorreto inserido, tente novamente.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
    Console.WriteLine("");
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}

// // Exemplo de busca por nome
// string nomeBusca = "exemplo"; // Substitua pelo nome que quiser buscar

// // O método Find procura um objeto Dia na lista 'dias' que atenda à condição especificada.
// // O 'd' é apenas um nome de variável temporária para cada elemento da lista durante a busca.
// // A expressão 'd => d.Nome == nomeBusca' significa:
// // "Para cada Dia (chamado de 'd') na lista, verifique se d.Nome é igual ao nomeBusca."
// Dia diaEncontrado = dias.Find(d => d.Nome == nomeBusca);

// if (diaEncontrado != null)
// {
//     Console.WriteLine($"Dia encontrado: {diaEncontrado.Nome}");
// }
// else
// {
//     Console.WriteLine("Dia não encontrado.");
// }
