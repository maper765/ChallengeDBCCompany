using System;

namespace ChallengeDBCCompany.Templates
{
	/// <summary>
	///		Cria instância para os objetos e atributos que compõem
	///		o relatório.
	/// </summary>
    public class FactoryTemplate
    {
		/// <summary>
		///		Obtêm uma instância para a implementação de 
		///		<see cref="ITemplate"/>.
		/// </summary>
		/// <param name="formatId">Código que identifica o template.</param>
		/// <returns></returns>
		public static ITemplate GetInstance(string formatId)
		{
			var namespaceTemplate =
				$"ChallengeDBCCompany.Templates.Template{formatId}";
			Type classe = Type.GetType(namespaceTemplate);

			return Activator.CreateInstance(classe) as ITemplate;
		}
	}
}
