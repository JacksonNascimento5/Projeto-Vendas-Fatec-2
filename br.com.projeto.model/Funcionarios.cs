using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.model
{
   public class Funcionarios : Cliente
    {
        //Atributos + getter e setters
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivel { get; set; }

    }
}
