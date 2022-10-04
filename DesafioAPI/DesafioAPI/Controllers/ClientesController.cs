using Newtonsoft.Json;
using DesafioAPI.Model;

namespace DesafioAPI.Controllers
{
    public class ClientesController
    {
        public static async Task<string> GetAllUsers(Uri u)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
                return response;
            }
        }

        public static async Task<Clientes> GetUserByNome(Uri u, string Nome)
        {
            var client = new HttpClient();
            var resposta = await client.GetAsync(u);
            var body = resposta.Content;
            var clientes = await body.ReadAsAsync<List<Clientes>>();

            var respostaList = clientes.Find(x => x.Nome == Nome);
            
            return respostaList;

        }

        public static async Task<List<string>> GetUserById(Uri u, string Id)
        {
            var client = new HttpClient();
            var resposta = await client.GetAsync(u);
            var body = resposta.Content;
            var clientes = await body.ReadAsAsync<List<Clientes>>();

            var respostaList = new List<string>();


            foreach (var cliente in clientes)
            {
                if (cliente.Id == Id)
                {
                    respostaList.Add(cliente.Nome);
                    respostaList.Add(cliente.DataNascimento);
                }
            }

            return respostaList;

        }
    }
}
