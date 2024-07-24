using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticaApi.Models;

namespace CriticaApi.DAOs
{
    public class CriticaDAO : BaseDAO<Critica>
    {
        public override string NomeTabela => "critica";

        public override Mapa[] Mapas => new Mapa[]
        {
            
            new() { Propriedade = "NameFilme", Campo = "nameFilme" },
            new() { Propriedade = "Analise", Campo = "analise" },
            new() { Propriedade = "Autor", Campo = "autor" },
            new() { Propriedade = "Estrelas", Campo = "estrelas" }
        };
    }
}
