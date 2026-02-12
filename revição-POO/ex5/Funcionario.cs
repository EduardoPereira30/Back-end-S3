using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ex5
{
    public class Funcionario : Pessoa
    {
        public int salario = 20 ; 

        public void ExibirDados()
        {
            System.Console.WriteLine($"Funcionario: {nome}");
            System.Console.WriteLine($"Salario: {salario}");

        }
    }
}