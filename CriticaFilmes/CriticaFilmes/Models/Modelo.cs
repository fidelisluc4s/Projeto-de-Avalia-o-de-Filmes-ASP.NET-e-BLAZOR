using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
namespace CriticaFilmes.Models
{
    public abstract class Modelo<T> where T : Modelo<T>
    {
        public string? Id { get; set; }

    }
}
