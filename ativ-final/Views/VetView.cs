using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Controllers;
using ativ_final.Models;

namespace ativ_final.Views
{
	public class VetView
	{
		private VetController vetController;

		public VetView()
		{
			vetController = new VetController();
			this.Init();
		}

		public void Init()
		{

			int option;

			do
			{
				Utils.BoxPrint("Veterinarios");

				var menu = new Menu(new string[] { "1 - Inserir", "2 - Listar", "3 - Exportar", "4 - Importar", "5 - Pesquisar (nome)", "6 - Voltar" });
				menu.Draw();

				Console.Write("\nOpção: ");
				Int32.TryParse(Console.ReadLine(), out option);

				switch (option)
				{
					case 1: Insert(); break;
					case 2: List(); break;
					case 3: Export(); break;
					case 4: Import(); break;
					case 5: SearchByName(); break;
					case 6: break;
					default:
						Console.Write(new string(' ', Console.WindowWidth));
						Console.WriteLine("Opção inválida.");
						Utils.Pause();
						break;
				}
			} while (option != 6);
		}

		private void List()
		{
			List<Veterinarian> listagem = vetController.List();

			for (int i = 0; i < listagem.Count; i++)
			{
				Console.WriteLine(Print(listagem[i]));
			}

			Utils.Pause();
		}

		private string Print(Veterinarian vet)
		{
			string retorno = "";
			retorno += $"Id: {vet.Id} \n";
			retorno += $"Nome: {vet.FullName} \n";
			retorno += $"CPF: {vet.CPF} \n";
			retorno += $"Clinica: {vet.ClinicName()} \n";
			retorno += "-------------------------------------------";
			
			return retorno;
		}

		private void Insert()
		{
			Veterinarian vet = new()
			{
				Id = vetController.GetNextId()
			};

			Console.Write("Informe o primeiro nome: ");
			vet.FirstName = Console.ReadLine();
			
			Console.Write("Informe o ultimo nome: ");
			vet.LastName = Console.ReadLine();

			Console.Write("Informe o CPF: ");
			vet.CPF = Console.ReadLine();

			Console.Write("Informe o ID da clinica: ");
			vet.Clinic = Convert.ToInt32(Console.ReadLine());

			if (vetController.Insert(vet))
				Console.WriteLine("Veterinario Inserido com sucesso!");

			Utils.Pause();
		}

		private void Export()
		{
			if (vetController.ExportToTextFile())
				Console.WriteLine("Arquivo gerado com sucesso!");
			else
				Console.WriteLine("Erro!");

			Utils.Pause();
		}

		private void Import()
		{
			if (vetController.ImportFromTxtFile())
				Console.WriteLine("Arquivo importado com sucesso!");
			else
				Console.WriteLine("Erro!");

			Utils.Pause();
		}

		private void SearchByName()
		{
			Console.Write("Digite o nome para pesquisar: ");
			string? input = Console.ReadLine();

			List<Veterinarian>? vets = new List<Veterinarian>();
			vets = vetController.SearchByName(input);

			if (vets?.Count > 0)
			{
				foreach (Veterinarian vet in vets)
				{
					Console.WriteLine(vet.ToString());
				}
			}
			else
			{
				Console.WriteLine("Nenhum registro encontrado.");
			}

			Utils.Pause();
		}
	}
}