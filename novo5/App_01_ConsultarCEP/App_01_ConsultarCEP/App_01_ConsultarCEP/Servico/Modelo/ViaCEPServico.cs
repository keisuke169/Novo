using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App_01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;



namespace App_01_ConsultarCEP.Servico.Modelo
{
  public  class ViaCEPServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";
        
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end =JsonConvert.DeserializeObject<Endereco>(Conteudo);
			if (end.cep == null) return null;
            return end;
        }
    }
}
