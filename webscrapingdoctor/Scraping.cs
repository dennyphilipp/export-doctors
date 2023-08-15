using System.Globalization;
using Newtonsoft.Json;
using CsvHelper;

namespace webscrapingdoctor
{
    public class Scraping
    {
        private List<string> estados = new List<string>() {
                            "AC",
                            "AL",
                            "AP",
                            "AM",
                            "BA",
                            "CE",
                            "DF",
                            "ES",
                            "GO",
                            "MA",
                            "MT",
                            "MS",
                            "MG",
                            "PA",
                            "PB",
                            "PR",
                            "PE",
                            "PI",
                            "RJ",
                            "RN",
                            "RS",
                            "RO",
                            "RR",
                            "SC",
                            "SP",
                            "SE",
                            "TO"
        };
        public Scraping()
        {
        }


        public async void Execute()
        {
            var itens = new List<Doctor>();

            foreach (var item in estados)
            {
                var result = await GetDoctors(item);
                itens.AddRange(result);
            }

            var csvModel = itens.AsParallel().Select(s => new CSVModel {
                Categoria = s.Categoria,
                CRM = s.CRM,
                Descricao = s.Descricao,
                DisponivelPesquisa = s.DisponivelPesquisa,
                Email = s.Email,
                Especialidade = s.Especialidade,
                Estado = s.Estado,
                Foto = s.Foto,
                Matricula = s.Matricula,
                Municipio = s.Municipio,
                Nome = s.Nome,
                NumeroConselhoExtras = s.NumeroConselhoExtras,
                Profissao = s.Profissao,
                Pronome = s.Pronome,
                PublicarPagina = s.PublicarPagina,
                Sexo = s.Sexo,
                Telefone = String.Join(" / ", s.Telefones.Select(s => s.ddi + " " + s.fone )),
                Titulos = s.Titulos,
                UF = s.UF,
                UFConselho = s.UFConselho,
                Website = s.Website
            }).ToList();
            SaveCsv(csvModel);
        }


        private async Task<List<Doctor>> GetDoctors(string uf)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://x.com.br/");
                var result = await client.GetAsync($"x?format=json&nome=&categoria_profissional_id=&uf_descricao={uf}");

                var data = JsonConvert.DeserializeObject<Dado>(await result.Content.ReadAsStringAsync());
                return data.Data;
            }
        }

        private void SaveCsv(List<CSVModel> list)
        {

            using (var writer = new StreamWriter("medicos.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }
    }
}

