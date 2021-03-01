using System;
using System.Collections.Generic;
using System.IO;
using exelinq.Entities;
using System.Globalization;
using System.Linq;

namespace exelinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o arquivo: ");
            string arquivo = Console.ReadLine();

            List<Funcionario> lista = new List<Funcionario>();

            using (StreamReader sr = File.OpenText(arquivo))
            {
                while (!sr.EndOfStream)
                {
                    string[] linha = sr.ReadLine().Split(",");
                    string nome = linha[0];
                    string email = linha[1];
                    double salario = double.Parse(linha[2], CultureInfo.InvariantCulture);

                    lista.Add(new Funcionario { Name = nome, Email = email, Salario = salario });
                }
            }

            Console.WriteLine("Informe o salario: ");
            double limitador = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Email das pessoas com salario maior que " + limitador.ToString());

            var novaLista1 = lista.Where(p => p.Salario > limitador)
                .OrderBy(p => p.Name)
                .Select(p => p.Email);

            foreach (var item in novaLista1)
            {
                Console.WriteLine(item);
            }

            var novaLista2 = lista.Where(p => p.Name[0] == 'M').Select(p => p.Salario).Sum();

            Console.WriteLine("A soma do salario dos empregados que começam por M:  " + novaLista2.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
