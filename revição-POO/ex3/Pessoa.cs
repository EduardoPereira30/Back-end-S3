using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex3
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

            if (i > 0)
            {

                Idade = i;

            }
            else
            {
                System.Console.WriteLine("idade invalida");

                Idade = 0;

            }
            Nome = n;


        }
    }
}