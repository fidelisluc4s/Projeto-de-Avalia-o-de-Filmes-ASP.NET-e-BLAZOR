using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
namespace CriticaFilmes.Models
{
    public class Critica: Modelo<Critica>
    {
        public String NameFilme { get; set; } = "";
        public String Analise { get; set; } = "";
        public String Autor { get; set; } = "";
        public int Estrelas { get; set; }
    }
}
