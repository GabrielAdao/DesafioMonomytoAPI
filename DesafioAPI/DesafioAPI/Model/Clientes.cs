using Newtonsoft.Json;

namespace DesafioAPI.Model
{
    public class Clientes
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }

        public Clientes()
        {
        } 
    }
}
