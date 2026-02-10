using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex2
{
    public class Pessoa
    {
        public string Nome = "Eduardo";
        
        public int idade = 16 ;


        public void Exibirdados()
        {
            
        System.Console.WriteLine($"olá {Nome}, você tem {idade} anos");

        }
    }
}