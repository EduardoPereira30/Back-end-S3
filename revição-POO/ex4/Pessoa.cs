using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex4
{
    public class Pessoa
    {

        public string Nome = "Eduardo";

        public int Idade = 16;


        public void Exibirdados()
        {

            Console.WriteLine($"olá {Nome}, você tem {Idade} anos");

        }
        public Pessoa(string n, int i)
        {

            Idade = i;
            Nome = n;

        }
    }
}