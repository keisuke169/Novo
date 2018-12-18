using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_01_ConsultarCEP.Servico.Modelo;
using App_01_ConsultarCEP.Servico;

namespace App_01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BOTAO.Clicked += BuscarCEP;

		}

		private void BuscarCEP(object sender, EventArgs args)
		{

			string cep = CEP.Text.Trim();
			if (isValidCEP(cep) == true) {
				try
				{
					Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
					if (end != null)
					{
						RESULTADO.Text = string.Format("Endereco:{0},{1} {2}", end.localidade, end.uf, end.logradouro);
					}
					else
					{
						DisplayAlert("Erro Crítico", cep + "O CEP não existe", "OK");
						

					}
				}
				catch (Exception e)
				{
					
					DisplayAlert("Erro Crítico", e.Message, "OK");
				}
				

			}
		}
		

		private bool isValidCEP( String cep)
		{
			bool valido = true;
			if (cep.Length != 8)
			{
				DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 dígitos.", "OK");
				valido = false;
			}
			int NovoCep = 0;
			if (!int.TryParse(cep, out NovoCep)) {
				DisplayAlert("ERRO", "CEP inválido! O CEP deve conter apenas números.", "OK");
				valido = false;
			}
			return valido;
		}
	}

}
