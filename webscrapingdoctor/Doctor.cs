using System;
using Newtonsoft.Json;

namespace webscrapingdoctor
{
    public class Doctor
    {
        public string Categoria { get; set; }

        [JsonProperty("disponivel_pesquisa")]
        public string DisponivelPesquisa { get; set; }

        public string Email { get; set; }

        [JsonProperty("end_estado")]
        public string Estado { get; set; }

        [JsonProperty("end_municipio")]
        public string Municipio { get; set; }

        [JsonProperty("end_uf")]
        public string UF { get; set; }

        public string Especialidade { get; set; }
        public string Foto { get; set; }

        [JsonProperty("id_cat")]
        public string IdCat { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }

        //[JsonProperty("num_conselho")]
        //public string num_conselho { get; set; }

        [JsonProperty("num_conselho_extras")]
        public string NumeroConselhoExtras { get; set; }

        [JsonProperty("numero_conselho")]
        public string CRM { get; set; }

        [JsonProperty("pessoa_id")]
        public string PessoaId { get; set; }
        public string Profissao { get; set; }

        [JsonProperty("pronome_tratamento")]
        public string Pronome { get; set; }

        [JsonProperty("publicar_pagina")]
        public string PublicarPagina { get; set; }

        [JsonProperty("rqe_descricao")]
        public string Descricao { get; set; }
        public string Sexo { get; set; }
        public string Titulos { get; set; }

        [JsonProperty("uf_conselho")]
        public string UFConselho { get; set; }

        public string Website { get; set; }

        public string Telefone { get; set; }


        public List<Phone> Telefones
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Telefone))
                    return new List<Phone>();

                return JsonConvert.DeserializeObject<List<Phone>>(Telefone);
            }
        }


    }
}

