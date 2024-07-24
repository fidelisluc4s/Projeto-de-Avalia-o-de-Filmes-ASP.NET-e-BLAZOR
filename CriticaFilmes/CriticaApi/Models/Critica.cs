namespace CriticaApi.Models
{
    public class Critica : IModel
    {

        public String? Id { get; set; }
        public String? NameFilme { get ; set; }
        public String? Analise { get; set; }
        public String? Autor { get; set; }
        public int Estrelas { get; set; }
    }
}
